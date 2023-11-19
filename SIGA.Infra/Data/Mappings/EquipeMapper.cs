using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;
using SIGA.Domain.Enums;

namespace SIGA.Infra.Data.Mappings;
public class EquipeMapper : IEntityTypeConfiguration<Equipe>
{
    public void Configure(EntityTypeBuilder<Equipe> builder)
    {
        builder
             .ToTable("Equipe")
             .HasKey(x => x.Id);

        builder
            .HasData(new List<Equipe>
            {
                new() {Id = EEquipe.Desenvolvimento, Nome = nameof(EEquipe.Desenvolvimento)},
                new() {Id = EEquipe.Suporte, Nome = nameof(EEquipe.Suporte)},
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
            .HasMany(x => x.Funcionarios)
            .WithOne(x => x.Equipe);
    }
}
