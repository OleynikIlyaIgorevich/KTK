using UsersService.Infra.Repositories.Base;

namespace UsersService.Infra.Repositories;

public class PermissionRepository
    : Repository<PermissionEntity, int>, IPermissionRepository
{
    public PermissionRepository(AuthDbContext dbContext) : base(dbContext)
    {
    }
}