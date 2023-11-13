using Microsoft.EntityFrameworkCore;
using SIGA.Repositories.Data;
using SIGA.Repositories.Exceptions;
using SIGA.Repositories.Interfaces;
using SIGA.Lib.Models;
using System.Collections.Generic;

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
        if ( _context.Roles is null )
            throw new Exception("Entity set 'SIGAAppDbContext.Roles'  is null.");
    }

    public async Task Delete(int id)
    {
        var role = await _context.Roles.FindAsync(id) ?? throw new DataNotFoundException("Role não encontrada");

        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Role>> GetAll()
    {
        return await _context.Roles.AsNoTracking().ToListAsync();
    }

    public async Task<Role> GetById(int id)
    {
        return await _context.Roles.FindAsync(id) ?? throw new DataNotFoundException("Role não encontrada");
    }

    public async Task<IEnumerable<Funcionario>> GetFuncionariosByRole(int roleId)
    {
        var role = await _context.Roles
            .AsNoTracking()
            .Include(r => r.Funcionarios)
            .Where(r => r.Id.Equals(roleId))
            .FirstOrDefaultAsync();

        return role is null ? throw new DataNotFoundException("Role não encontrada") : (IEnumerable<Funcionario>)role.Funcionarios;
    }

    public async Task Save(Role entity)
    {

        _context.Roles.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Role entity)
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
        return (_context.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
