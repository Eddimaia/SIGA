using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;
using SIGA.Domain.Entities.Relations;

namespace SIGA.Infrastructure.Mappings;
public class ProjectMapper : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder
            .ToTable(nameof(Project))
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
            .Property(x => x.Acronym)
            .IsRequired(false)
            .HasColumnType("VARCHAR(10)");

        builder
            .Property(x => x.ImagePath)
            .IsRequired()
            .HasColumnType("VARCHAR(200)");

        builder
            .Property(x => x.CoordinatorId)
            .IsRequired(false)
            .HasColumnType("INT");

        builder
            .HasMany(x => x.Clients)
            .WithMany(x => x.Projects)
            .UsingEntity<ClientProject>();

        builder
            .HasMany(x => x.ApplicationUsers)
            .WithMany(x => x.Projects)
            .UsingEntity<ApplicationUserProject>();


        builder
            .HasOne(x => x.Coordinator)
            .WithMany(x => x.CoordinatorProjects)
            .HasForeignKey(x => x.CoordinatorId)
            .HasConstraintName("FK_Project_CoordinatorId")
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasMany(x => x.DatabaseAccesses)
            .WithMany(x => x.Projects)
            .UsingEntity<DatabaseAcessProject>();
    }
}
