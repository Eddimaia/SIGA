using System.ComponentModel.DataAnnotations;

namespace SIGA.Lib.DTOs.Funcionario;
public class UpdateFuncionarioDTO
{
	[Required(ErrorMessage = "Id é obrigatório")]
	public int Id { get; set; }

	[Required(ErrorMessage = "Nome é obrigatório")]
	public string Nome { get; set; }

	[Required(ErrorMessage = "Sobrenome é obrigatório")]
	public string Sobrenome { get; set; }

	[Required(ErrorMessage = "E-mail é obrigatório")]
	[EmailAddress(ErrorMessage = "E-mail inválido")]
	public string Email { get; set; }
	
	public string? Password { get; set; }
}
