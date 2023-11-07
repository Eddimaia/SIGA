using System.ComponentModel.DataAnnotations;

namespace SIGA.Lib.DTOs;
public class RoleDTO
{
	[Required(ErrorMessage = "Nome é obrigatório")]
	public string Nome { get; set; }
}
