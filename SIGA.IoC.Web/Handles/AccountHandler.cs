using SIGA.Application.DTO;
using SIGA.Application.DTO.Account;
using SIGA.Application.Handles.Interfaces;
using System.Net.Http.Json;
using System.Text;

namespace SIGA.IoC.Web.Handles;

public class AccountHandler(IHttpClientFactory httpClientFactory) : IAccountHandler, ILogoutHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("siga");
    public async Task<Response<LoginResponse?>> LoginAsync(LoginRequest request)
    {
        var response = await _client.PostAsJsonAsync("/v1/accounts/Login", request);
        _client.DefaultRequestHeaders.Add("Access-Control-Allow-Credentials", "true");


        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<LoginResponse>();

            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", content.Token);
            return new Response<LoginResponse?>(content, 200, "Login realizado com sucesso!");
        }

        return new Response<LoginResponse?>(null, 400, "Não foi possível realizar o login");
    }

    public async Task LogoutAsync()
    {
        var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");
        var response = await _client.PostAsJsonAsync("/v1/accounts/Logout", emptyContent);
        Console.WriteLine(response.ToString());
    }

    public Task<Response<LoginResponse?>> RefreshTokenAsync(RefreshTokenRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Response<RegisterResponse?>> RegisterAsync(RegisterRequest request)
    {
        throw new NotImplementedException();
    }
}
