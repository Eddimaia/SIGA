using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SIGA.API.Configuration;
using SIGA.API.Endpoints;
using SIGA.Infrastructure.Context;
using SIGA.IoC.Setup;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
   .AddDataProtection(o =>
   {
       o.ApplicationDiscriminator = "SIGA";
   });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddIoCServices();
        builder.Services.AddIoCHandles();
        builder.Services.AddConfigurations(builder.Configuration);
        builder.Services.AddSecurity(builder.Configuration);
        builder.Services.AddCors(
        options => options.AddPolicy("CORSTESTE", policy
            => policy
                    .WithOrigins("http://localhost:5222")
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials()
            ));

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminCreateOnly", policy =>
            {
                policy.RequireRole("Admin");
                policy.RequireClaim("Create");
            });
        });


        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("CORSTESTE");
        app.UseAuthentication();
        app.UseAuthorization();

        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<AppDbContext>();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Erro na migração");
        }

        app.UseStaticFiles();
        app.MapEndpoints();
        app.Run();
    }
}