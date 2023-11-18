using SIGA.Domain.Entities;

namespace SIGA.Repositories.Interfaces;
public interface IGrupoRepository : IRepository<Grupo>
{
	Task<IEnumerable<Concessao>> GetConcessoesByGrupo(int grupoId);
}
