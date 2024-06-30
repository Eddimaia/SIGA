using Financials.Domain.Entities;
using Financials.Domain.Entities.Common;

namespace SIGA.Domain.Entities;
public class Project : Entity
{
    public Project(int id, string name, string acronym)
    {
        Id = id;
        Name = name;
        Acronym = acronym;
    }

    public string Name { get; set; } = null!;
    public string Acronym { get; set; } = null!;



    public ICollection<ApplicationUser> ApplicationUser { get; set; } = new List<ApplicationUser>();
    public ICollection<Coordinator> Coordinators { get; set; } = new List<Coordinator>();
    public ICollection<Client> Clients { get; set; } = new List<Client>();
}
