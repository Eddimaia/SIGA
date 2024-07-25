using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SIGA.Application.DTO.Account;

namespace SIGA.Web.Pages.Register;
///TODO: FINALIZAR REGISTRO
public class RegisterPage : ComponentBase
{
    public RegisterRequest InputModel { get; set; } = new();

    public async Task OnValidSubmitAsync()
    {
    }
}
