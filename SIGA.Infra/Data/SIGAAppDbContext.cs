using Microsoft.EntityFrameworkCore;
using SIGA.Repositories.Data.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SIGA.Domain.Entities;
using SIGA.Infra.Data.Mappings;
using Microsoft.AspNetCore.Identity;

namespace SIGA.Infra.Data;

public class SIGAAppDbContext(DbContextOptions options) : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>(options)
{
    public DbSet<Acesso> Acessos { get; set; }
	public DbSet<AnexoInstalacao> AnexosIntalacoes { get; set; }
	public DbSet<ClientVPN> ClientsVPNs { get; set; }
	public DbSet<Concessao> Concessoes { get; set; }
	public DbSet<Funcionario> Funcionarios { get; set; }
	public DbSet<Grupo> Grupos { get; set; }
	public DbSet<Projeto> Projetos { get; set; }
	public DbSet<VPN> VPNs { get; set; }
	public DbSet<TipoAcesso> TipoAcessos { get; set; }
	public DbSet<EmpresaVPN> EmpresasVPNs { get; set; }
	public DbSet<Equipe> Equipes { get; set; }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<IdentityRole>().HasData(new List<IdentityRole>
        {
            new() { Id = "1", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "FA17B140-A23D-42C0-A627-77AAE14CF19C"},
            new() { Id = "2", Name = "Funcionario", NormalizedName = "FUNCIONARIO", ConcurrencyStamp = "E938FC2D-9EC8-4C57-8889-5DAD0B21CECE"}
        });
		modelBuilder.Entity<ApplicationUser>().ToTable("users", schema: "Identity");
        modelBuilder
			.ApplyConfiguration(new AcessoMapper())
			.ApplyConfiguration(new AnexoInstalacaoMapper())
			.ApplyConfiguration(new ClientVPNMapper())
			.ApplyConfiguration(new ConcessaoMapper())
			.ApplyConfiguration(new FuncionarioMapper())
			.ApplyConfiguration(new GrupoMapper())
			.ApplyConfiguration(new ProjetoMapper())
			.ApplyConfiguration(new VPNMapper())
			.ApplyConfiguration(new TipoAcessoMapper())
			.ApplyConfiguration(new EmpresaVPNMapper())
			.ApplyConfiguration(new EquipeMapper())
			//.ApplyConfiguration(new IdentityUserMapper())
			;
	}
}
