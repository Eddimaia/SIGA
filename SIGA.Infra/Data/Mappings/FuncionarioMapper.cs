using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Repositories.Data.Mappings;

public class FuncionarioMapper : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder
            .ToTable("Funcionario")
            .HasKey(x => x.Id);

		builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

		builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

		builder.Property(x => x.Sobrenome)
			.IsRequired()
			.HasColumnName("Sobrenome")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(50);

        builder
            .HasOne(x => x.Usuario)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Equipe)
            .WithMany(x => x.Funcionarios)
            .HasConstraintName("FK_Funcionario_EquipeId")
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.Projetos)
            .WithMany(x => x.Funcionarios)
            .UsingEntity<Dictionary<string, object>>(
                "FuncionarioProjeto",
                projeto => projeto
                    .HasOne<Projeto>()
                    .WithMany()
                    .HasForeignKey("ProjetoId")
                    .HasConstraintName("FK_FuncionarioProjeto_ProjetoId")
                    .OnDelete(DeleteBehavior.Cascade),
                funcionario => funcionario
                    .HasOne<Funcionario>()
                    .WithMany()
                    .HasForeignKey("FuncionarioId")
                    .HasConstraintName("FK_FuncionarioProjeto_FuncionarioId")
                    .OnDelete(DeleteBehavior.Cascade));

        builder
            .HasMany(x => x.Acessos)
            .WithMany(x => x.Funcionarios)
            .UsingEntity<Dictionary<string, object>>(
                "FuncionarioAcesso",
                acesso => acesso
                    .HasOne<Acesso>()
                    .WithMany()
                    .HasForeignKey("AcessoId")
                    .HasConstraintName("FK_FuncionarioAcesso_AcessoId")
                    .OnDelete(DeleteBehavior.Cascade),
                funcionario => funcionario
                    .HasOne<Funcionario>()
                    .WithMany()
                    .HasForeignKey("FuncionarioId")
                    .HasConstraintName("FK_FuncionarioAcesso_FuncionarioId")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}
