using System.Text.Json.Serialization;

namespace SIGA.Domain.Entities;
public class Squad : ModelBase
{
	public string Nome { get; set; } = string.Empty;

	[JsonIgnore]
	public List<Funcionario> Funcionarios { get; set; } = new();
}
