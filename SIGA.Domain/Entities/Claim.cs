using SIGA.Domain.Entities.Common;

namespace SIGA.Domain.Entities;
public class Claim : Entity
{
    public Claim()
    {
        
    }
    public Claim(string name, string description, ICollection<ApplicationUser> applicationUser)
    {
        Name = name;
        Description = description;
        ApplicationUser = applicationUser;
    }

    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;



    public ICollection<ApplicationUser> ApplicationUser { get; set; } = new List<ApplicationUser>();
}
