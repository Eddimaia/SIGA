using SIGA.Domain.Entities;
using System.Security.Claims;

namespace SIGA.Domain.Extensions;
public static class RoleClaimsExtension
{
    public static IEnumerable<Claim> GetClaims(this ApplicationUser usuario, IList<string> roles)
    {
        var result = new List<Claim>()
        {
            new(ClaimTypes.Name, usuario.UserName)
        };

        if ( roles.Count > 0 )
            result.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        return result;
    }
}
