using SIGA.Application.DTO;
using SIGA.Application.DTO.Account;

namespace SIGA.Application.Handles.Interfaces;
public interface IAccountHandler
{
    Task<Response<RegisterResponse?>> RegisterAsync(RegisterRequest request);
    Task<Response<LoginResponse?>> LoginAsync(LoginRequest request);
    Task<Response<LoginResponse?>> RefreshTokenAsync(RefreshTokenRequest request);
}
