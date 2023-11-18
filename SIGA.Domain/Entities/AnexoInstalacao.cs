using System.Text.Json.Serialization;

namespace SIGA.Domain.Entities;
public class AnexoInstalacao : ModelBase
{
	public string Caminho { get; set; } = string.Empty;
	public string Nome { get; set; } = string.Empty;

	[JsonIgnore]
	public ClientVPN ClientVPN { get; set; } = new();
}
