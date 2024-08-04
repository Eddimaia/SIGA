
using SIGA.Application.DTO.Common;
using SIGA.Application.DTO.Projects;
using SIGA.Application.Handles.Interfaces;

namespace SIGA.API.Endpoints.Projects;

public class DeleteProjectEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .RequireAuthorization()
            .WithName("Projects: Delete")
            .WithSummary("Exclui um projeto")
            .WithDescription("Exclui um projeto")
            .WithOrder(2)
            .Produces<Response<ProjectResponse?>>();

    private static async Task<IResult> HandleAsync(int id, IProjectHandler handler)
    {

        var result = await handler.DeleteAsync(id);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
