using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SIGA.Application.Configuration.API;
using SIGA.Application.Services.Interfaces;
using SIGA.Domain.Entities;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SIGA.IoC.Services;
/// TODO: Finalizar refreshtoken
public class JwtAuthService(IOptions<Jwt> jwtOptions) : ITokenService
{
    private readonly ConcurrentDictionary<string, string?> _refreshTokens = new ConcurrentDictionary<string, string?>();
    private readonly Jwt _jwtConfiguration = jwtOptions.Value;

    public bool ClearAutheticationStates(string refreshToken) => _refreshTokens.TryRemove(refreshToken, out _);

    public async Task<(string token, string refreshToken)?> GenerateFromRefreshTokenAsync(ApplicationUser user, string refreshToken)
    {
        if (ValidateRefreshToken(user, refreshToken))
        {
            _refreshTokens.TryRemove(user.Login, out _);
            return await AuthenticateAsync(user);
        }

        return null;
    }

    public async Task<(string token, string refreshToken)> AuthenticateAsync(ApplicationUser user)
    {
        return await Task.FromResult((GenerateToken(user), GenerateRefreshToken(user)));
    }

    private string GenerateRefreshToken(ApplicationUser user)
    {
        var key = Encoding.ASCII.GetBytes(_jwtConfiguration.SecurityKey);
        var expiration = DateTime.Now.AddMinutes(_jwtConfiguration.RefreshTokenExpiration);

        var claims = GetClaimsForToken(user, isAccessToken: false);

        var jwt = new JwtSecurityToken(
             issuer: _jwtConfiguration.Issuer,
                audience: _jwtConfiguration.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: expiration,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));

        var refreshToken = new JwtSecurityTokenHandler().WriteToken(jwt);

        _refreshTokens.TryAdd(user.Login, refreshToken);
        return refreshToken;
    }

    private bool ValidateRefreshToken(ApplicationUser user, string refreshToken)
    {
        var exists = _refreshTokens.TryGetValue(user.Login, out var refreshTokenPersisted);

        if (exists && IsTokenExpired(refreshTokenPersisted!))
        {
            return refreshToken == refreshTokenPersisted;
        }

        return false;
    }

    private static List<System.Security.Claims.Claim> GetClaimsForToken(ApplicationUser user, bool isAccessToken = true)
    {
        var claims = new List<System.Security.Claims.Claim> { new(ClaimTypes.NameIdentifier, user.Id.ToString()) };

        if (isAccessToken)
        {

            claims.AddRange(user.Claims.Select(claim => new System.Security.Claims.Claim(claim.Name, claim.Description)));

            foreach (var role in user.Roles)
                claims.Add(new System.Security.Claims.Claim(ClaimTypes.Role, role.Name));

            claims.AddRange([
                new(ClaimTypes.Name, user.Login),
                new(ClaimTypes.Email, user.Email),
                new("RegisteredName", user.FirstName + " " + user.LastName)]);
        }

        return claims;
    }

    private string GenerateToken(ApplicationUser user)
    {
        var key = Encoding.ASCII.GetBytes(_jwtConfiguration.SecurityKey);
        var expiration = DateTime.Now.AddMinutes(_jwtConfiguration.AccessTokenExpiration);

        var claims = GetClaimsForToken(user);

        var jwt = new JwtSecurityToken(
             issuer: _jwtConfiguration.Issuer,
                audience: _jwtConfiguration.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: expiration,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    private bool IsTokenExpired(string token)
    {
        ArgumentException.ThrowIfNullOrEmpty(token, nameof(token));

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadToken(token) as JwtSecurityToken ?? throw new ArgumentException("Token inválido.", nameof(token));

        var expirationDate = jwtToken.ValidTo;

        return expirationDate > DateTime.UtcNow;
    }
}
