namespace SIGA.Application.Configuration.API;
public class Jwt
{
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public string SecurityKey { get; set; } = null!;
    public int AccessTokenExpiration { get; set; }
    public int RefreshTokenExpiration { get; set; }
}