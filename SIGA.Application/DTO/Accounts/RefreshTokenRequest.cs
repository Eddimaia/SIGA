using System.ComponentModel.DataAnnotations;

namespace SIGA.Application.DTO.Accounts;
public class RefreshTokenRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MaxLength(20, ErrorMessage = "O campo {0} só suporta até 20 caracteres")]
    public string Login { get; set; } = null!;
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string RefreshToken { get; set; } = null!;
}
