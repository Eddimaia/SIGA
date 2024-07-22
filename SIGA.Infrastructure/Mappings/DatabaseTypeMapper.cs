using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;
using SIGA.Domain.Enums;

namespace SIGA.Infrastructure.Mappings;
public class DatabaseTypeMapper : IEntityTypeConfiguration<DatabaseType>
{
    public void Configure(EntityTypeBuilder<DatabaseType> builder)
    {
        builder
            .ToTable(nameof(DatabaseType))
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .HasConversion<byte>()
            .HasColumnType("TINYINT")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasColumnType("VARCHAR(50)");

        builder
            .HasMany(x => x.DatabaseAccesses)
            .WithOne(x => x.DatabaseType)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasData(
            new DatabaseType { Id = EDatabaseType.SqlServer, Name = nameof(EDatabaseType.SqlServer) },
            new DatabaseType { Id = EDatabaseType.PostgreSql, Name = nameof(EDatabaseType.PostgreSql) },
            new DatabaseType { Id = EDatabaseType.MySql, Name = nameof(EDatabaseType.MySql) },
            new DatabaseType { Id = EDatabaseType.OracleDb, Name = nameof(EDatabaseType.OracleDb) },
            new DatabaseType { Id = EDatabaseType.MongoDb, Name = nameof(EDatabaseType.MongoDb) }
            );
    }
}
