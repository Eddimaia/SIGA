using SIGA.Application.DTO.Common;
using SIGA.Application.DTO.Employee;
using SIGA.Application.Handles.Interfaces;
using System.Net.Http.Json;

namespace SIGA.IoC.Web.Handles;
public class EmployeeHandler(IHttpClientFactory httpClientFactory) : IEmployeeHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("siga");

    public async Task<Response<IEnumerable<EmployeeResponse>>> GetAllAsync()
    {
        var response = await _client.GetAsync($"/v1/employees");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<Response<IEnumerable<EmployeeResponse>>>();
            return content!;
        }

        return new Response<IEnumerable<EmployeeResponse>>(null, 400, "Ocorreu um erro na busca dos funcionários");
    }

    public async Task<PagedResponse<IEnumerable<EmployeeResponse>>> GetAsync(PagedEmployeeRequest request)
    {
        var response = await _client.GetAsync($"/v1/employees/paged?searchString={request.SearchString}&pageSize={request.PageSize}&pageNumber={request.PageNumber}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<PagedResponse<IEnumerable<EmployeeResponse>>>();
            return content!;
        }

        return new PagedResponse<IEnumerable<EmployeeResponse>>(null, 400, "Ocorreu um erro na busca dos funcionários");
    }
}
