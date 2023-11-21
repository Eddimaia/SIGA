using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;
using System.Text.Json.Serialization;
using SIGA.API;
using SIGA.API.Services;
using System.Text;
using SIGA.Repositories.Interfaces;
using SIGA.Repositories;
using SIGA.Infra.Data;
using Microsoft.AspNetCore.Identity;
using SIGA.Domain.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SIGA.Domain.Entities;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

LoadConfiguration(builder);
ConfigureAuthentication(builder);
ConfigureServices(builder);
ConfigureMvc(builder);



var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCompression();
app.UseStaticFiles();
app.MapControllers();
app.UseCors();
app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddAutoMapper(new Type[]
    {
        typeof(ConcessaoMappingProfile),
        typeof(ContaMappingProfile),
        typeof(GrupoMappingProfile),
        typeof(ProjetoMappingProfile),
        typeof(RoleMappingProfile)
    });

    builder.Services.AddEndpointsApiExplorer().
        AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "apisiga", Version = "v1" });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Description",
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada.");

    builder.Services
        .AddDbContext<SIGAAppDbContext>(options => options.UseSqlServer(connectionString));

    builder.Services
        .AddIdentity<ApplicationUser, IdentityRole<int>>()
        .AddEntityFrameworkStores<SIGAAppDbContext>()
        .AddDefaultTokenProviders();


    builder.Services.AddTransient<TokenService>()
        .AddTransient<IFuncionarioRepository, FuncionarioRepository>()
        .AddTransient<IContaRepository, FuncionarioRepository>()
        .AddTransient<IRoleRepository, RoleRepository>()
        .AddTransient<IProjetoRepository, ProjetoRepository>()
        .AddTransient<IGrupoRepository, GrupoRepository>();

    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policyOptions =>
        {
            policyOptions.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
    });
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

    Configuration.JwtKey = builder.Configuration.GetValue<string>("JwtKey")
        ?? throw new InvalidOperationException("JwtKey não encontrada.");

    Configuration.ApiKeyName = builder.Configuration.GetValue<string>("ApiKeyName")
        ?? throw new InvalidOperationException("ApiKeyName não encontrada.");

    Configuration.ApiKey = builder.Configuration.GetValue<string>("ApiKey")
        ?? throw new InvalidOperationException("ApiKey não encontrada.");

    Configuration.Issuer = builder.Configuration.GetValue<string>("Issuer")
        ?? throw new InvalidOperationException("Issuer não encontrado.");

    Configuration.Audience = builder.Configuration.GetValue<string>("Audience")
        ?? throw new InvalidOperationException("Audience não encontrado.");
}

void ConfigureAuthentication(WebApplicationBuilder builder)
{
    var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

    builder.Services.AddAuthentication(authenticationOptions =>
    {
        authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        authenticationOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

    }).AddJwtBearer(jwtBearerOptions =>
    {
        jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = Configuration.Issuer,
            ValidAudience = Configuration.Audience
        };
    });
}