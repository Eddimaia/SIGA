namespace SIGA.Lib.Models;
public class Role : ModelBase
{
    public string Nome { get; set; } = string.Empty;

    public List<Funcionario> Funcionarios { get; set; } = new();
}
