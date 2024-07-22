using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIGA.Infrastructure.Context;

namespace SIGA.Infrastructure.Setup;
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
}
