
using Microsoft.AspNetCore.Mvc;
using SIGA.Application.DTO.Accounts;
using SIGA.Application.DTO.Common;
using SIGA.Application.Handles.Interfaces;

namespace SIGA.API.Endpoints.Projects;

public class GetPagedProjectsEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
                        .RequireAuthorization(x => x.RequireRole("Admin"))
                        .WithName("Projects: Paged")
                        .WithSummary("Lista de projetos")
                        .WithDescription("Lista de projetos paginados")
                        .WithOrder(4)
                        .Produces<PagedResponse<IEnumerable<RegisterResponse>>>();

    private static async Task<IResult> HandleAsync(
        IProjectHandler handler, 
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        var request = new PagedRequest { PageNumber = pageNumber, PageSize = pageSize };
        var result = await handler.GetAsync(request);

        return result.IsSuccess ?
                TypedResults.Ok(result.Data)
                : TypedResults.Problem();
    }
}
