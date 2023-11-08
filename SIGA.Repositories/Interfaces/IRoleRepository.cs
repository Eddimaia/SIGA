using SIGA.Lib.Models;

namespace SIGA.Repositories.Interfaces;

public interface IRoleRepository : IRepository<Role>
{
	Task<Funcionario> GetFuncionariosByRole(int roleId);
}
