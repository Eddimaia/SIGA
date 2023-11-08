using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Lib.Models;

namespace SIGA.Repositories.Data.Mappings;
public class GrupoMapper : IEntityTypeConfiguration<Grupo>
{
	public void Configure(EntityTypeBuilder<Grupo> builder)
	{
		builder
			.ToTable("Grupo")
			.HasKey(x => x.Id);

		builder
			.Property(x => x.Id)
			.ValueGeneratedOnAdd()
			.UseIdentityColumn();

		builder
			.Property(x => x.Nome)
			.IsRequired()
			.HasColumnName("Nome")
			.HasColumnType("VARCHAR")
			.HasMaxLength(50);

		builder
			.Property(x => x.UF)
			.IsRequired()
			.HasColumnName("UF")
			.HasColumnType("CHAR")
			.HasMaxLength(2);

		builder
			.HasMany(x => x.Concessoes)
			.WithOne(x => x.Grupo)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
