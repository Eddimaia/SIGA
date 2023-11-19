namespace SIGA.Domain.DTOs.Usuario;
public class LoginResponseDTO
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}
