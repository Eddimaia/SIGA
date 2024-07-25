using Microsoft.AspNetCore.Components.Authorization;

namespace SIGA.Web.Security.Interfaces;

public interface ICustomAuthStateProvider
{
    Task<bool> CheckAuthenticatedAsync();
    Task<AuthenticationState> GetAuthenticationStateAsync();
    void NotifyAuthenticationStateChanged();
}
