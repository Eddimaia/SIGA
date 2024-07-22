using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Relations;

namespace SIGA.Infrastructure.Mappings.Relations;
public class ApplicationUserProjectMapper : IEntityTypeConfiguration<ApplicationUserProject>
{
    public void Configure(EntityTypeBuilder<ApplicationUserProject> builder)
    {
        builder
            .ToTable(nameof(ApplicationUserProject))
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .HasColumnType("INT")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .HasOne(x => x.Project)
            .WithMany(x => x.UserProjects)
            .HasForeignKey(x => x.ProjectId)
            .HasConstraintName("FK_UserProject_Project")
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.ApplicationUser)
            .WithMany(x => x.UserProjects)
            .HasForeignKey(x => x.ApplicationUserId)
            .HasConstraintName("FK_UserProject_ApplicationUser")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
