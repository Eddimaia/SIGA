using System.Security.Claims;

namespace SIGA.Web.Services.Interfaces;
public interface IJwtService
{
    bool IsTokenExpired(string token);
    string? GetClaimFromToken(string token, string claimType);
    List<Claim> GetUserInfoFromJwt(string token);
}
