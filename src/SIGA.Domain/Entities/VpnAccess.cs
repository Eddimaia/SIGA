using SIGA.Domain.Interfaces;

namespace SIGA.Domain.Entities;
public class VpnAccess : IAccess
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public string VpnName { get; set; } = null!;
    public string Password { get; set; } = null!;
}
