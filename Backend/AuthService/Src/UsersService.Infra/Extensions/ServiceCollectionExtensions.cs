using UsersService.Infra.Repositories;
using UsersService.Infra.Services;
using UsersService.Infra.UoF;

namespace UsersService.Infra.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddUnitOfWork(this IServiceCollection services)
    {
        services
            .AddTransient<IUnitOfWork, UnitOfWork>();
    }
    
    public static void AddRepositories(this IServiceCollection services)
    {
        services
            .AddTransient<IUserRepository, UserRepository>()
            .AddTransient<IRoleRepository, RoleRepository>()
            .AddTransient<IPermissionRepository, PermissionRepository>()
            .AddTransient<ISessionRepository, SessionRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services
            .AddTransient<IUserService, UserService>()
            .AddTransient<IRoleService, RoleService>()
            .AddTransient<IPermissionService, PermissionService>()
            .AddTransient<ISessionService, SessionService>()
            .AddTransient<ITokenService, TokenService>();
    }
}