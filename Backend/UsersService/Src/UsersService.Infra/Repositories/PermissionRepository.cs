namespace UsersService.Infra.Repositories;

public class PermissionRepository
    : Repository<Permission, int>, IPermissionRepository
{
    public PermissionRepository(
        UsersDbContext dbContext)
        : base(dbContext)
    {
    }
}