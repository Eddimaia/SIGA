using SIGA.Domain.Entities.Common;
using SIGA.Domain.Interfaces;

namespace SIGA.Domain.Entities;
public class VpnAccess : Entity, IAccess
{
    public VpnAccess()
    {
        
    }
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
    public int ClientId { get; set; }
    public int ApplicationUserId { get; set; }


    public Client Client { get; set; } = new();
    public ApplicationUser ApplicationUser { get; set; } = new();
}
