namespace SIGA.Application.Handles.Interfaces;
public interface ILogoutRefreshEndpointHandler
{
    Task<bool> LogoutAsync(string refreshToken);
}
