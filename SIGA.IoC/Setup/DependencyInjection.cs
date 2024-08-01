using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIGA.Application.Handles.Interfaces;
using SIGA.Application.Services.Interfaces;
using SIGA.Infrastructure.Context;
using SIGA.IoC.Handles;
using SIGA.IoC.Services;

namespace SIGA.IoC.Setup;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                optionsDb =>
                {
                    optionsDb.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                });
        });

        return services;
    }

    public static IServiceCollection AddIoCHandles(this IServiceCollection services)
    {
        services.AddScoped<IAccountHandler, AccountHandler>();
        services.AddScoped<ILogoutRefreshEndpointHandler, AccountHandler>();
        services.AddScoped<IProjectHandler, ProjectHandler>();

        return services;
    }

    public static IServiceCollection AddIoCServices(this IServiceCollection services)
    {
        services.AddSingleton<ITokenService, JwtAuthService>();
        services.AddSingleton<IPasswordService, PasswordService>();

        return services;
    }
}