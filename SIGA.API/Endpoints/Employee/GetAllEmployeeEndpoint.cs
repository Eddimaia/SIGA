using SIGA.Application.DTO.Common;
using SIGA.Application.DTO.Employee;
using SIGA.Application.Handles.Interfaces;

namespace SIGA.API.Endpoints.Employee;

public class GetAllEmployeeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
         => app.MapGet("/", HandleAsync)
                            //.RequireAuthorization()
                            .WithName("Employees: All")
                            .WithSummary("Lista de funcionários")
                            .WithDescription("Lista de funcionários")
                            .WithOrder(2)
                            .Produces<Response<List<EmployeeResponse>>>();

    private static async Task<IResult> HandleAsync(IEmployeeHandler handler)
    {
        var result = await handler.GetAllAsync();

        return result.IsSuccess ?
                TypedResults.Ok(result)
                : TypedResults.Problem();
    }
}
