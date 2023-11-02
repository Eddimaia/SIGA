namespace SIGA.Lib.Models;
public class Role : ModelBase
{
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public List<Funcionario> Funcionarios { get; set; } = new();
}
