using SIGA.Domain.Enums;
using System.Text.Json.Serialization;

namespace SIGA.Domain.Entities;
public class Equipe
{
    public EEquipe Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<Funcionario> Funcionarios { get; set; } = [];
}
