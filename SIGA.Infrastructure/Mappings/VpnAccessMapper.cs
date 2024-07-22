using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Infrastructure.Mappings;
public class VpnAccessMapper : IEntityTypeConfiguration<VpnAccess>
{
    public void Configure(EntityTypeBuilder<VpnAccess> builder)
    {
        builder
            .ToTable(nameof(VpnAccess))
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .HasColumnType("INT")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .Property(x => x.Login)
            .IsRequired()
            .HasColumnType("VARCHAR(50)");

        builder
            .Property(x => x.Password)
            .IsRequired()
            .HasColumnType("VARCHAR(50)");

        builder
            .HasOne(x => x.ApplicationUser)
            .WithMany(x => x.VpnAccesses)
            .HasForeignKey(x => x.ApplicationUserId)
            .HasConstraintName("FK_VpnAccess_ApplicationUser")
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.Vpn)
            .WithMany(x => x.VpnAccesses)
            .HasForeignKey(x => x.VpnId)
            .HasConstraintName("FK_VpnAccess_Vpn")
            .OnDelete(DeleteBehavior.NoAction);
    }
}
