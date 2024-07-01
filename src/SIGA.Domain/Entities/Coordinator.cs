using SIGA.Domain.Entities.Common;

namespace SIGA.Domain.Entities;
public class Coordinator : Entity
{
    public Coordinator(int id, int applicationUserId)
    {
        Id = id;
        ApplicationUserId = applicationUserId;
    }

    public int ApplicationUserId { get; set; }



    public ApplicationUser ApplicationUser { get; set; } = new(
        default, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, default, default, default, default, default, default, default, default);
    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
