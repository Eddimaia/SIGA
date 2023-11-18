using SIGA.Domain.Enums;
using System.Text.Json.Serialization;

namespace SIGA.Domain.Entities;
public class TipoAcesso
{
	public ETipoAcesso Id { get; set; }
	public string Nome { get; set; } = string.Empty;

	[JsonIgnore]
	public ICollection<Acesso> Acessos { get; set; } = new List<Acesso>();
}
