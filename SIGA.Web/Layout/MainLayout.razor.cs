using Microsoft.AspNetCore.Components;
using MudBlazor;
using SIGA.Web.Security.Interfaces;
using System.Security.Claims;

namespace SIGA.Web.Layout;

public class MainLayoutPage : LayoutComponentBase
{

    [Inject]
    public ICustomAuthStateProvider AuthenticationStateProvider { get; set; } = null!;

    protected MudThemeProvider _mudThemeProvider = null!;
    protected bool _drawerOpen = false;
    protected ClaimsPrincipal? _user;
    protected string? _registeredName;
    protected string? _login;
    protected bool _isDarkMode = true;
    protected string _themeIcon = null!;
    protected string _lightModeIcon = @Icons.Material.Filled.LightMode;
    protected string _darkModeIcon = @Icons.Material.Filled.DarkMode;

    protected void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        _user = authState.User;
        _registeredName = _user.FindFirst("RegisteredName")?.Value;
        _login = _user.Identity!.Name;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _isDarkMode = await _mudThemeProvider.GetSystemPreference();
            await _mudThemeProvider.WatchSystemPreference(OnSystemPreferenceChanged);
            _themeIcon = _isDarkMode ? _darkModeIcon : _lightModeIcon;
            StateHasChanged();
        }
    }

    protected Task OnSystemPreferenceChanged(bool newValue)
    {
        _isDarkMode = newValue;
        StateHasChanged();
        return Task.CompletedTask;
    }

    protected Task ChangeTheme()
    {
        _isDarkMode = !_isDarkMode;
        _themeIcon = _isDarkMode ? _darkModeIcon : _lightModeIcon;
        StateHasChanged();
        return Task.CompletedTask;
    }
}
