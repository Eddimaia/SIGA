using SIGA.Domain.DataAnnotations;
using SIGA.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SIGA.Domain.DTOs.Concessao;
public class ConcessaoDTO : ModelBase
{
	[Required(ErrorMessage = "{0} é obrigatório")]
	public string Nome { get; set; } = string.Empty;
	[Required(ErrorMessage = $"Nome Abreviado é obrigatório")]
	[Display(Name = "Nome Abreviado")]
	public string NomeAbreviado { get; set; } = string.Empty;
	[StringLength(2, MinimumLength = 2, ErrorMessage = "{0} fora do padrão")]
	[UF]
	public string UF { get; set; } = string.Empty;
}
