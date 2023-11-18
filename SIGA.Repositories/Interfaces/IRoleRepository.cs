using SIGA.Domain.Entities;

namespace SIGA.Repositories.Interfaces;

public interface IRoleRepository : IRepository<Squad>
{
	Task<IEnumerable<Funcionario>> GetFuncionariosByRole(int roleId);
}
