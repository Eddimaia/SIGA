namespace SIGA.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	Task<T> GetById(int id);
	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	Task<IEnumerable<T>> GetAll();
	/// <summary>
	/// 
	/// </summary>
	/// <param name="entity"></param>
	/// <returns></returns>
	Task Save(T entity);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="entity"></param>
	/// <returns></returns>
	Task Update(T entity);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	Task Delete(int id);
}
