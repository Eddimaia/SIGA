using SIGA.Application.Configuration.API;
using SIGA.Web.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SIGA.Web.Services;

public class JwtService : IJwtService
{
    public bool IsTokenExpired(string token)
    {
        ArgumentException.ThrowIfNullOrEmpty(token, nameof(token));

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadToken(token) as JwtSecurityToken ?? throw new ArgumentException("Token inválido.", nameof(token));

        var expirationDate = jwtToken.ValidTo;

        return expirationDate < DateTime.UtcNow;
    }

    public string GetClaimFromToken(string token, string claimType)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

        ArgumentException.ThrowIfNullOrEmpty(token, nameof(token));

        var claim = jwtToken!.Claims.FirstOrDefault(c => c.Type == claimType);

        return claim!.Value;
    }

    public List<Claim> GetUserInfoFromJwt(string token)
    {
        var claims = new List<Claim>();

        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            var tokenRead = tokenHandler.ReadJwtToken(token);

            var payload = tokenRead.Payload;

            claims.AddRange(payload.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            if (payload.TryGetValue(ClaimTypes.NameIdentifier, out var id))
            {
                claims.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));
            }
            if (payload.TryGetValue(ClaimTypes.Name, out var name))
            {
                claims.Add(new Claim(ClaimTypes.Name, name.ToString()));
            }
            if (payload.TryGetValue(ClaimTypes.Email, out var email))
            {
                claims.Add(new Claim(ClaimTypes.Email, email.ToString()));
            }
            if (payload.TryGetValue(ClaimTypes.MobilePhone, out var phoneNumber))
            {
                claims.Add(new Claim(ClaimTypes.MobilePhone, phoneNumber.ToString()));
            }
            if (payload.TryGetValue("RegisteredName", out var registeredName))
            {
                claims.Add(new Claim("RegisteredName", registeredName.ToString()));
            }
        }
        catch (Exception ex)
        {
            // Adicione o tratamento de exceções conforme necessário
            Console.WriteLine($"Error parsing JWT: {ex.Message}");
        }

        return claims;
    }
}
