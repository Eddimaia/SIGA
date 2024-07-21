using SIGA.Domain.Entities.Common;

namespace SIGA.Domain.Entities.Relations;
public class UserProject : Entity
{
    public int ApplicationUserId { get; set; }
    public int ProjectId { get; set; }


    public ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();
    public Project Project { get; set; } = new Project();
}
