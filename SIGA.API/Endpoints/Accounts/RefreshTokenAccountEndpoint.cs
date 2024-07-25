
using SIGA.Application.DTO;
using SIGA.Application.DTO.Account;
using SIGA.Application.Handles.Interfaces;

namespace SIGA.API.Endpoints.Accounts;

public class RefreshTokenAccountEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/RefreshToken", HandleAsync)
                    .WithName("Accounts: RefreshToken")
                    .WithSummary("Atualiza o token do usuário")
                    .WithDescription("Atualiza o token do usuário")
                    .WithOrder(3)
                    .Produces<Response<LoginResponse?>>();

    private static async Task<IResult> HandleAsync(
        IAccountHandler handler,
        RefreshTokenRequest request)
    {
        var result = await handler.RefreshTokenAsync(request);

        if (result.Code == StatusCodes.Status404NotFound)
            return TypedResults.NotFound(result.Message);

        if (result.Code == StatusCodes.Status422UnprocessableEntity)
            return TypedResults.UnprocessableEntity(result.Message);

        if (result.Code == StatusCodes.Status500InternalServerError)
            return TypedResults.Problem();

        return TypedResults.Ok(result.Data);
    }
}
