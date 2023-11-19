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
        //CheckDbSet();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Role>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Role> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Funcionario>> GetFuncionariosByRole(int roleId)
    {
        throw new NotImplementedException();
    }

    public Task Save(Role entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Role entity)
    {
        throw new NotImplementedException();
    }

    private void CheckDbSet()
    {
        throw new NotImplementedException();
        //if ( _context.Squads is null )
        //    throw new Exception("Entity set 'SIGAAppDbContext.Roles'  is null.");
    }

    private bool RoleExists(int id)
    {
        throw new NotImplementedException();
    }
}
