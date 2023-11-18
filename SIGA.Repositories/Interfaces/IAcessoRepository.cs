using SIGA.Domain.Entities;

namespace SIGA.Repositories.Interfaces;
public interface IAcessoRepository : IRepository<Acesso>
{
    Task<IEnumerable<Acesso>> GetAllByTipoAcesso(TipoAcesso tipoAcesso);
    Task<IEnumerable<Funcionario>> GetFuncionariosByAcesso(int acessoId);
    /// <summary></summary>
    /// <returns>Todos os acessos ordenados pela data de expiração mais próxima</returns>
    Task<IEnumerable<Acesso>> GetAllOrderByExpiracao();
}
