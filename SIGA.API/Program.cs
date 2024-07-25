using Microsoft.EntityFrameworkCore;
using SIGA.API.Endpoints;
using SIGA.Infrastructure.Context;
using SIGA.IoC.Setup;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddIoCServices();
        builder.Services.AddIoCHandles();
        builder.Services.AddSecurity();
        builder.Services.AddCors(
        options => options.AddPolicy("CORSTESTE",policy 
        => policy
                    .WithOrigins("https://localhost:7185", "http://localhost:5222")
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials()
            ));


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors("CORSTESTE");

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

        app.MapEndpoints();
        app.Run();
    }
}