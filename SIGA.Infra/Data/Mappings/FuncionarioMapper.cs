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
            .HasIndex(x => x.Email, "IX_Funcionario_Email")
            .IsUnique();

        builder
			.HasIndex(x => x.Login, "IX_Funcionario_Login")
			.IsUnique();

		builder
        .Property(x => x.Id)
        .ValueGeneratedOnAdd()
        .UseIdentityColumn();

		builder.Property(x => x.Login)
			.IsRequired()
			.HasColumnName("Login")
			.HasColumnType("VARCHAR")
			.HasMaxLength(10);

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

		builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);

        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasColumnName("PasswordHash")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255);

        builder
            .HasMany(x => x.Squads)
            .WithMany(x => x.Funcionarios)
            .UsingEntity<Dictionary<string, object>>(
                "FuncionarioSquad",
                squad => squad
                    .HasOne<Squad>()
                    .WithMany()
                    .HasForeignKey("SquadId")
                    .HasConstraintName("FK_FuncionarioSquad_SquadId")
                    .OnDelete(DeleteBehavior.Cascade),
                funcionario => funcionario
                    .HasOne<Funcionario>()
                    .WithMany()
                    .HasForeignKey("FuncionarioId")
                    .HasConstraintName("FK_FuncionarioSquad_FuncionarioId")
                    .OnDelete(DeleteBehavior.Cascade));

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
