using System.Text.Json.Serialization;

namespace SIGA.Lib.Models;
public class Grupo : ModelBase
{
    public string Nome { get; set; } = string.Empty;
    public string UF { get; set; } = string.Empty;

	[JsonIgnore]
	public List<Concessao> Concessoes { get; set; } = new();
}
