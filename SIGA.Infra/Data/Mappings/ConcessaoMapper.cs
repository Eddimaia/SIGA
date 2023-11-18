using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Repositories.Data.Mappings;
public class ConcessaoMapper : IEntityTypeConfiguration<Concessao>
{
	public void Configure(EntityTypeBuilder<Concessao> builder)
	{
		builder
			.ToTable("Concessao")
			.HasKey(t => t.Id);

		builder
			.Property(x => x.Id)
			.ValueGeneratedOnAdd()
			.UseIdentityColumn();

		builder.Property(x => x.Nome)
			.IsRequired()
			.HasColumnName("Nome")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(50);

		builder.Property(x => x.NomeAbreviado)
			.IsRequired()
			.HasColumnName("NomeAbreviado")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(10);

		builder.Property(x => x.UF)
			.HasColumnName("UF")
			.HasColumnType("CHAR")
			.HasMaxLength(2);

		builder
			.HasOne(x => x.Grupo)
			.WithMany(x => x.Concessoes)
			.HasConstraintName("FK_Grupo_ConcessaoId")
			.OnDelete(DeleteBehavior.Cascade);

		builder
			.HasMany(x => x.VPNs)
			.WithOne(x => x.Concessao)
			.HasConstraintName("FK_VPN_ConcessaoId")
			.OnDelete(DeleteBehavior.Cascade);

		builder
			.HasMany(x => x.Projetos)
			.WithMany(x => x.Concessoes)
			.UsingEntity<Dictionary<string, object>>(
				"ConcessaoProjeto",
				projeto => projeto
					.HasOne<Projeto>()
					.WithMany()
					.HasForeignKey("ProjetoId")
					.HasConstraintName("FK_ConcessaoProjeto_ProjetoId")
					.OnDelete(DeleteBehavior.Cascade),
				concessao => concessao
					.HasOne<Concessao>()
					.WithMany()
					.HasForeignKey("ConcessaoId")
					.HasConstraintName("FK_ConcessaoProjeto_ConcessaoId")
					.OnDelete(DeleteBehavior.Cascade));
	}
}