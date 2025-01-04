namespace UsersService.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AuthDbContext>(options => options
            .UseNpgsql(configuration.GetConnectionString(
                nameof(AuthDbContext))));
    }
        
}