using SIGA.Application.Handles.Interfaces;
using SIGA.Web.Services.Interfaces;
using System.Net.Http.Headers;
using SIGA.IoC.Web.Services;
using SIGA.Application.DTO.Accounts;

namespace SIGA.Web.MessageHandles;

public class TokenHandler : DelegatingHandler
{
    private readonly IJwtService _jwtService;
    private readonly SessionStorageService _sessionStorageService;
    private readonly IServiceProvider _serviceProvider;
    private static bool _isRefreshingToken;

    public TokenHandler(IJwtService tokenService, SessionStorageService sessionStorageService, IServiceProvider serviceProvider)
    {
        _jwtService = tokenService;
        _sessionStorageService = sessionStorageService;
        _serviceProvider = serviceProvider;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _sessionStorageService.GetItemAsync("jwtToken");

        if (!string.IsNullOrEmpty(token) && _jwtService.IsTokenExpired(token))
        {
            if (!_isRefreshingToken)
            {
                _isRefreshingToken = true;
                try
                {
                    var refreshToken = await _sessionStorageService.GetItemAsync("refreshToken");
                    var login = _jwtService.GetClaimFromToken(token, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");
                    var accountHandler = _serviceProvider.GetRequiredService<IAccountHandler>();
                    var response = await accountHandler.RefreshTokenAsync(new RefreshTokenRequest { Login = login!, RefreshToken = refreshToken });

                    if (response != null)
                    {
                        token = response.Data!.Token;
                        await _sessionStorageService.SetItemAsync("jwtToken", token);
                        await _sessionStorageService.SetItemAsync("refreshToken", response.Data.RefreshToken);
                    }
                }
                finally
                {
                    _isRefreshingToken = false;
                }
            }
        }

        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
