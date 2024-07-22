using SIGA.Domain.Entities.Common;
using SIGA.Domain.Entities.Relations;

namespace SIGA.Domain.Entities;
public class Client : Entity
{
    public Client()
    {
        
    }
    public Client(int id, string name, string? acronym)
    {
        Id = id;
        Name = name;
        Acronym = acronym;
    }

    public string Name { get; set; } = null!;
    public string? Acronym { get; set; } = null!;



    public ICollection<Project> Projects { get; set; } = new List<Project>();
    public ICollection<DatabaseAccess> DatabaseAccesses { get; set; } = new List<DatabaseAccess>();
    public ICollection<Vpn> Vpns { get; set; } = new List<Vpn>();
    public ICollection<ClientProject> ClientProjects { get; set; } = new List<ClientProject>();
}
