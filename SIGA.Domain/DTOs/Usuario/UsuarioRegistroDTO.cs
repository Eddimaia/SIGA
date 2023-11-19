using System.ComponentModel.DataAnnotations;

namespace SIGA.Domain.DTOs.Usuario;
public class UsuarioRegistroDTO
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Sobrenome é obrigatório")]
    public string Sobrenome { get; set; }

    [Required(ErrorMessage = "E-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Senha é obrigatória")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Login é obrigatório")]
    [StringLength(10, MinimumLength = 5, ErrorMessage = "Login deve conter entre 5 e 10 caracteres")]
    public string Login { get; set; }
}
