using UsersService.Infra.Repositories.Base;

namespace UsersService.Infra.Repositories;

public class SessionRepository 
    : Repository<SessionEntity, int>, ISessionRepository 
{
    public SessionRepository(AuthDbContext dbContext) : base(dbContext)
    {
    }
}