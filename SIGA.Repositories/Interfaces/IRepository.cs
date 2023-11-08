namespace SIGA.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
	Task<T> GetById(int id);
	Task<IEnumerable<T>> GetAll();
	Task Save(T entity);
	Task Update(T entity);
	Task Delete(int id);
}
