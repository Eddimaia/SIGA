using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;
using SIGA.Domain.Entities.Relations;

namespace SIGA.Infrastructure.Mappings;
public class DatabaseAccessMapper : IEntityTypeConfiguration<DatabaseAccess>
{
    public void Configure(EntityTypeBuilder<DatabaseAccess> builder)
    {
        builder
            .ToTable(nameof(DatabaseAccess))
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
            .HasOne(x => x.Client)
            .WithMany(x => x.DatabaseAccesses)
            .HasConstraintName("FK_DatabseAccess_Client")
            .HasForeignKey(x => x.ClientId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.DatabaseType)
            .WithMany(x => x.DatabaseAccesses)
            .HasConstraintName("FK_DatabseAccess_DatabaseType")
            .HasForeignKey(x => x.DataBaseTypeId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(x => x.Projects)
            .WithMany(x => x.DatabaseAccesses)
            .UsingEntity<DatabaseAcessProject>();
    }
}
