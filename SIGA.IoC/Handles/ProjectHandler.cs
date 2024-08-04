using Microsoft.EntityFrameworkCore;
using SIGA.Application.DTO.Common;
using SIGA.Application.DTO.Projects;
using SIGA.Application.Handles.Interfaces;
using SIGA.Infrastructure.Context;

namespace SIGA.IoC.Handles;
public class ProjectHandler(AppDbContext context) : IProjectHandler
{
    public async Task<Response<ProjectResponse?>> DeleteAsync(int id)
    {
        try
        {
            var project = await context
            .Projects
            .FindAsync(id);

            if (project is null)
                return new Response<ProjectResponse?>(null, 404, "Projeto não encontrado");

            context.Projects.Remove(project);
            await context.SaveChangesAsync();

            return new Response<ProjectResponse?>(ProjectResponse.ProjectToProjectResponse(project), message: "Categoria excluída com sucesso!");
        }
        catch
        {
            return new Response<ProjectResponse?>(null, 500, "Não foi possível excluir o projeto");
        }
    }

    public async Task<PagedResponse<List<ProjectResponse>>> GetAsync(PagedProjectRequest request)
    {
        try
        {
            var query = context.Projects
            .AsNoTracking()
            .Where(item => string.IsNullOrWhiteSpace(request.SearchString)
            || item.Name.Contains(request.SearchString)
            || item.Acronym.Contains(request.SearchString)
            ).OrderBy(x => x.Id);

            var result = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<ProjectResponse>>(
                   result
                   .Select(ProjectResponse.ProjectToProjectResponse)
                   .ToList(),
                   count,
                   request.PageNumber,
                   request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<ProjectResponse>>(null, 500, "Não foi possível consultar os projetos");
        }
    }
}
