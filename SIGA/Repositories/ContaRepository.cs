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
		var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id) ?? throw new DataNotFoundException("Funcionário não encontrado");

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
		var funcionario = await _context.Funcionarios
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.Id == id);
		return funcionario;
	}

	public async Task<Funcionario?> GetByLogin(string login)
	{
		var funcionario = await _context.Funcionarios
			.AsNoTracking()
			.Include(x => x.Roles)
			.FirstOrDefaultAsync(x => x.Login.ToLower().Equals(login.ToLower()));
		return funcionario;
	}

	public async Task Register(Funcionario funcionario)
	{
		await _context.Funcionarios.AddAsync(funcionario);
		await _context.SaveChangesAsync();
	}

	public Task Save(Funcionario entity)
	{
		throw new NotImplementedException();
	}

	public async Task Update(Funcionario entity)
	{
		var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == entity.Id) ?? throw new DataNotFoundException("Funcionário não encontrado");

		_context.Funcionarios.Update(funcionario);
		await _context.SaveChangesAsync();
	}
}
