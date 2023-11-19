using SIGA.Domain.Entities;

namespace SIGA.Repositories.Interfaces;

public interface IFuncionarioRepository : IRepository<Funcionario>
{
	Task<Funcionario> GetByEmail(string email);
	Task UpdatePassword(Funcionario funcionario);
	Task<IEnumerable<Projeto>> GetProjetosByFuncionario(int funcionarioId);
    Task<IEnumerable<Acesso>> GetAcessosByFuncionario(int funcionarioId);
    Task<IEnumerable<Role>> GetRolesByFuncionario(int funcionarioId);
	Task AddRolesFuncionario(IEnumerable<int> rolesIds, int funcionarioId);
    Task AddAcessoFuncionario(IEnumerable<int> acessosIds, int funcionarioId);
    Task AddProjetosFuncionario(IEnumerable<int> projetosIds, int funcionarioId);
    Task RemoveRolesFuncionario(IEnumerable<int> rolesIds, int funcionarioId);
    Task RemoveAcessoFuncionario(IEnumerable<int> acessosIds, int funcionarioId);
    Task RemoveProjetosFuncionario(IEnumerable<int> projetosIds, int funcionarioId);
}
