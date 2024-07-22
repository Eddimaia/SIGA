using SIGA.Domain.Entities.Common;
using SIGA.Domain.Interfaces;

namespace SIGA.Domain.Entities;
public class VpnAccess : Entity, IAccess
{
    public VpnAccess()
    {
        
    }
    public VpnAccess(int id, string login, string password)
    {
        Id = id;
        Login = login;
        Password = password;
    }

    public new int Id { get; set; }
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int ApplicationUserId { get; set; }
    public int VpnId { get; set; }


    public ApplicationUser ApplicationUser { get; set; } = new();
    public Vpn Vpn { get; set; } = new();
}
