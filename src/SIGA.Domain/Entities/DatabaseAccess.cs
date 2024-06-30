using SIGA.Domain.Enums;
using SIGA.Domain.Interfaces;

namespace SIGA.Domain.Entities;
public class DatabaseAccess : IAccess
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public EDataBaseType dataBaseType { get; set; }


    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
