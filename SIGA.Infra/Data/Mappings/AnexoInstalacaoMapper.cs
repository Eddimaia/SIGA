using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Repositories.Data.Mappings;
public class AnexoInstalacaoMapper : IEntityTypeConfiguration<AnexoInstalacao>
{
	public void Configure(EntityTypeBuilder<AnexoInstalacao> builder)
	{
		builder
			.ToTable("AnexoInstalacao")
			.HasKey(x => x.Id);

		builder
			.Property(x => x.Id)
			.ValueGeneratedOnAdd()
			.UseIdentityColumn();

		builder
			.Property(x => x.Caminho)
			.IsRequired()
			.HasColumnName("Caminho")
			.HasColumnType("VARCHAR")
			.HasMaxLength(500);

		builder
			.Property(x => x.Nome)
			.IsRequired()
			.HasColumnName("Nome")
			.HasColumnType("VARCHAR")
			.HasMaxLength(40);

		builder
			.HasOne(x => x.ClientVPN)
			.WithMany(x => x.AnexosInstalacao)
			.HasConstraintName("FK_ClientVPN_AnexoInstalacaoId")
			.OnDelete(DeleteBehavior.Cascade);
	}
}
