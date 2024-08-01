using SIGA.Application.DTO.Accounts;
using SIGA.Application.DTO.Common;

namespace SIGA.Application.Handles.Interfaces;
public interface IAccountHandler
{
    Task<Response<RegisterResponse?>> RegisterAsync(RegisterRequest request);
    Task<Response<LoginResponse?>> LoginAsync(LoginRequest request);
    Task<Response<LoginResponse?>> RefreshTokenAsync(RefreshTokenRequest request);
    Task<Response<RegisterResponse?>> GetLoginInfo(string login);
}
