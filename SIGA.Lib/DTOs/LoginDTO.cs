using System.ComponentModel.DataAnnotations;

namespace SIGA.Lib.DTOs;
public class LoginDTO
{
	[Required(ErrorMessage = "Login é obrigatório")]
	[Display(Name = "Login")]
	public string Login { get; set; }

	[Required(ErrorMessage = "Senha é obrigatória")]
	[Display(Name = "Senha")]
	public string Password { get; set; }
}
