using SIGA.Domain.Entities.Common;
using SIGA.Domain.Entities.Relations;

namespace SIGA.Domain.Entities;
public class Claim : Entity
{
    public Claim()
    {
        
    }
    public Claim(int id, string name, string description, ICollection<ApplicationUser> applicationUser)
    {
        Id = id;
        Name = name;
        Description = description;
        ApplicationUsers = applicationUser;
    }

    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;



    public ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
    public ICollection<ApplicationUserClaim> UserClaims { get; set; } = new List<ApplicationUserClaim>();
}
