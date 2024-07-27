using SIGA.Application.DTO;
using SIGA.Application.DTO.Account;
using SIGA.Application.Handles.Interfaces;

namespace SIGA.API.Endpoints.Accounts;

public class LoginAccountEndpoint() : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/Login", HandleAsync)
                .WithName("Accounts: Login")
                .WithSummary("Login do usuário")
                .WithDescription("Login do usuário")
                .WithOrder(2)
                .Produces<Response<LoginResponse?>>()
                .AllowAnonymous();

    private static async Task<IResult> HandleAsync(
        HttpContext http,
        IAccountHandler handler,
        LoginRequest request)
    {
        var result = await handler.LoginAsync(request);

        if (result.Code == StatusCodes.Status404NotFound)
            return TypedResults.NotFound(result.Message);

        if (result.Code == StatusCodes.Status401Unauthorized)
            return TypedResults.Unauthorized();

        if (result.Code == StatusCodes.Status500InternalServerError)
            return TypedResults.Problem();

        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Lax,
            Expires = DateTime.Now.AddHours(3)
        };

        http.Response.Cookies.Append("jwt", result.Data!.Token, cookieOptions);
        http.Response.Cookies.Append("refresh", result.Data!.RefreshToken, cookieOptions);

        return TypedResults.Ok(result.Data);
    }
}
