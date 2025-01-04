using UsersService.Application.Requests;
using UsersService.Application.Responses;

namespace UsersService.Application.IServices;

public interface ITokenService
{
    Task<IResult<TokenResponse>> CreateAsync(TokenRequest request, CancellationToken cancellationToken);
    Task<IResult<TokenResponse>> RefreshAsync(RefreshTokenRequest request, CancellationToken cancellationToken);
    Task<IResult<TokenResponse>> RevokeAsync(RevokeTokenRequest request, CancellationToken cancellationToken);
}