using SIGA.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SIGA.Domain.DTOs;
public class RoleDTO : ModelBase
{
	[Required(ErrorMessage = "Nome é obrigatório")]
	public string Nome { get; set; }
}
