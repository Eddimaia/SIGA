﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Repositories.Data.Mappings;
public class AcessoMapper : IEntityTypeConfiguration<Acesso>
{
	public void Configure(EntityTypeBuilder<Acesso> builder)
	{
		builder
			.ToTable("Acesso")
			.HasKey(x => x.Id);

		builder
			.Property(x => x.Id)
			.ValueGeneratedOnAdd()
			.UseIdentityColumn();

		builder
			.Property(x => x.Login)
			.IsRequired()
			.HasColumnName("Nome")
			.HasColumnType("VARCHAR")
			.HasMaxLength(100);

		builder
			.Property(x => x.Senha)
			.IsRequired()
			.HasColumnName("Senha")
			.HasColumnType("NVARCHAR")
			.HasMaxLength(35);

		builder
		.HasOne(x => x.Projeto)
		.WithMany(x => x.Acessos)
		.HasConstraintName("FK_Acesso_ProjetoId")
		.OnDelete(DeleteBehavior.Cascade);

		builder
			.HasMany(x => x.Funcionarios)
			.WithMany(x => x.Acessos)
			.UsingEntity<Dictionary<string, object>>(
			"FuncionarioAcesso",
			funcionario => funcionario
				.HasOne<Funcionario>()
				.WithMany()
				.HasForeignKey("FuncionarioId")
				.HasConstraintName("FK_FuncionarioAcesso_FuncionarioId")
				.OnDelete(DeleteBehavior.Cascade),
			acesso => acesso
				.HasOne<Acesso>()
				.WithMany()
				.HasForeignKey("AcessoId")
				.HasConstraintName("FK_FuncionarioAcesso_AcessoId")
				.OnDelete(DeleteBehavior.Cascade));

		//builder
		//	.Property(x => x.TipoAcesso)
		//	.IsRequired()
		//	.HasColumnName("TipoAcesso")
		//	.HasColumnType("TINYINT");

		builder
			.HasOne(x => x.TipoAcesso)
			.WithMany(x => x.Acessos)
			.HasForeignKey("TipoAcessoId")
			.HasConstraintName("FK_Acesso_TipoAcessoId");

        builder
            .HasOne(x => x.TipoAutenticacaoAcesso)
            .WithMany(x => x.Acessos)
            .HasForeignKey("TipoAutenticacaoAcessoId")
            .HasConstraintName("FK_Acesso_TipoAutenticacaoAcessoId");

        builder
			.HasOne(x => x.VPN)
			.WithMany(x => x.Acessos)
			.HasConstraintName("FK_Acesso_VPNId")
			.OnDelete(DeleteBehavior.Cascade);

		builder
			.Property(x => x.Expiracao)
			.HasDefaultValue(false)
			.HasColumnName("Expiracao")
			.HasColumnType("BIT");

		builder
			.Property(x => x.DataExpiracao)
			.HasColumnName("DataExpiracao")
			.HasColumnType("DATETIME2");

		builder
			.Property(x => x.Autenticacao)
			.HasDefaultValue(false)
			.HasColumnName("Autenticacao")
			.HasColumnType("BIT");

        builder
            .Property(x => x.AcessoSimultaneo)
            .HasDefaultValue(false)
            .HasColumnName("AcessoSimultaneo")
            .HasColumnType("BIT");

        builder
            .Property(x => x.AcessoForaDoServidor)
            .HasDefaultValue(false)
            .HasColumnName("AcessoForaDoServidor")
            .HasColumnType("BIT");

        builder
            .Property(x => x.QtdMaximaAcessoSimultaneo)
            .HasDefaultValue(false)
            .HasColumnName("QtdMaximaAcessoSimultaneo")
            .HasColumnType("TINYINT");

        builder
            .Property(x => x.BlAtivo)
            .HasDefaultValue(true)
            .HasColumnName("BlAtivo")
            .HasColumnType("BIT");

        builder
            .Property(x => x.BlAtivo)
            .HasDefaultValue(true)
            .HasColumnName("BlAtivo")
            .HasColumnType("BIT");
    }
}
