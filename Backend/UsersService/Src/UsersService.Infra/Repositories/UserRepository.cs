using UsersService.Domain.ValueObjects;

namespace UsersService.Infra.Repositories;

public class UserRepository
    : Repository<User, int>, IUserRepository
{
    public UserRepository(
        UsersDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<User?> GetByUsernameAsync(
        Username username, 
        CancellationToken cancellationToken, 
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = default,
        bool asTracking = default)
    {
        var query = asTracking ? _dbSet.AsTracking() : _dbSet.AsNoTrackingWithIdentityResolution();
        
        query = include is null ? query : include(query);

        return await query.SingleOrDefaultAsync(u => u.Username.Equals(username), cancellationToken);
    }
}