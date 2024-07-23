namespace SIGA.Application.Services.Interfaces;
public interface IPasswordService
{
    Task<string> HashPassword(string password);
    Task<bool> VerifyPassword(string hashedPassword, string password);
}
