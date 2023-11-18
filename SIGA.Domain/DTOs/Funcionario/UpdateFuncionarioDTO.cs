using System.ComponentModel.DataAnnotations;

namespace SIGA.Domain.DTOs.Funcionario;
public class UpdateFuncionarioDTO
{
	[Required(ErrorMessage = "{0} é obrigatório")]
	public int Id { get; set; }

	[Required(ErrorMessage = "{0} é obrigatório")]
	public string Nome { get; set; }

	[Required(ErrorMessage = "{0} é obrigatório")]
	public string Sobrenome { get; set; }

	[Required(ErrorMessage = "E-mail é obrigatório")]
	[EmailAddress(ErrorMessage = "E-mail inválido")]
	[Display(Name = "E-mail")]
	public string Email { get; set; }

	[Display(Name = "Nova Senha")]
	public string? Password { get; set; }

    [Display(Name = "Última Senha")]
    public string? OldPassword { get; set; }
}
