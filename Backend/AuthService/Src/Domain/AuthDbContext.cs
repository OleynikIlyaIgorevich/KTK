namespace Domain;

public class AuthDbContext(
    DbContextOptions<AuthDbContext> options) 
    : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<SessionEntity> Sessions { get; set; } = null!;
    public DbSet<RoleEntity> Roles { get; set; } = null!;
    public DbSet<PermissionEntity> Permissions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}