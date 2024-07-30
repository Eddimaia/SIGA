using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using SIGA.Application.DTO.Account;
using SIGA.IoC.Web.Services;
using SIGA.Web.Security.Interfaces;
using SIGA.Web.Services.Interfaces;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;

namespace SIGA.Web.Security;

public class CustomAuthenticationStateProvider(IHttpClientFactory clientFactory, SessionStorageService sessionStorageService, IJwtService jwtService) : AuthenticationStateProvider, ICustomAuthStateProvider
{
    private bool _isAuthenticated = false;
    private readonly HttpClient _client = clientFactory.CreateClient("siga");
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        _isAuthenticated = false;
        var user = new ClaimsPrincipal(new ClaimsIdentity());
        List<Claim> claims;
        try
        {
            var token = await sessionStorageService.GetItemAsync("jwtToken");
            claims = jwtService.GetUserInfoFromJwt(token);
        }
        catch (Exception ex)
        {
            claims = [];
        }

        var identity = new ClaimsIdentity();

        if (claims.Count > 0)
        {
            identity = new ClaimsIdentity(claims, "jwt");
        }
        else
            return new AuthenticationState(user);


        user = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(user);

        _isAuthenticated = true;
        NotifyAuthenticationStateChanged(Task.FromResult(state));
        return state;
    }

    public async Task<bool> CheckAuthenticatedAsync()
    {
        await GetAuthenticationStateAsync();
        return _isAuthenticated;
    }

    public void NotifyAuthenticationStateChanged()
        => NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
}
