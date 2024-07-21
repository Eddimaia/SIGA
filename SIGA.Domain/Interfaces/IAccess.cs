namespace SIGA.Domain.Interfaces;
public interface IAccess
{
    int Id { get; protected set; }
    string Login { get; set; }
    string Password { get; set; }
}
