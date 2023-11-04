namespace SIGA.Lib.Models;
public class Projeto : ModelBase
{
	public string Nome { get; set; } = string.Empty;
	public string Sigla { get; set; } = string.Empty;

	public List<Acesso> Acessos { get; set; } = new();
	public List<Concessao> Concessoes { get; set; } = new();
	public List<Funcionario> Funcionarios { get; set; } = new();
}
