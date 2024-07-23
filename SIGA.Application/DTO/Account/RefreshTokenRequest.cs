using System.ComponentModel.DataAnnotations;

namespace SIGA.Application.DTO.Account;
public class RefreshTokenRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Login { get; set; } = null!;
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string RefreshToken { get; set; } = null!;
}
