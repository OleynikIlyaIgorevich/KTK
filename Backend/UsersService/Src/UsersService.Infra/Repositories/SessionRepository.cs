namespace UsersService.Infra.Repositories;

public class SessionRepository 
    : Repository<Session, int>, ISessionRepository 
{
    public SessionRepository(
        UsersDbContext dbContext) 
        : base(dbContext)
    {
    }
}