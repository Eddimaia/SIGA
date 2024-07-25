using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SIGA.Application.Handles.Interfaces;
using SIGA.Application.Services.Interfaces;
using SIGA.Infrastructure.Context;
using SIGA.IoC.Handles;
using SIGA.IoC.Services;
using System.Text;

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

        return services;
    }

    public static IServiceCollection AddIoCServices(this IServiceCollection services)
    {
        services.AddSingleton<ITokenService, JwtAuthService>();
        services.AddSingleton<IPasswordService, PasswordService>();

        return services;
    }

    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = true;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("TESTE_KEY_API_QLÇWJKSAAZZXCV@$41x2412#!@#$!$")),
                ValidateLifetime = true
            };
        });

        services.AddAuthorization();

        return services;
    }
}