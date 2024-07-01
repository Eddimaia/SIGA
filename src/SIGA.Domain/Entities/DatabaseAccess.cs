using SIGA.Domain.Entities.Common;
using SIGA.Domain.Enums;
using SIGA.Domain.Interfaces;

namespace SIGA.Domain.Entities;
public class DatabaseAccess : Entity, IAccess
{
    public DatabaseAccess(int id, string login, string password, EDataBaseType dataBaseType)
    {
        Id = id;
        Login = login;
        Password = password;
        DataBaseType = dataBaseType;
    }

    public new int Id { get; set; }
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public EDataBaseType DataBaseType { get; set; }



    public Client Client { get; set; } = new(default, string.Empty, default);
    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
