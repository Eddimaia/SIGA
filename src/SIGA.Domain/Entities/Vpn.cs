using SIGA.Domain.Entities.Common;

namespace SIGA.Domain.Entities;
public class Vpn : Entity
{

    public Vpn(string host, string name, string version, string? iconPath, string? domain)
    {
        Host = host;
        Name = name;
        Version = version;
        IconPath = iconPath;
        Domain = domain;
    }

    public string Host {  get; set; }= null!;
    public string Name { get; set; } = null!;
    public string Version { get; set; } = null!;
    public string? IconPath { get; set; }
    public string? Domain { get; set; }



    public Client Client { get; set; } = new(default, string.Empty, default);
    public ICollection<VpnAccess> VpnAccesses { get; set; } = new List<VpnAccess>();
}
