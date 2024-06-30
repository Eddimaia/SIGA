using Financials.Domain.Entities.Common;

namespace SIGA.Domain.Entities;
public class Coordinator : Entity
{
    public int ApplicationUserId { get; set; }



    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
