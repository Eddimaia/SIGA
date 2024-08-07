
using Microsoft.AspNetCore.Mvc;
using SIGA.Application.DTO.Accounts;
using SIGA.Application.DTO.Common;
using SIGA.Application.DTO.Employee;
using SIGA.Application.DTO.Projects;
using SIGA.Application.Handles.Interfaces;

namespace SIGA.API.Endpoints.Employee;

public class GetPagedEmployeeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
         => app.MapGet("/paged", HandleAsync)
                            //.RequireAuthorization()
                            .WithName("Employees: Paged")
                            .WithSummary("Lista de funcionários")
                            .WithDescription("Lista de funcionários paginados")
                            .WithOrder(1)
                            .Produces<PagedResponse<List<EmployeeResponse>>>();

    private static async Task<IResult> HandleAsync(
        IEmployeeHandler handler,
        [FromQuery] string? searchString,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        var request = new PagedEmployeeRequest { PageNumber = pageNumber, PageSize = pageSize, SearchString = searchString };
        var result = await handler.GetAsync(request);

        return result.IsSuccess ?
                TypedResults.Ok(result)
                : TypedResults.Problem();
    }
}
