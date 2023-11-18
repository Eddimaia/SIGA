using SIGA.Domain.Entities;
using System.Security.Claims;

namespace SIGA.Domain.Extensions;
public static class RoleClaimsExtension
{
	public static IEnumerable<Claim> GetClaims(this Usuario funciorario)
	{
		var result = new List<Claim>()
		{
			new(ClaimTypes.Name, funciorario.Email)
		};



		//result.AddRange(funciorario.Squads.Select(role => new Claim(ClaimTypes.Role, role.Nome)));
		return result;
	}
}
