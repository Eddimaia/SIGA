﻿using SIGA.Domain.Enums;
using System.Text.Json.Serialization;

namespace SIGA.Domain.Entities;
public class TipoAutenticacaoAcesso
{
	public ETipoAutenticacaoAcesso Id { get; set; }
	public string NomeAppAutenticacao { get; set; } = string.Empty;

	[JsonIgnore]
	public ICollection<Acesso> Acessos { get; set; } = new List<Acesso>();
}
