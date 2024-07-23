using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SIGA.Application.Services.Interfaces;
using System.Security.Cryptography;

namespace SIGA.IoC.Services;
public class PasswordService : IPasswordService
{
    public Task<string> HashPassword(string password)
    {
        byte[] salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return Task.FromResult($"{Convert.ToBase64String(salt)}.{hashed}");
    }

    public Task<bool> VerifyPassword(string hashedPassword, string password)
    {
        var parts = hashedPassword.Split('.');
        if (parts.Length != 2)
        {
            return Task.FromResult(false);
        }

        var salt = Convert.FromBase64String(parts[0]);
        var storedHash = parts[1];

        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return Task.FromResult(storedHash == hashed);
    }
}
