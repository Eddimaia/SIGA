using SIGA.Lib.Models;

namespace SIGA.Repositories.Interfaces;
public interface IProjetoRepository : IRepository<Projeto>
{
	Task<Projeto> GetProjetoByName(string name);
	Task<Projeto> GetProjetoBySigla(string sigla);
	Task<IEnumerable<Concessao>> GetConcessoesByProjeto(int idProjeto);
	Task<IEnumerable<Acesso>> GetAcessosByProjeto(int idProjeto);
	Task<IEnumerable<Funcionario>> GetFuncionariosByProjeto(int idProjeto);
}
