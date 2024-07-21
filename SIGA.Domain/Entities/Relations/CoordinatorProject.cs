using SIGA.Domain.Entities.Common;

namespace SIGA.Domain.Entities.Relations;
public class CoordinatorProject : Entity
{
    public int ApplicationUserId { get; set; }
    public int ProjectId { get; set; }

    public ApplicationUser ApplicationUser { get; set; } = new();
    public Project Project { get; set; } = new();
}
