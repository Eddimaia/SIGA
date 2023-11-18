using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGA.Repositories.Data.Mappings;
public class EmpresaVPNMapper : IEntityTypeConfiguration<EmpresaVPN>
{
    public void Configure(EntityTypeBuilder<EmpresaVPN> builder)
    {
        builder
             .ToTable("EmpresaVPN")
             .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnType("SMALLINT")
            .UseIdentityColumn();

        builder
            .Property(x => x.NomeEmpresa)
            .IsRequired()
            .HasColumnName("NomeEmpresa")
            .HasColumnType("VARCHAR")
            .HasMaxLength(15);

        builder
            .HasMany(x => x.VPNs)
            .WithOne(x => x.EmpresaVPN);
    }
}
