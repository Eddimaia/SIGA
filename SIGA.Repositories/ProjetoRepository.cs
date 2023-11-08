using Microsoft.EntityFrameworkCore;
using SIGA.Lib.Models;
using SIGA.Repositories.Data;
using SIGA.Repositories.Exceptions;
using SIGA.Repositories.Interfaces;

namespace SIGA.Repositories;
public class ProjetoRepository : IProjetoRepository
{
	private readonly SIGAAppDbContext _context;

	public ProjetoRepository(SIGAAppDbContext context)
	{
		_context = context;
	}

	public async Task Delete(int id)
	{
		if (_context.Projetos is null)
			throw new Exception("Entity set 'SIGAAppDbContext.Projetos'  is null.");

		var role = await _context.Projetos.FindAsync(id) ?? throw new DataNotFoundException("Projeto não encontrado");

		_context.Projetos.Remove(role);
		await _context.SaveChangesAsync();
	}

	public Task<IEnumerable<Acesso>> GetAcessosByProjeto(int idProjeto)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Projeto>> GetAll()
	{
		if (_context.Projetos is null)
			throw new Exception("Entity set 'SIGAAppDbContext.Projetos'  is null.");

		return await _context.Projetos.AsNoTracking().ToListAsync();
	}

	public async Task<Projeto> GetById(int id)
	{
		if (_context.Projetos is null)
			throw new Exception("Entity set 'SIGAAppDbContext.Projetos'  is null.");

		return await _context.Projetos.FindAsync(id) ?? throw new DataNotFoundException("Projeto não encontrado");
	}

	public Task<IEnumerable<Concessao>> GetConcessoesByProjeto(int idProjeto)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Funcionario>> GetFuncionariosByProjeto(int idProjeto)
	{
		throw new NotImplementedException();
	}

	public Task<Projeto> GetProjetoByName(string name)
	{
		throw new NotImplementedException();
	}

	public Task<Projeto> GetProjetoBySigla(string sigla)
	{
		throw new NotImplementedException();
	}

	public async Task Save(Projeto entity)
	{
		if (_context.Projetos is null)
			throw new Exception("Entity set 'SIGAAppDbContext.Projetos'  is null.");

		_context.Projetos.Add(entity);
		await _context.SaveChangesAsync();
	}

	public async Task Update(Projeto entity)
	{
		_context.Entry(entity).State = EntityState.Modified;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!ProjetoExists(entity.Id))
				throw new DataNotFoundException("Projeto não encontrado");
			else
				throw;
		}
	}
	private bool ProjetoExists(int id)
	{
		return (_context.Projetos?.Any(e => e.Id == id)).GetValueOrDefault();
	}
}
