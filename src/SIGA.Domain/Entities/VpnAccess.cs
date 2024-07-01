using SIGA.Domain.Entities.Common;
using SIGA.Domain.Interfaces;

namespace SIGA.Domain.Entities;
public class VpnAccess : Entity, IAccess
{
    public VpnAccess(int id, string login, string vpnName, string password)
    {
        Id = id;
        Login = login;
        VpnName = vpnName;
        Password = password;
    }

    public new int Id { get; set; }
    public string Login { get; set; } = null!;
    public string VpnName { get; set; } = null!;
    public string Password { get; set; } = null!;



    public Client Client { get; set; } = new(default, string.Empty, default);
    public ApplicationUser ApplicationUser { get; set; } = new(
        default, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, default, default, default, default, default, default, default, default);
}
