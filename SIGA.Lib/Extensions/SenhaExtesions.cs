using SecureIdentity.Password;

namespace SIGA.Domain.Extensions;
public static class SenhaExtesions
{
    public static string GetPasswordHash(this string password) => PasswordHasher.Hash(password);
}
