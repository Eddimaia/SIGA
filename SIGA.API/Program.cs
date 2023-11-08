using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;
using System.Text.Json.Serialization;
using SIGA.Lib.Extensions;
using SIGA.API;
using SIGA.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SIGA.Repositories.Interfaces;
using SIGA.Repositories.Data;
using SIGA.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

LoadConfiguration(builder);
ConfigureAuthentication(builder);
ConfigureServices(builder);
ConfigureMvc(builder);



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCompression();
app.UseStaticFiles();
app.MapControllers();
app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
	builder.Services.AutoMapperBuild();
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada.");
    builder.Services.AddDbContext<SIGAAppDbContext>(options => options.UseSqlServer(connectionString));
	builder.Services.AddTransient<TokenService>();
	builder.Services.AddTransient<IContaRepository, ContaRepository>();
	builder.Services.AddTransient<IRoleRepository, RoleRepository>();
	builder.Services.AddTransient<IProjetoRepository, ProjetoRepository>();
}

void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services
        .AddMemoryCache()
        .AddResponseCompression(options =>
        {
            options.Providers.Add<GzipCompressionProvider>();
        })
        .AddControllers()
        .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)//removendo a validação padrão dos controladores)
        .AddJsonOptions(jsonOptions =>
        {
            jsonOptions.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            jsonOptions.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

    builder.Services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
}

void LoadConfiguration(WebApplicationBuilder builder)
{

	Configuration.JwtKey = builder.Configuration.GetValue<string>("JwtKey") ?? throw new InvalidOperationException("JwtKey não encontrada.");
	Configuration.ApiKeyName = builder.Configuration.GetValue<string>("ApiKeyName") ?? throw new InvalidOperationException("ApiKeyName não encontrada.");
	Configuration.ApiKey = builder.Configuration.GetValue<string>("ApiKey") ?? throw new InvalidOperationException("ApiKey não encontrada.");
}

void ConfigureAuthentication(WebApplicationBuilder builder)
{
	var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

	builder.Services.AddAuthentication(authenticationOptions =>
	{
		authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	}).AddJwtBearer(jwtBearerOptions =>
	{
		jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(key),
			ValidateIssuer = false,
			ValidateAudience = false
		};
	});
}