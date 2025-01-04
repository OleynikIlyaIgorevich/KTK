namespace UsersService.Infra.UoF;

public class UnitOfWork : IUnitOfWork
{
    private readonly AuthDbContext _dbContext;

    public UnitOfWork(AuthDbContext  dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
        => await _dbContext.SaveChangesAsync(false, cancellationToken) > 0;
}