using SIGA.Application.DTO.Common;
using SIGA.Application.DTO.Projects;
using SIGA.Application.Handles.Interfaces;
using SIGA.IoC.Web.Services;
using System.Net.Http.Json;

namespace SIGA.IoC.Web.Handles;
public class ProjectHandler(IHttpClientFactory httpClientFactory) : IProjectHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("siga");

    public async Task<Response<ProjectResponse?>> DeleteAsync(int id)
    {
        var response = await _client.DeleteAsync($"/v1/projects/{id}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<Response<ProjectResponse?>>();
            return content!;
        }

        return new Response<ProjectResponse?>(null, 400, "Falha ao excluir o projeto");
    }

    public async Task<PagedResponse<List<ProjectResponse>>> GetAsync(PagedProjectRequest request)
    {
        var response = await _client.GetAsync($"/v1/projects?searchString={request.SearchString}&pageSize={request.PageSize}&pageNumber={request.PageNumber}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<PagedResponse<List<ProjectResponse>>>();
            return content!;
        }

        return new PagedResponse<List<ProjectResponse>>(null, 400, "Ocorreu um erro na busca dos projetos");
    }
}
