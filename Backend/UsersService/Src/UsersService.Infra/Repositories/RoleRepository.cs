namespace UsersService.Infra.Repositories;

public class RoleRepository
    : Repository<Role, int>, IRoleRepository
{
    public RoleRepository(
        UsersDbContext dbContext) 
        : base(dbContext)
    {
    }
}