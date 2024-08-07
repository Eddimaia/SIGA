using SIGA.Application.DTO.Common;

namespace SIGA.Application.DTO.Employee;
public class PagedEmployeeRequest : PagedRequest
{
    public string? SearchString { get; set; }
}
