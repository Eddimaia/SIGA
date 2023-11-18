using System.Text.Json.Serialization;

namespace SIGA.Domain.Entities;
public class Acesso : ModelBase
{
	public string Login { get; set; } = string.Empty;
	public string Senha { get; set; } = string.Empty;
	public bool Expiracao { get; set; } = false;
	public DateTime? DataExpiracao { get; set; }
	public bool Autenticacao { get; set; } = false;
	public bool AcessoSimultaneo { get; set; } = false;
	public byte QtdMaximaAcessoSimultaneo { get; set; } = 1;
	public bool BlAtivo { get; set; } = true;
	public bool AcessoForaDoServidor { get; set; } = false;


	[JsonIgnore]
	public TipoAcesso? TipoAcesso { get; set; }

	[JsonIgnore]
	public TipoAutenticacaoAcesso? TipoAutenticacaoAcesso { get; set; }

	[JsonIgnore]
	public VPN VPN { get; set; } = new();

	[JsonIgnore]
	public Projeto Projeto { get; set; } = new();

	[JsonIgnore]
	public List<Funcionario> Funcionarios { get; set; } = new();
}
