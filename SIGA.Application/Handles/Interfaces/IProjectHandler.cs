using SIGA.Application.DTO.Common;
using SIGA.Application.DTO.Projects;

namespace SIGA.Application.Handles.Interfaces;
public interface IProjectHandler
{
    Task<PagedResponse<List<ProjectResponse>>> GetAsync(PagedProjectRequest request);
    Task<Response<ProjectResponse?>> DeleteAsync(int id);
    Task<Response<ProjectResponse?>> CreateAsync(CreateProjectRequest request);
}
