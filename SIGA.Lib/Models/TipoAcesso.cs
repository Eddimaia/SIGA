using SIGA.Lib.Enums;
using System.Text.Json.Serialization;

namespace SIGA.Lib.Models;
public class TipoAcesso
{
    public ETipoAcesso Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<Acesso> Acessos { get; set; } = new List<Acesso>();
}
