using SIGA.Lib.Models;

namespace SIGA.Lib.DTOs.Funcionario;
public class FuncionarioDTO : ModelBase
{
	public string Login { get; set; } = string.Empty;
	public string Nome { get; set; } = string.Empty;
	public string Sobrenome { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Token { get; set; } = string.Empty;

	public List<Projeto> Projetos { get; set; } = new();
	public List<Acesso> Acessos { get; set; } = new();
	public List<Role> Roles { get; set; } = new();
}
