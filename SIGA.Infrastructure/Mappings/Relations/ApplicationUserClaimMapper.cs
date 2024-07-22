using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Relations;

namespace SIGA.Infrastructure.Mappings.Relations;
public class ApplicationUserClaimMapper : IEntityTypeConfiguration<ApplicationUserClaim>
{
    public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
    {
        builder
            .ToTable(nameof(ApplicationUserClaim))
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .HasColumnType("INT")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .HasOne(x => x.ApplicationUser)
            .WithMany(x => x.UserClaims)
            .HasForeignKey(x => x.ApplicationUserId)
            .HasConstraintName("FK_UserClaim_ApplicationUser")
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Claim)
            .WithMany(x => x.UserClaims)
            .HasForeignKey(x => x.ClaimId)
            .HasConstraintName("FK_UserClaim_Claim")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
