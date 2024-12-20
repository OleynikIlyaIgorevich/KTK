namespace Infra.Repositories;

public class SessionRepository 
    : Repository<SessionEntity, int>, ISessionRepository 
{
    public SessionRepository(AuthDbContext dbContext) : base(dbContext)
    {
    }
}