using SIGA.Lib.Models;
using System.ComponentModel.DataAnnotations;

namespace SIGA.Lib.DTOs;
public class RoleDTO : ModelBase
{
	[Required(ErrorMessage = "Nome é obrigatório")]
	public string Nome { get; set; }
}
