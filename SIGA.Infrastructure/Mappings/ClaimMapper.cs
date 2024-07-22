using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;
using SIGA.Domain.Entities.Relations;

namespace SIGA.Infrastructure.Mappings;
public class ClaimMapper : IEntityTypeConfiguration<Claim>
{
    public void Configure(EntityTypeBuilder<Claim> builder)
    {
        builder
            .ToTable(nameof(Claim))
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .HasColumnType("INT")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasColumnType("VARCHAR(50)");

        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasColumnType("VARCHAR(200)");

        builder
            .HasMany(x => x.ApplicationUsers)
            .WithMany(x => x.Claims)
            .UsingEntity<ApplicationUserClaim>();
    }
}
