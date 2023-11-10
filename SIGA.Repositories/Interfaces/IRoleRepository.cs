using SIGA.Lib.Models;

namespace SIGA.Repositories.Interfaces;

public interface IRoleRepository : IRepository<Role>
{
	Task<IEnumerable<Funcionario>> GetFuncionariosByRole(int roleId);
}
