using Microsoft.EntityFrameworkCore;
using SIGA.Application.DTO.Common;
using SIGA.Application.DTO.Projects;
using SIGA.Application.Handles.Interfaces;
using SIGA.Infrastructure.Context;

namespace SIGA.IoC.Handles;
public class ProjectHandler(AppDbContext context) : IProjectHandler
{
    public async Task<PagedResponse<List<ProjectResponse>>> GetAsync(PagedRequest request)
    {
        try
        {
            var query = context.Projects
            .AsNoTracking()
            .OrderBy(x => x.Id);

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
