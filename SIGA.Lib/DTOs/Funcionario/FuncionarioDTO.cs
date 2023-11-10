using SIGA.Lib.Models;
using System.Text.Json.Serialization;

namespace SIGA.Lib.DTOs.Funcionario;
public class FuncionarioDTO : ModelBase
{
	public string Login { get; set; } = string.Empty;
	public string Nome { get; set; } = string.Empty;
	public string Sobrenome { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Token { get; set; } = string.Empty;

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public List<Projeto>? Projetos { get; set; } = default;
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public List<Acesso>? Acessos { get; set; } = default;
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public List<Role>? Roles { get; set; } = default;
}
