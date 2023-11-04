namespace SIGA.Lib.Models;
public class Funcionario : ModelBase
{
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome {  get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    public List<Projeto> Projetos { get; set; } = new();
    public List<Acesso> Acessos { get; set; } = new();
    public List<Role> Roles { get; set; } = new();
}
