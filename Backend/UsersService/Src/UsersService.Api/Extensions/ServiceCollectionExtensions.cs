namespace UsersService.Api.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddJwtAuthentication(
        this IServiceCollection services, IConfiguration configuration)
    {
        var secretKey = configuration.GetSection("JwtOptions:SecretKey").Value 
                        ?? throw new ArgumentException("Secret key is missing");
        
        services
            .AddAuthentication(authentication =>
            {
                authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearer =>
            {
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromDays(1)
                };

                bearer.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        if (!string.IsNullOrEmpty(accessToken)) 
                            context.Token = accessToken;

                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception is SecurityTokenExpiredException)
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            context.Response.ContentType = "application/json";
                            var result = JsonSerializer.Serialize(OperationResult.Fail("Время жизни токена истекло!"));
                            return context.Response.WriteAsync(result);
                        }
                        else
                        {
#if DEBUG
                            context.NoResult();
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.ContentType = "text/plain";
                            return context.Response.WriteAsync(context.Exception.ToString());
#else
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.ContentType = "application/json";
                            var result = JsonSerializer.Serialize(Result.Fail("Произошло необработанное исключение!"));
                            return context.Response.WriteAsync(result);
#endif
                        }
                    },
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        if (context.Response.HasStarted) return Task.CompletedTask;
                        
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        context.Response.ContentType = "application/json";
                        var result = JsonSerializer.Serialize(OperationResult.Fail("Вы не авторизованы!"));
                        return context.Response.WriteAsync(result);

                    },
                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        context.Response.ContentType = "application/json";
                        var result = JsonSerializer.Serialize(OperationResult.Fail("Доступ к данному ресурсу запрещён!"));
                        return context.Response.WriteAsync(result);
                    }
                };
            });
        services.AddAuthorization(options =>
        {
            // Here I stored necessary permissions/roles in a constant
            var permissionsList = Permissions.GetRegisteredPermissions();
            foreach (var permission in permissionsList)
                    options.AddPolicy(permission, policy => 
                        policy.RequireClaim(ApplicationClaimTypes.Permission, permission));
        });
        return services;
    }}