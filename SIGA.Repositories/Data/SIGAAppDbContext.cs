using Microsoft.EntityFrameworkCore;
using SIGA.Repositories.Data.Mappings;
using SIGA.Lib.Models;

namespace SIGA.Repositories.Data;

public class SIGAAppDbContext : DbContext
{
	public SIGAAppDbContext(DbContextOptions<SIGAAppDbContext> options) : base(options) { }
	public DbSet<Acesso> Acessos { get; set; }
	public DbSet<AnexoInstalacao> AnexosIntalacoes { get; set; }
	public DbSet<ClientVPN> ClientsVPNs { get; set; }
	public DbSet<Concessao> Concessoes { get; set; }
	public DbSet<Funcionario> Funcionarios { get; set; }
	public DbSet<Grupo> Grupos { get; set; }
	public DbSet<Projeto> Projetos { get; set; }
	public DbSet<Role> Roles { get; set; }
	public DbSet<VPN> VPNs { get; set; }
	public DbSet<TipoAcesso> TipoAcessos { get; set; }
	public DbSet<EmpresaVPN> EmpresasVPNs { get; set; }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new AcessoMapper());
		modelBuilder.ApplyConfiguration(new AnexoInstalacaoMapper());
		modelBuilder.ApplyConfiguration(new ClientVPNMapper());
		modelBuilder.ApplyConfiguration(new ConcessaoMapper());
		modelBuilder.ApplyConfiguration(new FuncionarioMapper());
		modelBuilder.ApplyConfiguration(new GrupoMapper());
		modelBuilder.ApplyConfiguration(new ProjetoMapper());
		modelBuilder.ApplyConfiguration(new RoleMapper());
		modelBuilder.ApplyConfiguration(new VPNMapper());
        modelBuilder.ApplyConfiguration(new TipoAcessoMapper());
        modelBuilder.ApplyConfiguration(new EmpresaVPNMapper());
    }
}
