using SIGA.Lib.Enums;
using System.Text.Json.Serialization;

namespace SIGA.Lib.Models;
public class VPN : ModelBase
{
    public string Nome { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
    public short Port { get; set; }
    public string Descricao { get; set; } = string.Empty;

	[JsonIgnore]
	public EmpresaVPN EmpresaVPN { get; set; } = new();

	[JsonIgnore]
	public ClientVPN ClientVPN { get; set; } = new();
	[JsonIgnore]
	public Concessao Concessao { get; set; } = new();

	[JsonIgnore]
	public List<Acesso> Acessos { get; set; } = new();
}
