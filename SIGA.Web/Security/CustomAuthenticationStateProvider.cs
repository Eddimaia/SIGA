using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using SIGA.Web.Security.Interfaces;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;

namespace SIGA.Web.Security;

public class CustomAuthenticationStateProvider(IHttpClientFactory clientFactory) : AuthenticationStateProvider, ICustomAuthStateProvider
{
    private bool _isAuthenticated = false;
    private readonly HttpClient _client = clientFactory.CreateClient("siga");
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        _isAuthenticated = false;
        var user = new ClaimsPrincipal(new ClaimsIdentity());
        string? token;
        try
        {


             token = await _client.GetFromJsonAsync<string?>("/v1/accounts/Info") ?? null;

        }
        catch (Exception ex)
        {
             token = null;
        }

        var identity = new ClaimsIdentity();

        if (!string.IsNullOrEmpty(token))
        {
            identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
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

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var claims = new List<Claim>();
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
        return claims;
    }

    private byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}
