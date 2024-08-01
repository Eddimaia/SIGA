using SIGA.Application.DTO.Accounts;
using SIGA.Application.DTO.Common;
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

        return TypedResults.Ok(result.Data);
    }
}
