using Microsoft.AspNetCore.Components;
using MudBlazor;
using SIGA.Application.DTO.Accounts;
using SIGA.Application.Handles.Interfaces;
using SIGA.Web.Security.Interfaces;

namespace SIGA.Web.Pages.Register;
///TODO: FINALIZAR REGISTRO
public class RegisterPage : ComponentBase
{
    public RegisterRequest InputModel { get; set; } = new();
    private bool isShow;
    public InputType PasswordInput = InputType.Password;
    public string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
    public bool IsBusy { get; set; } = false;


    [Inject]
    public IAccountHandler Handler { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public ICustomAuthStateProvider AuthenticationStateProvider { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;


    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await Handler.RegisterAsync(InputModel);

            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo("/");
            }
            else
                Snackbar.Add(result.Message, Severity.Error);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    public void ShowHidePassword()
    {
        if(isShow)
        {
            isShow = false;
            PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
            PasswordInput = InputType.Password;
        }
        else
        {
            isShow = true;
            PasswordInputIcon = Icons.Material.Filled.Visibility;
            PasswordInput = InputType.Text;
        }
    }
}
