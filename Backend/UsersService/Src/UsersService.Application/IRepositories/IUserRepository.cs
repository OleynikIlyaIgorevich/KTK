using UsersService.Domain.ValueObjects;

namespace UsersService.Application.IRepositories;

public interface IUserRepository
    : IRepository<User, int>
{
    Task<User?> GetByUsernameAsync(
        Username username,
        CancellationToken cancellationToken,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = default,
        bool asTracking = default);
}