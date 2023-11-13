using Microsoft.EntityFrameworkCore;
using SIGA.Repositories.Data;
using SIGA.Repositories.Exceptions;
using SIGA.Repositories.Interfaces;
using SIGA.Lib.Models;
using NuGet.Packaging;

namespace SIGA.Repositories;

public class FuncionarioRepository : IFuncionarioRepository, IContaRepository
{
    private readonly SIGAAppDbContext _context;

    public FuncionarioRepository(SIGAAppDbContext context)
    {
        _context = context;
        CheckDbSet();
    }

    public async Task Delete(int id)
    {

        var funcionario = await _context.Funcionarios.FindAsync(id) ?? throw new DataNotFoundException("Funcionário não encontrado");

        _context.Funcionarios.Remove(funcionario);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Acesso>> GetAcessosByFuncionario(int funcionarioId)
    {

        var funcionario = await _context.Funcionarios
            .AsNoTracking()
            .Include(f => f.Acessos)
            .Where(f => f.Id.Equals(funcionarioId))
            .FirstOrDefaultAsync();

        return funcionario is null ? throw new DataNotFoundException("Funcionário não encontrado") : (IEnumerable<Acesso>)funcionario.Acessos;
    }

    public async Task<IEnumerable<Funcionario>> GetAll()
    {
        var funcionarios = await _context.Funcionarios
            .AsNoTracking()
            .ToListAsync();
        return funcionarios;
    }

    public async Task<Funcionario> GetByEmail(string email)
    {

        return await _context.Funcionarios.FindAsync(email) ?? throw new DataNotFoundException("Funcionário não encontrado");
    }

    public async Task<Funcionario> GetById(int id)
    {

        return await _context.Funcionarios.FindAsync(id) ?? throw new DataNotFoundException("Funcionário não encontrado");
    }
    public async Task<Funcionario> GetByLogin(string login)
    {
        var funcionario = await _context.Funcionarios
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Login.ToLower().Equals(login.ToLower())) ?? throw new DataNotFoundException("Funcionário não encontrado");
        return funcionario;
    }

    public async Task<IEnumerable<Projeto>> GetProjetosByFuncionario(int funcionarioId)
    {

        var funcionario = await _context.Funcionarios
            .Include(f => f.Projetos)
            .Where(f => f.Id.Equals(funcionarioId))
            .FirstOrDefaultAsync();

        return funcionario == null ? throw new DataNotFoundException("Funcionário não encontrado") : (IEnumerable<Projeto>)funcionario.Projetos;
    }

    public async Task<IEnumerable<Role>> GetRolesByFuncionario(int funcionarioId)
    {
        var funcionario = await _context.Funcionarios
            .Include(f => f.Roles)
            .Where(f => f.Id.Equals(funcionarioId))
            .FirstOrDefaultAsync();

        return funcionario == null ? throw new DataNotFoundException("Funcionário não encontrado") : (IEnumerable<Role>)funcionario.Roles;
    }

    public async Task Save(Funcionario entity)
    {
        _context.Funcionarios.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Funcionario entity)
    {
        var entry = _context.Entry(entity);

        entry.State = EntityState.Modified;

        entry.Property(x => x.PasswordHash).IsModified = false;
        entry.Property(x => x.Login).IsModified = false;
        entry.Property(x => x.Acessos).IsModified = false;
        entry.Property(x => x.Projetos).IsModified = false;
        entry.Property(x => x.Roles).IsModified = false;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch ( DbUpdateConcurrencyException )
        {
            if ( !ContaExists(entity.Id) )
                throw new DataNotFoundException("Funcionário não encontrado");
            else
                throw;
        }
    }

