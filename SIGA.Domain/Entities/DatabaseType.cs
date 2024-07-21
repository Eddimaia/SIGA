using SIGA.Domain.Enums;

namespace SIGA.Domain.Entities;
public class DatabaseType
{
    public DatabaseType()
    {
        
    }
    public DatabaseType(EDatabaseType id, string name)
    {
        Id = id;
        Name = name;
    }

    public EDatabaseType Id { get; set; }
    public string Name { get; set; } = null!;



    public ICollection<DatabaseAccess> DatabaseAccess { get; set; } = new List<DatabaseAccess>();
}
