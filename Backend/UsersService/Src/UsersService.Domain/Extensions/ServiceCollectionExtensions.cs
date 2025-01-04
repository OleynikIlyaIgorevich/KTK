namespace UsersService.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<UsersDbContext>(options =>
        {
            options
                .UseNpgsql(configuration.GetConnectionString(
                    nameof(UsersDbContext)))
                .UseLazyLoadingProxies();
        });
    }
}
        
