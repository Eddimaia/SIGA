using Microsoft.AspNetCore.Components;
using SIGA.Application.DTO.Account;
using SIGA.Application.Handles.Interfaces;
using SIGA.Web.Security.Interfaces;

namespace SIGA.Web.Pages.Login;

public class LoginPage : ComponentBase
{
    public bool IsBusy { get; set; } = false;
    public LoginRequest InputModel { get; set; } = new();

    [Inject]
    public IAccountHandler Handler { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public ICustomAuthStateProvider AuthenticationStateProvider { get; set; } = null!;


    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity is { IsAuthenticated: true })
            NavigationManager.NavigateTo("/");
    }

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await Handler.LoginAsync(InputModel);

            if (result.IsSuccess)
            {
                await AuthenticationStateProvider.GetAuthenticationStateAsync();
                AuthenticationStateProvider.NotifyAuthenticationStateChanged();
                NavigationManager.NavigateTo("/");
            }
        }
        catch (Exception ex)
        {
            
        }
        finally
        {
            IsBusy = false;
        }
    }
}
