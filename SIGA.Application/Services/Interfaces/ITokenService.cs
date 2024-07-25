using SIGA.Domain.Entities;

namespace SIGA.Application.Services.Interfaces;
public interface ITokenService
{
    Task<(string token, string refreshToken)> GenerateTokenAsync(ApplicationUser user);
    Task<(string token, string refreshToken)?> GenerateFromRefreshTokenAsync(ApplicationUser user, string refreshToken);
    bool ClearAutheticationStates(string refreshToken);
}
