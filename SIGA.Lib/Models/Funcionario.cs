﻿using System.Text.Json.Serialization;

namespace SIGA.Lib.Models;
public class Funcionario : ModelBase
{
    public string Login { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome {  get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    [JsonIgnore]
    public string PasswordHash { get; set; } = string.Empty;

	[JsonIgnore]
	public List<Projeto> Projetos { get; set; } = new();
	[JsonIgnore]
	public List<Acesso> Acessos { get; set; } = new();
	[JsonIgnore]
	public List<Role> Roles { get; set; } = new();
}