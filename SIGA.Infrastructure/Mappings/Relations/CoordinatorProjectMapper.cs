using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Relations;

namespace SIGA.Infrastructure.Mappings.Relations;
public class CoordinatorProjectMapper : IEntityTypeConfiguration<CoordinatorProject>
{
    public void Configure(EntityTypeBuilder<CoordinatorProject> builder)
    {
        builder
            .ToTable(nameof(CoordinatorProject))
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .HasColumnType("INT")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .HasOne(x => x.Project)
            .WithMany(x => x.CoordinatorsProjects)
            .HasForeignKey(x => x.ProjectId)
            .HasConstraintName("FK_CoordinatorProject_Project")
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.ApplicationUser)
            .WithMany(x => x.CoordinatorsProjects)
            .HasForeignKey(x => x.ApplicationUserId)
            .HasConstraintName("FK_CoordinatorProject_ApplicationUser")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
