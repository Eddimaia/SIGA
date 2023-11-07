using Microsoft.EntityFrameworkCore;
using SIGA.API.Data;
using SIGA.API.Exceptions;
using SIGA.API.Repositories.Interfaces;
using SIGA.Lib.Models;

namespace SIGA.API.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly SIGAAppDbContext _context;

    public RoleRepository(SIGAAppDbContext context)
    {
        _context = context;
    }

    public async Task Delete(int id)
    {
        if (_context.Roles is null)
            throw new Exception("Entity set 'SIGAAppDbContext.Roles'  is null.");

        var role = await _context.Roles.FindAsync(id) ?? throw new DataNotFoundException("Funcionário não encontrado");

        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Role>> GetAll()
    {
        if (_context.Roles is null)
            throw new Exception("Entity set 'SIGAAppDbContext.Roles'  is null.");

        return await _context.Roles.AsNoTracking().ToListAsync();
    }

    public async Task<Role?> GetById(int id)
    {
        if (_context.Roles is null)
            throw new Exception("Entity set 'SIGAAppDbContext.Roles'  is null.");

        return await _context.Roles.FindAsync(id) ?? throw new DataNotFoundException("Role não encontrada");
    }

    public async Task Save(Role entity)
    {

        if (_context.Roles is null)
            throw new Exception("Entity set 'SIGAAppDbContext.Roles'  is null.");

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
        catch (DbUpdateConcurrencyException)
        {
            if (!RoleExists(entity.Id))
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
