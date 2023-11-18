using Microsoft.EntityFrameworkCore;
using SIGA.Infra.Data;
using SIGA.Repositories.Exceptions;
using SIGA.Repositories.Interfaces;
using System.Collections.Generic;
using SIGA.Domain.Entities;

namespace SIGA.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly SIGAAppDbContext _context;

    public RoleRepository(SIGAAppDbContext context)
    {
        _context = context;
        CheckDbSet();
    }

    private void CheckDbSet()
    {
        if ( _context.Squads is null )
            throw new Exception("Entity set 'SIGAAppDbContext.Roles'  is null.");
    }

    public async Task Delete(int id)
    {
        var role = await _context.Squads.FindAsync(id) ?? throw new DataNotFoundException("Role não encontrada");

        _context.Squads.Remove(role);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Squad>> GetAll()
    {
        return await _context.Squads.AsNoTracking().ToListAsync();
    }

    public async Task<Squad> GetById(int id)
    {
        return await _context.Squads.FindAsync(id) ?? throw new DataNotFoundException("Role não encontrada");
    }

    public async Task<IEnumerable<Funcionario>> GetFuncionariosByRole(int roleId)
    {
        var role = await _context.Squads
            .AsNoTracking()
            .Include(r => r.Funcionarios)
            .Where(r => r.Id.Equals(roleId))
            .FirstOrDefaultAsync();

        return role is null ? throw new DataNotFoundException("Role não encontrada") : (IEnumerable<Funcionario>)role.Funcionarios;
    }

    public async Task Save(Squad entity)
    {

        _context.Squads.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Squad entity)
    {
        _context.Entry(entity).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch ( DbUpdateConcurrencyException )
        {
            if ( !RoleExists(entity.Id) )
                throw new DataNotFoundException("Role não encontrada");
            else
                throw;
        }
    }

    private bool RoleExists(int id)
    {
        return (_context.Squads?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
