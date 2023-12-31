﻿using Microsoft.EntityFrameworkCore;
using SIGA.Domain.Entities;
using SIGA.Infra.Data;
using SIGA.Repositories.Exceptions;
using SIGA.Repositories.Interfaces;

namespace SIGA.Repositories;
public class GrupoRepository : IGrupoRepository
{
    private readonly SIGAAppDbContext _context;

    public GrupoRepository(SIGAAppDbContext context)
    {
        _context = context;
        CheckDbSet();
    }

    private void CheckDbSet()
    {
        if ( _context.Grupos is null )
            throw new Exception("Entity set 'SIGAAppDbContext.Grupos'  is null.");
    }

    public async Task Delete(int id)
    {
        var role = await _context.Grupos.FindAsync(id) ?? throw new DataNotFoundException("Grupo não encontrado");

        _context.Grupos.Remove(role);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Grupo>> GetAll()
    {
        return await _context.Grupos.AsNoTracking().ToListAsync();
    }

    public async Task<Grupo> GetById(int id)
    {
        return await _context.Grupos.FindAsync(id) ?? throw new DataNotFoundException("Grupo não encontrado");
    }

    public async Task<IEnumerable<Concessao>> GetConcessoesByGrupo(int grupoId)
    {
        var grupo = await _context.Grupos
            .AsNoTracking()
            .Include(g => g.Concessoes)
            .Where(g => g.Id.Equals(grupoId))
            .FirstOrDefaultAsync();

        return grupo is null ? throw new DataNotFoundException("Grupo não encontrado") : (IEnumerable<Concessao>)grupo.Concessoes;
    }

    public async Task Save(Grupo entity)
    {
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
        catch ( DbUpdateConcurrencyException )
        {
            if ( !GrupoExists(entity.Id) )
                throw new DataNotFoundException("Grupo não encontrado");
            else
                throw;
        }
    }

    private bool GrupoExists(int id) => (_context.Grupos?.Any(e => e.Id == id)).GetValueOrDefault();
}
