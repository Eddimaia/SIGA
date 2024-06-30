using Financials.Domain.Entities.Common;

namespace Financials.Domain.Entities;
public class Role : Entity
{
    public Role(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;



    public ICollection<ApplicationUser> ApplicationUser { get; set; } = new List<ApplicationUser>();
}
