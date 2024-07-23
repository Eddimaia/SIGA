using System.ComponentModel.DataAnnotations;

namespace SIGA.Application.DTO.Account;
public class LoginRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Login { get; set; } = null!;
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Password { get; set; } = null!;
}
