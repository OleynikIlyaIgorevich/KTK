using Microsoft.EntityFrameworkCore;
using UsersService.Infra.Services.Base;

namespace UsersService.Infra.Services;

public class TokenService 
    : BaseService, ITokenService
{
    private readonly string _tokenSecret;
    
    private readonly ISessionRepository _sessionRepository;
    private readonly IUserRepository _userRepository;
    public TokenService(
        IConfiguration configuration,
        IUnitOfWork _unitOfWork,
        ISessionRepository sessionRepository,
        IUserRepository userRepository) 
        : base(_unitOfWork)
    {
        _tokenSecret = configuration.GetSection("JwtOptions:SecretKey").Value 
                       ?? throw new ArgumentException("Secret key is missing");

        
        _sessionRepository = sessionRepository;
        _userRepository = userRepository;
    }

    public async Task<IResult<TokenResponse>> CreateAsync(
        TokenRequest request,
        CancellationToken cancellationToken)
    {
        var userEntity = await _userRepository.GetByUsernameAsync(
            value: request.Username,
            include: i => i
                .Include(u => u.Roles)
                .ThenInclude(r => r.Permissions),
            cancellationToken: cancellationToken);
        if (userEntity == null)
        {
            return await Result<TokenResponse>
                .FailAsync("Неправильный логин или пароль");
        }
        
        var isPasswordConfirm = BCrypt.Net.BCrypt
            .Verify(request.Password, userEntity.PasswordHash);
        if (!isPasswordConfirm)
        {
            return await Result<TokenResponse>
                .FailAsync("Неправильный логин или пароль");
        }

        if (!userEntity.IsActive)
        {
            return await Result<TokenResponse>
                .FailAsync("Профиль не активирован обратитесь в дневное отделение!");
        }
            
        var refreshToken = GenerateRefreshToken();
        var accessToken = GenerateJwtAsync(userEntity, cancellationToken);

        var sessionEntity = new SessionEntity(
            userEntity.Id,
            refreshToken,
            DateTime.UtcNow.AddDays(7));
        
        await _sessionRepository.AddAsync(sessionEntity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var tokenResponse = new TokenResponse(accessToken, refreshToken);

        return await Result<TokenResponse>.SuccessAsync(tokenResponse);
    }

    public Task<IResult<TokenResponse>> RefreshAsync(
        RefreshTokenRequest request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IResult<TokenResponse>> RevokeAsync(
        RevokeTokenRequest request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
     private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
    
    private string GenerateJwtAsync(UserEntity user, CancellationToken cancellationToken) =>
        GenerateEncryptedToken(GetSigningCredentials(), GetClaimsAsync(user, cancellationToken));
    
    
    private string GenerateEncryptedToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims)
    {
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: signingCredentials);
        var tokenHandler = new JwtSecurityTokenHandler();
        var encryptedToken = tokenHandler.WriteToken(token);
        return encryptedToken;
    }
    
    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSecret)),
            ValidateIssuer = false,
            ValidateAudience = false,
            RoleClaimType = ClaimTypes.Role,
            ClockSkew = TimeSpan.FromDays(1),
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }
    
    private IEnumerable<Claim> GetClaimsAsync(UserEntity user, CancellationToken cancellationToken)
    {
        var rolesEntities = user.Roles;
        
        var roleClaims = new List<Claim>();
        var permissionClaims = new List<Claim>();
        foreach (var roleEntity in rolesEntities)
        {
            roleClaims.Add(new Claim(ClaimTypes.Role, roleEntity.Title));
            permissionClaims.AddRange(roleEntity.Permissions
                .Select(permissionEntity => 
                    new Claim(ApplicationClaimTypes.Permission, permissionEntity.Title)));
        }

        var claims = new List<Claim> 
        { 
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Username),
        }.Union(roleClaims).Union(permissionClaims);

        return claims;
    }

    private SigningCredentials GetSigningCredentials() =>
        new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSecret)),
            SecurityAlgorithms.HmacSha256);
}