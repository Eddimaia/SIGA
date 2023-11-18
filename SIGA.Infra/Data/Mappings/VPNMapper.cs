using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Repositories.Data.Mappings;
public class VPNMapper : IEntityTypeConfiguration<VPN>
{
	public void Configure(EntityTypeBuilder<VPN> builder)
	{
		builder
			.ToTable("VPN")
			.HasKey(x => x.Id);

		builder
			.Property(x => x.Id)
			.ValueGeneratedOnAdd()
			.UseIdentityColumn();

		builder.Property(x => x.Nome)
			.IsRequired()
			.HasColumnName("Nome")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(80);

		builder.Property(x => x.Host)
			.IsRequired()
			.HasColumnName("Host")
			.HasColumnType("VARCHAR")
			.HasMaxLength(100);

		builder
			.Property(x => x.Port)
			.IsRequired()
			.HasColumnName("Port")
			.HasColumnType("SMALLINT");

		builder.Property(x => x.Descricao)
			.IsRequired()
			.HasColumnName("Descricao")
			.HasColumnType("VARCHAR")
			.HasMaxLength(1000);

        builder
            .HasOne(x => x.EmpresaVPN)
            .WithMany(x => x.VPNs)
			.HasForeignKey("EmpresaVPNId")
			.HasConstraintName("Fk_VPN_EmpresaVPNId")
            .OnDelete(DeleteBehavior.Cascade);

        builder
			.HasOne(x => x.ClientVPN)
			.WithOne(x => x.VPN)
            .OnDelete(DeleteBehavior.Cascade);

		builder
			.HasOne(x => x.Concessao)
			.WithMany(x => x.VPNs)
            .HasForeignKey("ConcessaoId")
            .HasConstraintName("Fk_VPN_ConcessaoVPNId")
            .OnDelete(DeleteBehavior.Cascade);

		builder
			.HasMany(x => x.Acessos)
			.WithOne(x => x.VPN)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
