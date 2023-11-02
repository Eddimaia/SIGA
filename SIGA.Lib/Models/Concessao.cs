namespace SIGA.Lib.Models;
public class Concessao : ModelBase
{
    public string Nome { get; set; } = string.Empty;
    public string UF { get; set; } = string.Empty;
    public Grupo Grupo { get; set; } = new();
    public List<VPN> VPNs { get; set; } = new();
}
