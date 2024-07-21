using SIGA.Domain.Entities.Common;
using SIGA.Domain.Enums;
using SIGA.Domain.Interfaces;

namespace SIGA.Domain.Entities;
public class DatabaseAccess : Entity, IAccess
{
    public DatabaseAccess()
    {
        
    }
    public DatabaseAccess(int id, string login, string password, EDatabaseType dataBaseType)
    {
        Id = id;
        Login = login;
        Password = password;
        DataBaseTypeId = dataBaseType;
    }

    public new int Id { get; set; }
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int ClientId { get; set; }
    public EDatabaseType DataBaseTypeId { get; set; }



    public Client Client { get; set; } = new();
    public DatabaseType DatabaseType { get; set; } = new();


    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
