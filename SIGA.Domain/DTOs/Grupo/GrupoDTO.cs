using SIGA.Domain.DataAnnotations;
using SIGA.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SIGA.Domain.DTOs.Grupo;
public class GrupoDTO : ModelBase
{
	[Required(ErrorMessage = "Nome é obrigatório")]
	public string Nome { get; set; } = string.Empty;
	[Required(ErrorMessage = "UF é obrigatório")]
	[StringLength(2, MinimumLength = 2, ErrorMessage = "UF fora do padrão")]
	[UF]
	public string UF { get; set; } = string.Empty;
}
