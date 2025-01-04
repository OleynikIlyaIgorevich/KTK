namespace UsersService.Application.IRepositories;

public interface IUserRepository
    : IRepository<UserEntity, int>
{
    Task<UserEntity?> GetByUsernameAsync(
        string value,
        CancellationToken cancellationToken,
        Func<IQueryable<UserEntity>, IIncludableQueryable<UserEntity, object>>? include = default,
        bool asTracking = default);
}