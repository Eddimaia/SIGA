using System.Text.Json.Serialization;

namespace SIGA.Lib.Models;
public class Role : ModelBase
{
    public string Nome { get; set; } = string.Empty;

	[JsonIgnore]
	public List<Funcionario> Funcionarios { get; set; } = new();
}
