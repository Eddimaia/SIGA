using SIGA.Lib.Models;

namespace SIGA.Repositories.Interfaces;
public interface IGrupoRepository : IRepository<Grupo>
{
	Task<IEnumerable<Concessao>> GetConcessoesByGrupo(int grupoId);
}
