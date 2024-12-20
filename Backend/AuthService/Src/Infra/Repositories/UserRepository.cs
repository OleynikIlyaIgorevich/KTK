namespace Infra.Repositories;

public class UserRepository
    : Repository<UserEntity, int>, IUserRepository
{
    public UserRepository(AuthDbContext dbContext) : base(dbContext)
    {
    }
}