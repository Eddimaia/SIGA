using Microsoft.EntityFrameworkCore;
using SIGA.Lib.Models;
using SIGA.Repositories.Data;
using SIGA.Repositories.Exceptions;
using SIGA.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Repositories;
public class GrupoRepository : IGrupoRepository
{
	private readonly SIGAAppDbContext _context;

	public GrupoRepository(SIGAAppDbContext context)
	{
		_context = context;
	}
	public async Task Delete(int id)
	{
		if (_context.Grupos is null)
			throw new Exception("Entity set 'SIGAAppDbContext.Grupos'  is null.");

		var role = await _context.Grupos.FindAsync(id) ?? throw new DataNotFoundException("Grupo não encontrado");

		_context.Grupos.Remove(role);
		await _context.SaveChangesAsync();
	}

	public async Task<IEnumerable<Grupo>> GetAll()
	{
		if (_context.Grupos is null)
			throw new Exception("Entity set 'SIGAAppDbContext.Grupos'  is null.");

		return await _context.Grupos.AsNoTracking().ToListAsync();
	}

	public async Task<Grupo> GetById(int id)
	{
		if (_context.Grupos is null)
			throw new Exception("Entity set 'SIGAAppDbContext.Grupos'  is null.");

		return await _context.Grupos.FindAsync(id) ?? throw new DataNotFoundException("Grupo não encontrado");
	}

	public async Task<IEnumerable<Concessao>> GetConcessoesByGrupo(int grupoId)
	{
		if (_context.Grupos is null)
			throw new Exception("Entity set 'SIGAAppDbContext.Grupos'  is null.");

		var grupos = await _context.Grupos
			.AsNoTracking()
			.Include(g => g.Concessoes)
			.Where(g => g.Id.Equals(grupoId))
			.FirstOrDefaultAsync();

		return grupos.Concessoes;
	}

	public async Task Save(Grupo entity)
	{
		if (_context.Grupos is null)
			throw new Exception("Entity set 'SIGAAppDbContext.Grupos'  is null.");

		entity.UF = entity.UF.ToUpperInvariant();

		_context.Grupos.Add(entity);
		await _context.SaveChangesAsync();
	}

	public async Task Update(Grupo entity)
	{
		_context.Entry(entity).State = EntityState.Modified;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!GrupoExists(entity.Id))
				throw new DataNotFoundException("Grupo não encontrado");
			else
				throw;
		}
	}

	private bool GrupoExists(int id) => (_context.Grupos?.Any(e => e.Id == id)).GetValueOrDefault();
}
