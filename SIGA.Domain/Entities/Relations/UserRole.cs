using SIGA.Domain.Entities.Common;

namespace SIGA.Domain.Entities.Relations;
public class UserRole : Entity
{
    public int ApplicationUserId { get; set; }
    public int RoleId { get; set; }



    public ApplicationUser ApplicationUser { get; set; } = new();
    public Role Role { get; set; } = new();
}
