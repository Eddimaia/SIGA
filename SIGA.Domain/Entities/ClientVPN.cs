using System.Text.Json.Serialization;

namespace SIGA.Domain.Entities;
public class ClientVPN : ModelBase
{
	public string Nome { get; set; } = string.Empty;
	public string LinkDownload { get; set; } = string.Empty;
	public string Versao { get; set; } = string.Empty;
	public string Observacao { get; set; } = string.Empty;
	public string DescricaoInstalacao { get; set; } = string.Empty;

	[JsonIgnore]
	public VPN VPN { get; set; } = new();

	[JsonIgnore]
	public List<AnexoInstalacao> AnexosInstalacao { get; set; } = new();
}