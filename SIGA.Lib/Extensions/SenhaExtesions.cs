using SecureIdentity.Password;

namespace SIGA.Lib.Extensions;
public static class SenhaExtesions
{
    public static string GetPasswordHash(this string password) => PasswordHasher.Hash(password);
}
