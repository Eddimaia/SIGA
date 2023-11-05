using Microsoft.IdentityModel.Tokens;
using SIGA.Lib.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SIGA.Lib.Extensions;

namespace SIGA.API.Services;
public class TokenService
{
	public string GenerateToken(Funcionario funcionario)
	{
		var tokenHandler = new JwtSecurityTokenHandler();

		var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
		var claims = funcionario.GetClaims();

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(claims),
			Expires = DateTime.UtcNow.AddHours(8),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
		};
		var token = tokenHandler.CreateToken(tokenDescriptor);

		return tokenHandler.WriteToken(token);
	}
}