using Blazored.LocalStorage;
using SIGA.Application.DTO;
using SIGA.Application.DTO.Account;
using SIGA.Application.Handles.Interfaces;
using System.Net.Http.Json;
using System.Text;

namespace SIGA.IoC.Web.Handles;

public class AccountHandler(IHttpClientFactory httpClientFactory, ILocalStorageService localStorage) : IAccountHandler, ILogoutHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("siga");

    public async Task<Response<LoginResponse?>> LoginAsync(LoginRequest request)
    {
        var response = await _client.PostAsJsonAsync("/v1/accounts/Login", request);


        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<LoginResponse>();

            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", content!.Token);
            await localStorage.SetItemAsync("jwtToken", content!.Token);

            return new Response<LoginResponse?>(content, 200, "Login realizado com sucesso!");
        }

        return new Response<LoginResponse?>(null, 401, "Não foi possível realizar o login");
    }

    public async Task LogoutAsync()
    {
        var token = await localStorage.GetItemAsync<string>("jwtToken");
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");
        var response = await _client.PostAsJsonAsync("/v1/accounts/Logout", emptyContent);
        Console.WriteLine(response.ToString());
    }

    public Task<Response<LoginResponse?>> RefreshTokenAsync(RefreshTokenRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<RegisterResponse?>> RegisterAsync(RegisterRequest request)
    {
        var token = await localStorage.GetItemAsync<string>("jwtToken");
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        var response = await _client.PostAsJsonAsync("/v1/accounts/Register", request);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<RegisterResponse>();
            return new Response<RegisterResponse?>(content, 200, "Cadastro realizado com sucesso!");
        }

        return new Response<RegisterResponse?>(null, 401, "Não foi possível realizar o cadastro");
    }
}
