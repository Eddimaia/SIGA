using SIGA.Application.DTO;

namespace SIGA.API.Endpoints.Accounts;

public class InfoAccountEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/Info", HandleAsync)
                    .WithName("Accounts: UserInfo")
                    .WithSummary("Tokens do usuário")
                    .WithDescription("Tokens do usuário")
                    .WithOrder(4)
                    .Produces<Response<string?>>();

    private static IResult HandleAsync(HttpContext httpContext)
    {
        if (httpContext.Request.Cookies.TryGetValue("jwt", out var token))
        {
            return TypedResults.Ok(token);
        }
        return TypedResults.Unauthorized();
    }
}
