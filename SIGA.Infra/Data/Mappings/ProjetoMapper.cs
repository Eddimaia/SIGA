using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Repositories.Data.Mappings;
public class ProjetoMapper : IEntityTypeConfiguration<Projeto>
{
	public void Configure(EntityTypeBuilder<Projeto> builder)
	{
		builder
			.ToTable("Projeto")
			.HasKey(x => x.Id);

		builder.HasData(new List<Projeto>
		{
			new Projeto
			{
				Id = 1,
				Nome = "SUITS",
				Sigla = "SUITS"
			},
			new Projeto
			{
				Id = 2,
				Nome = "TOR",
				Sigla = "TOR"
			},new Projeto
			{
				Id = 3,
				Nome = "SIR",
				Sigla = "SIR"
			},new Projeto
			{
				Id = 4,
				Nome = "SAGA",
				Sigla = "SAGA"
			},new Projeto
			{
				Id = 5,
				Nome = "FADAMY PAY",
				Sigla = "FPAY"
			}
		});

		builder
			.Property(x => x.Id)
			.ValueGeneratedOnAdd()
			.UseIdentityColumn();

		builder.Property(x => x.Nome)
			.IsRequired()
			.HasColumnName("Nome")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(50);

		builder.Property(x => x.Sigla)
			.IsRequired()
			.HasColumnName("Sigla")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(50);

		builder
			.HasMany(x => x.Funcionarios)
			.WithMany(x => x.Projetos)
			.UsingEntity<Dictionary<string, object>>(
				"FuncionarioProjeto",
				funcionario => funcionario
					.HasOne<Funcionario>()
					.WithMany()
					.HasForeignKey("FuncionarioId")
					.HasConstraintName("FK_FuncionarioProjeto_FuncionarioId")
					.OnDelete(DeleteBehavior.Cascade),
				projeto => projeto
					.HasOne<Projeto>()
					.WithMany()
					.HasForeignKey("ProjetoId")
					.HasConstraintName("FK_FuncionarioProjeto_ProjetoId")
					.OnDelete(DeleteBehavior.Cascade));

		builder
			.HasMany(x => x.Concessoes)
			.WithMany(x => x.Projetos)
			.UsingEntity<Dictionary<string, object>>(
				"ConcessaoProjeto",
				concessao => concessao
					.HasOne<Concessao>()
					.WithMany()
					.HasForeignKey("ConcessaoId")
					.HasConstraintName("FK_ConcessaoProjeto_ConcessaoId")
					.OnDelete(DeleteBehavior.Cascade),
				projeto => projeto
					.HasOne<Projeto>()
					.WithMany()
					.HasForeignKey("ProjetoId")
					.HasConstraintName("FK_ConcessaoProjeto_ProjetoId")
					.OnDelete(DeleteBehavior.Cascade));
	}
}
