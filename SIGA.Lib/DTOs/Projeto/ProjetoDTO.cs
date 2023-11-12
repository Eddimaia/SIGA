using SIGA.Lib.Models;
using System.ComponentModel.DataAnnotations;

namespace SIGA.Lib.DTOs.Projeto;
public class ProjetoDTO : ModelBase
{
	[Required(ErrorMessage = "{0} é obrigatório")]
	public string Nome { get; set; } = string.Empty;

	[Required(ErrorMessage = "{0} é obrigatório")]
	public string Sigla { get; set; } = string.Empty;
}
