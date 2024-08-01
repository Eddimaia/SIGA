namespace SIGA.Application.DTO.Accounts;
public class AccountInfoResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
}
