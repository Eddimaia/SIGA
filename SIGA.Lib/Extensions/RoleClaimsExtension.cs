using SIGA.Lib.Models;
using System.Security.Claims;

namespace SIGA.Lib.Extensions;
public static class RoleClaimsExtension
{
	public static IEnumerable<Claim> GetClaims(this Funcionario funciorario)
	{
		var result = new List<Claim>()
		{
			new Claim(ClaimTypes.Name, funciorario.Email)
		};
		result.AddRange(funciorario.Roles.Select(role => new Claim(ClaimTypes.Role, role.Nome)));
		return result;
	}
}
