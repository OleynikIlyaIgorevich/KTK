using UsersService.Domain.ValueObjects;
using UsersService.Infra.Services.Base;

namespace UsersService.Infra.Services;

public class UserService 
    : BaseService, IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository) 
        : base(unitOfWork)
    {
        _userRepository = userRepository;
    }

    public Task<OperationResult<UserResponse>> GetByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult<PaginatedData<UserResponse>>> GetPaginatedAsync(
        int pageNumber, int pageSize,
        string sortBy, string searchTerms,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IOperationResult> CreateAsync(
        CreateUserRequest request, 
        CancellationToken cancellationToken)
    {
        var username = await Username.CreateAsync(request.Username);
        var user = new User(username.Data, BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password), request.ActivateUser);

        await _userRepository.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return await OperationResult.SuccessAsync();
    }

    public Task<IOperationResult> DeleteAsync(
        int id,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IOperationResult> UpdateAsync(
        int id, UpdateUserRequest request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}