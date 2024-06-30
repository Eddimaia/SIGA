namespace SIGA.Domain.Interfaces;
public interface IAccess
{
    int Id { get; set; }
    string Login { get; set; }
    string Password { get; set; }
}
