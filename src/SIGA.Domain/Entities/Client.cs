using Financials.Domain.Entities.Common;

namespace SIGA.Domain.Entities;
public class Client : Entity
{
    public string Name { get; set; } = null!;
    public string? Acronym { get; set; } = null!;



    public ICollection<Project> Projects { get; set; } = new List<Project>();
    public ICollection<VpnAccess> VpnAccesses { get; set; } = new List<VpnAccess>();
    public ICollection<DatabaseAccess> DatabaseAccesses { get; set; } = new List<DatabaseAccess>();
}
