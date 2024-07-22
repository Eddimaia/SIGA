using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;
using SIGA.Domain.Entities.Relations;

namespace SIGA.Infrastructure.Mappings;
public class ClientMapper : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder
            .ToTable(nameof(Client))
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
            .HasMany(x => x.Projects)
            .WithMany(x => x.Clients)
            .UsingEntity<ClientProject>();

        builder
            .HasMany(x => x.DatabaseAccesses)
            .WithOne(x => x.Client)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.Vpns)
            .WithOne(x => x.Client)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
