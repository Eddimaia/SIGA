using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SIGA.Application.Configuration.API;
using System.Text;

namespace SIGA.API.Configuration;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtAppSettingOptions = configuration.GetSection(nameof(Jwt));
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtAppSettingOptions[nameof(Jwt.SecurityKey)]!));

        services.Configure<Jwt>(options =>
        {
            options.Issuer = jwtAppSettingOptions[nameof(Jwt.Issuer)] ?? "SIGA.API";
            options.Audience = jwtAppSettingOptions[nameof(Jwt.Audience)] ?? "SIGA.Web";
            options.SecurityKey = jwtAppSettingOptions[nameof(Jwt.SecurityKey)]!;
            options.AccessTokenExpiration = int.Parse(jwtAppSettingOptions[nameof(Jwt.AccessTokenExpiration)] ?? "30");
            options.RefreshTokenExpiration = int.Parse(jwtAppSettingOptions[nameof(Jwt.RefreshTokenExpiration)] ?? "480");
        });

        return services;
    }

    public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtAppSettingOptions = configuration.GetSection(nameof(Jwt));
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtAppSettingOptions[nameof(Jwt.SecurityKey)]!));

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
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(Jwt.Issuer)] ?? "SIGA.API",

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(Jwt.Audience)] ?? "SIGA.Web",

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };
        });

        services.AddAuthorization();

        return services;
    }
}
