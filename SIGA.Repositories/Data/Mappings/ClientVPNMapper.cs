using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Lib.Models;

namespace SIGA.Repositories.Data.Mappings;
public class ClientVPNMapper : IEntityTypeConfiguration<ClientVPN>
{
	public void Configure(EntityTypeBuilder<ClientVPN> builder)
	{

		builder
			.ToTable("ClientVPN")
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
			.Property(x => x.LinkDownload)
			.IsRequired()
			.HasColumnName("LinkDownload")
			.HasColumnType("VARCHAR")
			.HasMaxLength(200);

		builder
			.Property(x => x.Versao)
			.IsRequired()
			.HasColumnName("Versao")
			.HasColumnType("VARCHAR")
			.HasMaxLength(10);

		builder
			.Property(x => x.Observacao)
			.IsRequired()
			.HasColumnName("Observacao")
			.HasColumnType("VARCHAR")
			.HasMaxLength(500);

		builder
			.Property(x => x.DescricaoInstalacao)
			.IsRequired()
			.HasColumnName("DescricaoInstalacao")
			.HasColumnType("VARCHAR(MAX)");

		builder
			.HasOne(x => x.VPN)
			.WithOne(x => x.ClientVPN)
			.HasForeignKey<ClientVPN>("VPNId")
			.HasConstraintName("FK_ClientVPN_VPNId")
			.OnDelete(DeleteBehavior.Cascade);

		builder
			.HasMany(x => x.AnexosInstalacao)
			.WithOne(x => x.ClientVPN)
			.OnDelete(DeleteBehavior.Cascade);
	}
}