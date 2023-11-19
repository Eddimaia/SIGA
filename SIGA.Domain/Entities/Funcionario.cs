using Microsoft.AspNetCore.Identity;
using SIGA.Domain.Enums;
using System.Text.Json.Serialization;

namespace SIGA.Domain.Entities;
public class Funcionario : ModelBase
{
	public string Nome { get; set; } = string.Empty;
	public string Sobrenome { get; set; } = string.Empty;

	[JsonIgnore]
	public Equipe Equipe { get; set; } = new();

	[JsonIgnore]
	public ApplicationUser Usuario { get; set; } = new();

	[JsonIgnore]
	public List<Projeto> Projetos { get; set; } = [];
	[JsonIgnore]
	public List<Acesso> Acessos { get; set; } = [];
}
