using SIGA.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SIGA.Domain.DTOs.Funcionario;
public class FuncionarioDTO : ModelBase
{
	[Required(ErrorMessage = "{0} é Obrigatório")]
	public string Login { get; set; } = string.Empty;

	[Required(ErrorMessage = "{0} é Obrigatório")]
	public string Nome { get; set; } = string.Empty;

	[Required(ErrorMessage = "{0} é Obrigatório")]
	public string Sobrenome { get; set; } = string.Empty;

	[Required(ErrorMessage = "E-mail é Obrigatório")]
	[EmailAddress(ErrorMessage = "E-mail inválido")]
	[Display(Name = "E-mail")]
	public string Email { get; set; } = string.Empty;
	public string Token { get; set; } = string.Empty;

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public List<Entities.Projeto>? Projetos { get; set; } = default;
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public List<Acesso>? Acessos { get; set; } = default;
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public List<Role>? Roles { get; set; } = default;
}
