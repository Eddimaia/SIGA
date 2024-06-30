using Financials.Domain.Entities.Common;

namespace Financials.Domain.Entities;
public class Role : Entity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;



    public ICollection<ApplicationUser> ApplicationUser { get; set; } = new List<ApplicationUser>();
}
