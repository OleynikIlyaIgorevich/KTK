using UsersService.Infra.Repositories.Base;

namespace UsersService.Infra.Repositories;

public class UserRepository
    : Repository<UserEntity, int>, IUserRepository
{
    public UserRepository(AuthDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<UserEntity?> GetByUsernameAsync(
        string value, 
        CancellationToken cancellationToken, 
        Func<IQueryable<UserEntity>, IIncludableQueryable<UserEntity, object>>? include = default,
        bool asTracking = default)
    {
        var query = asTracking ? _dbSet.AsTracking() : _dbSet.AsNoTrackingWithIdentityResolution();
        
        query = include is null ? query : include(query);

        return await query.SingleOrDefaultAsync(u => u.Username == value, cancellationToken);
    }
}