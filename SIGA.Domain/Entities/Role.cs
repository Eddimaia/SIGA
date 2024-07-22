using SIGA.Domain.Entities.Common;
using SIGA.Domain.Entities.Relations;

namespace SIGA.Domain.Entities;
public class Role : Entity
{
    public Role()
    {
        
    }
    public Role(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;



    public ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
    public ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();
}
