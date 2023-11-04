using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Lib.Models;

namespace SIGA.API.Data.Mappings;
public class ProjetoMapper : IEntityTypeConfiguration<Projeto>
{
	public void Configure(EntityTypeBuilder<Projeto> builder)
	{
		builder
			.ToTable("Projeto")
			.HasKey(x => x.Id);

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
