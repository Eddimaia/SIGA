namespace SIGA.Domain.Entities.Relations;
public class VpnVpnAccess
{
    public int VpnId { get; set; }
    public int VpnAccessId { get; set; }


    public Vpn Vpn { get; set; } = new Vpn();
    public VpnAccess VpnAccess { get; set; } = new VpnAccess();
}
