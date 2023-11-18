using System.Text.Json.Serialization;

namespace SIGA.Domain.Entities;
public class Projeto : ModelBase
{
	public string Nome { get; set; } = string.Empty;
	public string Sigla { get; set; } = string.Empty;

	[JsonIgnore]
	public List<Acesso> Acessos { get; set; } = new();
	[JsonIgnore]
	public List<Concessao> Concessoes { get; set; } = new();
	[JsonIgnore]
	public List<Funcionario> Funcionarios { get; set; } = new();
}
