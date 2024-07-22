using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;
using SIGA.Domain.Entities.Relations;

namespace SIGA.Infrastructure.Mappings;
public class VpnMapper : IEntityTypeConfiguration<Vpn>
{
    public void Configure(EntityTypeBuilder<Vpn> builder)
    {
        builder
            .ToTable(nameof(Vpn))
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .HasColumnType("INT")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .Property(x => x.Host)
            .IsRequired()
            .HasColumnType("VARCHAR(50)");

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasColumnType("VARCHAR(50)");

        builder
            .Property(x => x.Version)
            .IsRequired()
            .HasColumnType("VARCHAR(10)");

        builder
            .Property(x => x.IconPath)
            .IsRequired(false)
            .HasColumnType("VARCHAR(50)");

        builder
            .Property(x => x.Domain)
            .IsRequired(false)
            .HasColumnType("VARCHAR(50)");

        builder
            .HasOne(x => x.Client)
            .WithMany(x => x.Vpns)
            .HasForeignKey(x => x.ClientId)
            .HasConstraintName("FK_VPN_CLIENT")
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(x => x.VpnAccesses)
            .WithOne(x => x.Vpn)
            .HasForeignKey(x => x.VpnId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
