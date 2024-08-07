
using SIGA.Application.DTO.Common;
using SIGA.Application.DTO.Projects;
using SIGA.Application.Handles.Interfaces;

namespace SIGA.API.Endpoints.Projects;

public class CreateProjectEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
                //.RequireAuthorization("AdminCreate")
                .WithName("Projects: Create")
                .WithSummary("Cria um projeto")
                .WithDescription("Cria um projeto")
                .WithOrder(3)
                .Produces<Response<ProjectResponse?>>();

    private static async Task<IResult> HandleAsync(CreateProjectRequest request, IProjectHandler handler)
    {

        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}
