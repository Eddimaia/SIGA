namespace SIGA.Lib.Models;
public class ClientVPN : ModelBase
{
    public string Nome { get; set; } = string.Empty;
    public string LinkDownload { get; set; } = string.Empty;
    public string Versao { get; set; } = string.Empty;
    public string Observacao { get; set; } = string.Empty;
    public string DescricaoInstalacao { get; set; } = string.Empty;

    public VPN VPN { get; set; } = new();

    public List<AnexoInstalacao> AnexosInstalacao { get; set; } = new();
}