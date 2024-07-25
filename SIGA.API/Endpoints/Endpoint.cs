using SIGA.API.Endpoints.Accounts;

namespace SIGA.API.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app
            .MapGroup("");

        endpoints.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK" });

        endpoints.MapGroup("v1/accounts")
            .WithTags("Accounts")
            .AllowAnonymous()
            .MapEndpoint<RegisterAccountEndpoint>()
            .MapEndpoint<LoginAccountEndpoint>()
            .MapEndpoint<RefreshTokenAccountEndpoint>()
            .MapEndpoint<InfoAccountEndpoint>()
            .MapEndpoint<LogoutAccountEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
