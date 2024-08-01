using SIGA.Application.DTO.Common;
using SIGA.Application.DTO.Projects;

namespace SIGA.Application.Handles.Interfaces;
public interface IProjectHandler
{
    Task<PagedResponse<List<ProjectResponse>>> GetAsync(PagedRequest request);
}
