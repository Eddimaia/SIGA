using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Relations;

namespace SIGA.Infrastructure.Mappings.Relations;
public class DatabaseAcessProjectMapper : IEntityTypeConfiguration<DatabaseAcessProject>
{
    public void Configure(EntityTypeBuilder<DatabaseAcessProject> builder)
    {
        builder
            .ToTable(nameof(DatabaseAcessProject))
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .HasColumnType("INT")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .HasOne(x => x.Project)
            .WithMany(x => x.DatabaseAcessProjects)
            .HasForeignKey(x => x.ProjectId)
            .HasConstraintName("FK_DatabaseAcessProject_Project")
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.DatabaseAccess)
            .WithMany(x => x.DatabaseAcessProjects)
            .HasForeignKey(x => x.DatabaseAccessId)
            .HasConstraintName("FK_DatabaseAcessProject_DatabaseAccess")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
