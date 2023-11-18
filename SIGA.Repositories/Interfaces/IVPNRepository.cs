using SIGA.Domain.Entities;

namespace SIGA.Repositories.Interfaces;
public interface IVPNRepository : IRepository<VPN>
{
	Task<IEnumerable<Acesso>> GetAcessosByVPN(int vpnId);
}
