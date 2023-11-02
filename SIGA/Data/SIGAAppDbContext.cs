using Microsoft.EntityFrameworkCore;
using SIGA.API.Data.Mappings;
using SIGA.Lib.Models;

namespace SIGA.API.Data;

public class SIGAAppDbContext : DbContext
{
    public SIGAAppDbContext(DbContextOptions<SIGAAppDbContext> options) : base(options) { }
    public DbSet<Funcionario> Funcionarios { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FuncionarioMapper());
    }
}
