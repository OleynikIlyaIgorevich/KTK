using UsersService.Infra.Repositories.Base;

namespace UsersService.Infra.Repositories;

public class RoleRepository
    : Repository<RoleEntity, int>, IRoleRepository
{
    public RoleRepository(AuthDbContext dbContext) : base(dbContext)
    {
    }
}