using Microsoft.AspNetCore.Http;
using SIGA.Application.Handles.Interfaces;

namespace SIGA.API.Endpoints.Accounts;

public class LogoutAccountEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/Logout", HandleAsync)
                    .RequireAuthorization()
                    .WithName("Accounts: Logout")
                    .WithSummary("Logout do usuário")
                    .WithDescription("Logout do usuário")
                    .WithOrder(5);

    private static IResult HandleAsync(HttpContext httpContext, ILogoutRefreshEndpointHandler handler)
    {
        var requestIsOk = httpContext.Request.Cookies.TryGetValue("refresh", out var cookieRefresh);
        if (!requestIsOk)
        {
            return TypedResults.BadRequest();
        }


        httpContext.Response.Cookies.Delete("jwt");
        httpContext.Response.Cookies.Delete("refresh");
        handler.LogoutAsync(cookieRefresh);
        return TypedResults.Ok();
    }
}
