using Microsoft.AspNetCore.Components;
using SIGA.Application.Handles.Interfaces;
using SIGA.Web.Security.Interfaces;

namespace SIGA.Web.Components.Menu;

public class NavMenuPage : ComponentBase
{
    [Parameter]
    public bool DrawerOpen { get; set; }
    [Parameter]
    public string? Login {  get; set; }

    [Inject]
    public ILogoutHandler Handler { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public ICustomAuthStateProvider AuthenticationStateProvider { get; set; } = null!;


    public async Task LogoutAsync()
    {

        if (await AuthenticationStateProvider.CheckAuthenticatedAsync())
        {
            await Handler.LogoutAsync();
            await AuthenticationStateProvider.GetAuthenticationStateAsync();
            AuthenticationStateProvider.NotifyAuthenticationStateChanged();
            NavigationManager.NavigateTo("/Login");
        }

    }
}
