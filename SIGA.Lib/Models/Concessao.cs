using System.Text.Json.Serialization;

namespace SIGA.Lib.Models;
public class Concessao : ModelBase
{
    public string Nome { get; set; } = string.Empty;
    public string NomeAbreviado {  get; set; } = string.Empty;
    public string UF { get; set; } = string.Empty;

	[JsonIgnore]
	public Grupo Grupo { get; set; } = new();

	[JsonIgnore]
	public List<VPN> VPNs { get; set; } = new();
	[JsonIgnore]
	public List<Projeto> Projetos { get; set; } = new();
}
