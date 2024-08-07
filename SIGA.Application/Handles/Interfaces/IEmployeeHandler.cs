using SIGA.Application.DTO.Common;
using SIGA.Application.DTO.Employee;

namespace SIGA.Application.Handles.Interfaces;
public interface IEmployeeHandler
{
    Task<PagedResponse<IEnumerable<EmployeeResponse>>> GetAsync(PagedEmployeeRequest request);
    Task<Response<IEnumerable<EmployeeResponse>>> GetAllAsync();
}
