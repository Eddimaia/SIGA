namespace SIGA.Lib.Models;
public class VPN : ModelBase
{
    public string Nome { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
    public short Port { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public bool AcessoForaDoServidor { get; set; } = false;

    public ClientVPN ClientVPN { get; set; } = new();
    public Concessao Concessao { get; set; } = new();

    public List<Acesso> Acessos { get; set; } = new();
}
