using Microsoft.EntityFrameworkCore;
using SIGA.API.Data;
using SIGA.API.Exceptions;
using SIGA.API.Repositories.Interfaces;
using SIGA.Lib.Models;

namespace SIGA.API.Repositories;

public class ContaRepository : IContaRepository
{
	private readonly SIGAAppDbContext _context;

	public ContaRepository(SIGAAppDbContext context)
	{
		_context = context;
	}

	public async Task Delete(int id)
	{
		if (_context.Funcionarios is null)
			throw new Exception("Entity set 'SIGAAppDbContext.Funcionarios'  is null.");

		var funcionario = await _context.Funcionarios.FindAsync(id) ?? throw new DataNotFoundException("Funcionário não encontrado");

		_context.Funcionarios.Remove(funcionario);
		await _context.SaveChangesAsync();
	}

	public async Task<IEnumerable<Funcionario>> GetAll()
	{
		var funcionarios = await _context.Funcionarios
			.AsNoTracking()
			.ToListAsync();
		return funcionarios;
	}

	public async Task<Funcionario?> GetById(int id)
	{
		if (_context.Funcionarios is null)
			throw new Exception("Entity set 'SIGAAppDbContext.Funcionarios'  is null.");

		return await _context.Funcionarios.FindAsync(id) ?? throw new DataNotFoundException("Funcionário não encontrada;");
	}
	public async Task<Funcionario?> GetByLogin(string login)
	{
		var funcionario = await _context.Funcionarios
			.AsNoTracking()
			.Include(x => x.Roles)
			.Include(x => x.Projetos)
			.Include(x => x.Acessos)
			.FirstOrDefaultAsync(x => x.Login.ToLower().Equals(login.ToLower()));
		return funcionario;
	}

	public async Task Save(Funcionario entity)
	{
		if (_context.Funcionarios is null)
			throw new Exception("Entity set 'SIGAAppDbContext.Funcionarios'  is null.");

		_context.Funcionarios.Add(entity);
		await _context.SaveChangesAsync();
	}

	public async Task Update(Funcionario entity)
	{
		var entry = _context.Entry(entity);

		entry.State = EntityState.Modified;
		entry.Property(x => x.PasswordHash).IsModified = false;
		entry.Property(x => x.Login).IsModified = false;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!ContaExists(entity.Id))
				throw new DataNotFoundException("Funcionário não encontrado");
			else
				throw;
		}
	}

	private bool ContaExists(int id) => (_context.Funcionarios?.Any(e => e.Id == id)).GetValueOrDefault();
}
