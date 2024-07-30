using SIGA.Application.DTO;
using SIGA.Application.DTO.Account;
using SIGA.Application.Handles.Interfaces;
using SIGA.IoC.Web.Services;
using System.Net.Http.Json;
using System.Text;

namespace SIGA.IoC.Web.Handles;

public class AccountHandler(IHttpClientFactory httpClientFactory, SessionStorageService sessionStorageService) : IAccountHandler, ILogoutHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient("siga");

    public Task<Response<RegisterResponse?>> GetLoginInfo(string login)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<LoginResponse?>> LoginAsync(LoginRequest request)
    {
        var response = await _client.PostAsJsonAsync("/v1/accounts/Login", request);


        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<LoginResponse>();

            await sessionStorageService.SetItemAsync("jwtToken", content!.Token);
            await sessionStorageService.SetItemAsync("refreshToken", content!.RefreshToken);
            await sessionStorageService.SetItemAsync("Login", request.Login);

            return new Response<LoginResponse?>(content, 200, "Login realizado com sucesso!");
        }

        return new Response<LoginResponse?>(null, 401, "Não foi possível realizar o login");
    }

    public async Task LogoutAsync()
    {
        var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");
        var response = await _client.PostAsJsonAsync("/v1/accounts/Logout", emptyContent);

        await sessionStorageService.ClearAsync();
    }

    public async Task<Response<LoginResponse?>> RefreshTokenAsync(RefreshTokenRequest request)
    {
        var response = await _client.PostAsJsonAsync("/v1/accounts/RefreshToken", request);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return new Response<LoginResponse?>(content, 200, "Tokens atualizados com sucesso!");
        }

        return new Response<LoginResponse?>(null, 401, "Não foi possível realizar a atualização dos tokens");
    }

    public async Task<Response<RegisterResponse?>> RegisterAsync(RegisterRequest request)
    {
        var response = await _client.PostAsJsonAsync("/v1/accounts/Register", request);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<RegisterResponse>();
            return new Response<RegisterResponse?>(content, 200, "Cadastro realizado com sucesso!");
        }

        return new Response<RegisterResponse?>(null, 401, "Não foi possível realizar o cadastro");
    }
}
