using Microsoft.EntityFrameworkCore;
using SIGA.Repositories.Data.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SIGA.Domain.Entities;

namespace SIGA.Infra.Data;

public class SIGAAppDbContext : IdentityDbContext<ApplicationUser>
{
    public SIGAAppDbContext(DbContextOptions options) : base(options) { }
	public DbSet<Acesso> Acessos { get; set; }
	public DbSet<AnexoInstalacao> AnexosIntalacoes { get; set; }
	public DbSet<ClientVPN> ClientsVPNs { get; set; }
	public DbSet<Concessao> Concessoes { get; set; }
	public DbSet<Funcionario> Funcionarios { get; set; }
	public DbSet<Grupo> Grupos { get; set; }
	public DbSet<Projeto> Projetos { get; set; }
	public DbSet<Squad> Squads { get; set; }
	public DbSet<VPN> VPNs { get; set; }
	public DbSet<TipoAcesso> TipoAcessos { get; set; }
	public DbSet<EmpresaVPN> EmpresasVPNs { get; set; }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder
			.ApplyConfiguration(new AcessoMapper())
			.ApplyConfiguration(new AnexoInstalacaoMapper())
			.ApplyConfiguration(new ClientVPNMapper())
			.ApplyConfiguration(new ConcessaoMapper())
			.ApplyConfiguration(new FuncionarioMapper())
			.ApplyConfiguration(new GrupoMapper())
			.ApplyConfiguration(new ProjetoMapper())
			.ApplyConfiguration(new SquadMapper())
			.ApplyConfiguration(new VPNMapper())
			.ApplyConfiguration(new TipoAcessoMapper())
			.ApplyConfiguration(new EmpresaVPNMapper());
	}
}
