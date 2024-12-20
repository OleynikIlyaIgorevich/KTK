namespace Infra.Repositories;

public class RoleRepository
    : Repository<RoleEntity, int>, IRoleRepository
{
    public RoleRepository(AuthDbContext dbContext) : base(dbContext)
    {
    }
}