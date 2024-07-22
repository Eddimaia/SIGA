using SIGA.Domain.Entities.Common;

namespace SIGA.Domain.Entities.Relations;
public class DatabaseAcessProject : Entity
{
    public int DatabaseAccessId { get; set; }
    public int ProjectId { get; set; }


    public DatabaseAccess DatabaseAccess { get; set; } = new DatabaseAccess();
    public Project Project { get; set; } = new Project();
}
