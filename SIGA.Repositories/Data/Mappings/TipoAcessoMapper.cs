using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Lib.Enums;
using SIGA.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                new TipoAcesso{Id = ETipoAcesso.Database, Nome = nameof(ETipoAcesso.Database)},
                new TipoAcesso{Id = ETipoAcesso.Server, Nome = nameof(ETipoAcesso.Server)},
                new TipoAcesso{Id = ETipoAcesso.VPN, Nome = nameof(ETipoAcesso.VPN)}
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
