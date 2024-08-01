using SIGA.Domain.Entities.Common;
using SIGA.Domain.Entities.Relations;

namespace SIGA.Domain.Entities;
public class Project : Entity
{
    public Project()
    {
        
    }
    public Project(int id, string name, string acronym)
    {
        Id = id;
        Name = name;
        Acronym = acronym;
    }

    public string Name { get; set; } = null!;
    public string? Acronym { get; set; } = null!;
    public string ImagePath { get; set; } = null!;



    public ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
    public ICollection<ApplicationUser> Coordinators { get; set; } = new List<ApplicationUser>();
    public ICollection<Client> Clients { get; set; } = new List<Client>();
    public ICollection<DatabaseAccess> DatabaseAccesses { get; set; } = new List<DatabaseAccess>();

    public ICollection<ClientProject> ClientProjects { get; set; } = new List<ClientProject>();
    public ICollection<CoordinatorProject> CoordinatorProjects { get; set; } = new List<CoordinatorProject>();
    public ICollection<DatabaseAcessProject> DatabaseAccessProjects { get; set; } = new List<DatabaseAcessProject>();
    public ICollection<CoordinatorProject> CoordinatorsProjects { get; set; } = new List<CoordinatorProject>();
    public ICollection<DatabaseAcessProject> DatabaseAcessProjects { get; set; } = new List<DatabaseAcessProject>();
    public ICollection<ApplicationUserProject> UserProjects { get; set; } = new List<ApplicationUserProject>();
}
