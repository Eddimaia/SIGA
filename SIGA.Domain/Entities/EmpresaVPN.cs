using SIGA.Domain.Enums;

namespace SIGA.Domain.Entities;
public class EmpresaVPN
{
	public short Id { get; set; }
	public string NomeEmpresa { get; set; } = string.Empty;

	public ICollection<VPN> VPNs { get; set; } = new List<VPN>();
}