    public async Task UpdatePassword(Funcionario funcionario)
    {
        var entry = _context.Entry(funcionario);

        entry.State = EntityState.Modified;

        entry.Property(x => x.Login).IsModified = false;
        entry.Property(x => x.Nome).IsModified = false;
        entry.Property(x => x.Email).IsModified = false;
        entry.Property(x => x.Sobrenome).IsModified = false;

        entry.Property(x => x.Roles).IsModified = false;
        entry.Property(x => x.Acessos).IsModified = false;
        entry.Property(x => x.Projetos).IsModified = false;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch ( DbUpdateConcurrencyException )
        {
            if ( !ContaExists(funcionario.Id) )
                throw new DataNotFoundException("Funcionário não encontrado");
            else
                throw;
        }
    }

    public async Task AddRolesFuncionario(IEnumerable<int> rolesIds, int funcionarioId)
    {

        var roles = await _context.Roles.Where(x => rolesIds.Contains(x.Id)).ToListAsync();


        var funcionario = await GetById(funcionarioId);

        funcionario.Roles.AddRange(roles);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch ( DbUpdateConcurrencyException )
        {
            if ( !ContaExists(funcionario.Id) )
                throw new DataNotFoundException("Funcionário não encontrado");
            else
                throw;
        }
    }

    private bool ContaExists(int id) => (_context.Funcionarios?.Any(e => e.Id == id)).GetValueOrDefault();

    public async Task AddAcessoFuncionario(IEnumerable<int> acessosIds, int funcionarioId)
    {

        var acessos = await _context.Acessos.Where(x => acessosIds.Contains(x.Id)).ToListAsync();


        var funcionario = await GetById(funcionarioId);

        funcionario.Acessos.AddRange(acessos);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch ( DbUpdateConcurrencyException )
        {
            if ( !ContaExists(funcionario.Id) )
                throw new DataNotFoundException("Funcionário não encontrado");
            else
                throw;
        }
    }

    public async Task AddProjetosFuncionario(IEnumerable<int> projetosIds, int funcionarioId)
    {

        var projetos = await _context.Projetos.Where(x => projetosIds.Contains(x.Id)).ToListAsync();


        var funcionario = await GetById(funcionarioId);

        funcionario.Projetos.AddRange(projetos);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch ( DbUpdateConcurrencyException )
        {
            if ( !ContaExists(funcionario.Id) )
                throw new DataNotFoundException("Funcionário não encontrado");
            else
                throw;
        }
    }

    public async Task RemoveRolesFuncionario(IEnumerable<int> rolesIds, int funcionarioId)
    {

        var roles = await _context.Roles.Where(x => rolesIds.Contains(x.Id)).ToListAsync();


        var funcionario = await GetById(funcionarioId);

        foreach ( var role in roles )
            funcionario.Roles.Remove(role);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch ( DbUpdateConcurrencyException )
        {
            if ( !ContaExists(funcionario.Id) )
                throw new DataNotFoundException("Funcionário não encontrado");
            else
                throw;
        }
    }

    public async Task RemoveAcessoFuncionario(IEnumerable<int> acessosIds, int funcionarioId)
    {

        var acessos = await _context.Acessos.Where(x => acessosIds.Contains(x.Id)).ToListAsync();


        var funcionario = await GetById(funcionarioId);

        foreach ( var acesso in acessos )
            funcionario.Acessos.Remove(acesso);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch ( DbUpdateConcurrencyException )
        {
            if ( !ContaExists(funcionario.Id) )
                throw new DataNotFoundException("Funcionário não encontrado");
            else
                throw;
        }
    }

    public async Task RemoveProjetosFuncionario(IEnumerable<int> projetosIds, int funcionarioId)
    {

        var projetos = await _context.Projetos.Where(x => projetosIds.Contains(x.Id)).ToListAsync();


        var funcionario = await GetById(funcionarioId);

        foreach ( var projeto in projetos )
            funcionario.Projetos.Remove(projeto);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch ( DbUpdateConcurrencyException )
        {
            if ( !ContaExists(funcionario.Id) )
                throw new DataNotFoundException("Funcionário não encontrado");
            else
                throw;
        }
    }

    private void CheckDbSet()
    {
        if ( _context.Funcionarios is null )
            throw new Exception("Entity set 'SIGAAppDbContext.Funcionarios'  is null.");
    }
}
