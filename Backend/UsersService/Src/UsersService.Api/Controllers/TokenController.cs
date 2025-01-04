namespace UsersService.Api.Controllers;

public class TokenController
    : BaseController
{
    private readonly ITokenService _tokenService;
    public TokenController(
        ITokenService tokenService)
    {
        _tokenService = tokenService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        TokenRequest request,
        CancellationToken cancellationToken = default)
    {
        return Ok(await _tokenService.CreateAsync(request, cancellationToken));
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshAsync(
        RefreshTokenRequest request,
        CancellationToken cancellationToken = default)
    {
        return Ok(await _tokenService.RefreshAsync(request, cancellationToken));
    }

    [HttpPost("revoke")]
    public async Task<IActionResult> RevokeAsync(
        RevokeTokenRequest request,
        CancellationToken cancellationToken = default)
    {
        return Ok(await _tokenService.RevokeAsync(request, cancellationToken));
    }
}