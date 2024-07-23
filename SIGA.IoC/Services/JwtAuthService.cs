using Microsoft.IdentityModel.Tokens;
using SIGA.Application.Services.Interfaces;
using SIGA.Domain.Entities;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SIGA.IoC.Services;
public class JwtAuthService : ITokenService
{
    private readonly ConcurrentDictionary<string, string?> _refreshTokens = new ConcurrentDictionary<string, string?>();
    public async Task<(string token, string refreshToken)?> GenerateFromRefreshTokenAsync(ApplicationUser user, string refreshToken)
    {
        if (ValidateRefreshToken(refreshToken))
        {
            _refreshTokens.TryRemove(refreshToken, out _);
            return await GenerateTokenAsync(user);
        }

        return null;
    }

    public async Task<(string token, string refreshToken)> GenerateTokenAsync(ApplicationUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("TESTE_KEY_API_QLÇWJKSAAZZXCV");
        var expiration = DateTime.Now.AddHours(3);

        var claims = new List<System.Security.Claims.Claim>();
        claims.AddRange(user.Claims.Select(claim => new System.Security.Claims.Claim(claim.Name, claim.Description)));

        foreach (var role in user.Roles)
            claims.Add(new System.Security.Claims.Claim(ClaimTypes.Role, role.Name));

        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expiration,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var jwtToken = tokenHandler.CreateToken(descriptor);
        var tokenWrite = tokenHandler.WriteToken(jwtToken);

        var refreshToken = await GenerateRefreshToken();

        var tuple = Tuple.Create(jwtToken, refreshToken);

        return (tokenWrite, refreshToken);
    }

    private Task<string> GenerateRefreshToken()
    {
        var refreshToken = Guid.NewGuid().ToString();
        _refreshTokens.TryAdd(refreshToken, null);

        return Task.FromResult(refreshToken);
    }

    private bool ValidateRefreshToken(string refreshToken)
        => _refreshTokens.TryGetValue(refreshToken, out _);
}
