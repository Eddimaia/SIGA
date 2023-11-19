using SIGA.Domain.Entities;

namespace SIGA.Repositories.Interfaces;

public interface IRoleRepository : IRepository<Role>
{
	Task<IEnumerable<Funcionario>> GetFuncionariosByRole(int roleId);
}
