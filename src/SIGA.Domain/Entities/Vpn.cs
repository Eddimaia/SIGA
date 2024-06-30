using Financials.Domain.Entities.Common;

namespace SIGA.Domain.Entities;
public class Vpn : Entity
{
    public Vpn(int id, string name, string version, string? iconPath)
    {
        Id = id;
        Name = name;
        Version = version;
        IconPath = iconPath;
    }

    public string Name { get; set; } = null!;
    public string Version { get; set; } = null!;
    public string? IconPath { get; set; }


    public Client Client { get; set; } = new(default, string.Empty, default);
    public ICollection<VpnAccess> VpnAccesses { get; set; } = new List<VpnAccess>();
}
