using Microsoft.AspNetCore.DataProtection;
using SIGA.Application.DTO;
using SIGA.Application.DTO.Account;
using SIGA.Application.Handles.Interfaces;
using System.Text.Json;

namespace SIGA.API.Endpoints.Accounts;

public class InfoAccountEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/Info", HandleAsync)
                    .RequireAuthorization()
                    .WithName("Accounts: UserInfo")
                    .WithSummary("Tokens do usuário")
                    .WithDescription("Tokens do usuário")
                    .WithOrder(4)
                    .Produces<Response<RegisterResponse>>();

    private static IResult HandleAsync(HttpContext httpContext, string login, IAccountHandler handler, IDataProtectionProvider provider)
    {
        var protector = provider.CreateProtector("SIGA");
        if (httpContext.Request.Cookies.TryGetValue("User_Info", out var userInfo))
        {
            try
            {
                var jsonData = protector.Unprotect(userInfo);
                if (jsonData == null)
                {
                    // Log ou manipulação adicional
                    return TypedResults.BadRequest("Desprotection returned null");
                }

                var user = JsonSerializer.Deserialize<RegisterResponse>(jsonData);
                return TypedResults.Ok(user);
            }
            catch (Exception ex)
            {
                // Log do erro
                Console.WriteLine($"Error unprotecting data: {ex.Message}");
                return TypedResults.BadRequest("Invalid cookie");
            }
        }
        return TypedResults.NotFound("Cookie not found");
    }

}
