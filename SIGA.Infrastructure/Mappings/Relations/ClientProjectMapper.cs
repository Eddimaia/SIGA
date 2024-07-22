using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Relations;

namespace SIGA.Infrastructure.Mappings.Relations;
public class ClientProjectMapper : IEntityTypeConfiguration<ClientProject>
{
    public void Configure(EntityTypeBuilder<ClientProject> builder)
    {
        builder
            .ToTable(nameof(ClientProject))
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .HasColumnType("INT")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .HasOne(x => x.Project)
            .WithMany(x => x.ClientProjects)
            .HasForeignKey(x => x.ProjectId)
            .HasConstraintName("FK_ClientProject_Project")
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Client)
            .WithMany(x => x.ClientProjects)
            .HasForeignKey(x => x.ClientId)
            .HasConstraintName("FK_ClientProject_Client")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
