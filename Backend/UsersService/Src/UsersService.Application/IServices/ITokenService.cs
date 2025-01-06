using UsersService.Application.Requests;
using UsersService.Application.Responses;

namespace UsersService.Application.IServices;

public interface ITokenService
{
    Task<IOperationResult<TokenResponse>> CreateAsync(TokenRequest request, CancellationToken cancellationToken);
    Task<IOperationResult<TokenResponse>> RefreshAsync(RefreshTokenRequest request, CancellationToken cancellationToken);
    Task<IOperationResult<TokenResponse>> RevokeAsync(RevokeTokenRequest request, CancellationToken cancellationToken);
}