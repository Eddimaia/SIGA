using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SIGA.Domain.Extensions;
using SIGA.Domain.Entities;

namespace SIGA.API.Services;
public class TokenService
{
	public UsuarioToken GenerateToken(ApplicationUser usuario, IList<string> roles)
	{
		var tokenHandler = new JwtSecurityTokenHandler();

		var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
		var claims = usuario.GetClaims(roles);
		var expires = DateTime.UtcNow.AddHours(8);

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(claims),
			Expires = expires,
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
			Issuer = Configuration.Issuer,
			Audience = Configuration.Audience
		};
		var token = tokenHandler.CreateToken(tokenDescriptor);

		return new UsuarioToken
		{
			Token = tokenHandler.WriteToken(token),
			Expiration = expires,
		};
	}
}