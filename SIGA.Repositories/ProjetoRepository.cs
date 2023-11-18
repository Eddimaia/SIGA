using Microsoft.EntityFrameworkCore;
using SIGA.Domain.Entities;
using SIGA.Infra.Data;
using SIGA.Repositories.Exceptions;
using SIGA.Repositories.Interfaces;

namespace SIGA.Repositories;
public class ProjetoRepository : IProjetoRepository
{
    private readonly SIGAAppDbContext _context;

    public ProjetoRepository(SIGAAppDbContext context)
    {
        _context = context;
        CheckDbSet();
    }

    private void CheckDbSet()
    {
        if ( _context.Projetos is null )
            throw new Exception("Entity set 'SIGAAppDbContext.Projetos'  is null.");
    }

    public async Task Delete(int id)
    {
        var role = await _context.Projetos.FindAsync(id) ?? throw new DataNotFoundException("Projeto não encontrado");

        _context.Projetos.Remove(role);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Acesso>> GetAcessosByProjeto(int idProjeto)
    {
        if ( _context.Projetos is null )
            throw new Exception("Entity set 'SIGAAppDbContext.Projetos'  is null.");

        var projeto = await _context.Projetos
            .Include(p => p.Acessos)
            .Where(p => p.Id.Equals(idProjeto))
            .FirstOrDefaultAsync();

        if ( projeto is null )
            throw new DataNotFoundException("Projeto não encontrado");
        else
            return projeto.Acessos;
    }

    public async Task<IEnumerable<Projeto>> GetAll()
    {
        return await _context.Projetos.AsNoTracking().ToListAsync();
    }

    public async Task<Projeto> GetById(int id)
    {
        return await _context.Projetos
            .FindAsync(id) ?? throw new DataNotFoundException("Projeto não encontrado");
    }

    public async Task<IEnumerable<Concessao>> GetConcessoesByProjeto(int idProjeto)
    {
        var projeto = await _context.Projetos
            .Include(p => p.Concessoes)
            .Where(p => p.Id.Equals(idProjeto))
            .FirstOrDefaultAsync();

        return projeto is null ? throw new DataNotFoundException("Projeto não encontrado") : (IEnumerable<Concessao>)projeto.Concessoes;
    }

    public async Task<IEnumerable<Funcionario>> GetFuncionariosByProjeto(int idProjeto)
    {
        var projeto = await _context.Projetos
            .Include(p => p.Funcionarios)
            .Where(p => p.Id.Equals(idProjeto))
            .FirstOrDefaultAsync();

        if ( projeto is null )
            throw new DataNotFoundException("Projeto não encontrado");
        else
            return projeto.Funcionarios;
    }

    public async Task<Projeto> GetProjetoByName(string name)
    {
        return await _context.Projetos
            .Where(p => p.Nome.Equals(name, StringComparison.OrdinalIgnoreCase))
            .FirstOrDefaultAsync() ?? throw new DataNotFoundException("Projeto não encontrado");
    }

    public async Task<Projeto> GetProjetoBySigla(string sigla)
    {
        return await _context.Projetos
            .Where(p => p.Sigla.Equals(sigla, StringComparison.OrdinalIgnoreCase))
            .FirstOrDefaultAsync() ?? throw new DataNotFoundException("Projeto não encontrado");
    }

    public async Task Save(Projeto entity)
    {
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
        catch ( DbUpdateConcurrencyException )
        {
            if ( !ProjetoExists(entity.Id) )
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
