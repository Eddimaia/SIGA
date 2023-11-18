using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;
using SIGA.Domain.Enums;

namespace SIGA.Repositories.Data.Mappings;
public class TipoAcessoMapper : IEntityTypeConfiguration<TipoAcesso>
{
    public void Configure(EntityTypeBuilder<TipoAcesso> builder)
    {
        builder
             .ToTable("TipoAcesso")
             .HasKey(x => x.Id);

        builder
            .HasData(new List<TipoAcesso>
            {
                new() {Id = ETipoAcesso.Database, Nome = nameof(ETipoAcesso.Database)},
				new() {Id = ETipoAcesso.Server, Nome = nameof(ETipoAcesso.Server)},
				new() {Id = ETipoAcesso.VPN, Nome = nameof(ETipoAcesso.VPN)}
            });

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnType("TINYINT")
            .UseIdentityColumn();

        builder
            .Property(x => x.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        builder
            .HasMany(x => x.Acessos)
            .WithOne(x => x.TipoAcesso);
    }
}
