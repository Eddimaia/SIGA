namespace SIGA.API;

public class Configuration
{
	public static string JwtKey { get; set; } = string.Empty;
	public static string ApiKeyName { get; set; } = string.Empty;
	public static string ApiKey { get; set; } = string.Empty;
	public static string Issuer { get; set;} = string.Empty;
	public static string Audience { get; set; } = string.Empty;
}
