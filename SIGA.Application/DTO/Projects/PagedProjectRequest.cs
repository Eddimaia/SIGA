using SIGA.Application.DTO.Common;

namespace SIGA.Application.DTO.Projects;
public class PagedProjectRequest : PagedRequest
{
    public string? SearchString {  get; set; }
}
