namespace SIGA.Lib.Models;
public class VPN : ModelBase
{
    public string Nome { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public bool AcessoForaDoServidor { get; set; } = false;
    public List<ClientVPN> ClientVPN { get; set; } = new();
}
