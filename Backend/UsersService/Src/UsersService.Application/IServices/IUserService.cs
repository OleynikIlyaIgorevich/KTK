
namespace UsersService.Application.IServices;

public interface IUserService
{
    Task<OperationResult<UserResponse>> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<OperationResult<PaginatedData<UserResponse>>> GetPaginatedAsync(int pageNumber, int pageSize, string sortBy, string searchTerms, CancellationToken cancellationToken);

    Task<IOperationResult> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken);
    Task<IOperationResult> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<IOperationResult> UpdateAsync(int id, UpdateUserRequest request, CancellationToken cancellationToken);
}