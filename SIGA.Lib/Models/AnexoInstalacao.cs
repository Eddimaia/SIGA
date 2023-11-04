namespace SIGA.Lib.Models;
public class AnexoInstalacao : ModelBase
{
    public string Caminho { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;

    public ClientVPN ClientVPN { get; set; } = new();
}
