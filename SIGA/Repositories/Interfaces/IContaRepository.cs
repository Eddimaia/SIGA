using SIGA.Lib.Models;

namespace SIGA.API.Repositories.Interfaces;

public interface IContaRepository : IRepository<Funcionario>
{
	Task<Funcionario?> GetByLogin(string login);
}
