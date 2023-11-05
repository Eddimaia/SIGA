﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SIGA.API.Data;

#nullable disable

namespace SIGA.API.Migrations
{
    [DbContext(typeof(SIGAAppDbContext))]
    [Migration("20231104143443_v1.0.4")]
    partial class v104
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConcessaoProjeto", b =>
                {
                    b.Property<int>("ConcessaoId")
                        .HasColumnType("int");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.HasKey("ConcessaoId", "ProjetoId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("ConcessaoProjeto");
                });

            modelBuilder.Entity("FuncionarioAcesso", b =>
                {
                    b.Property<int>("AcessoId")
                        .HasColumnType("int");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.HasKey("AcessoId", "FuncionarioId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("FuncionarioAcesso");
                });

            modelBuilder.Entity("FuncionarioProjeto", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.HasKey("FuncionarioId", "ProjetoId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("FuncionarioProjeto");
                });

            modelBuilder.Entity("FuncionarioRole", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("FuncionarioId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("FuncionarioRole");
                });

            modelBuilder.Entity("SIGA.Lib.Models.Acesso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataExpiracao")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("DataExpiracao");

                    b.Property<bool>("Expiracao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(true)
                        .HasColumnName("Expiracao");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Nome");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Senha");

                    b.Property<byte>("TipoAcesso")
                        .HasColumnType("TINYINT")
                        .HasColumnName("TipoAcesso");

                    b.Property<int>("VPNId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.HasIndex("VPNId");

                    b.ToTable("Acesso", (string)null);
                });

            modelBuilder.Entity("SIGA.Lib.Models.AnexoInstalacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Caminho")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Caminho");

                    b.Property<int>("ClientVPNId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("ClientVPNId");

                    b.ToTable("AnexoInstalacao", (string)null);
                });

            modelBuilder.Entity("SIGA.Lib.Models.ClientVPN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescricaoInstalacao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(MAX)")
                        .HasColumnName("DescricaoInstalacao");

                    b.Property<string>("LinkDownload")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("LinkDownload");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Nome");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Observacao");

                    b.Property<string>("Versao")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Versao");

                    b.HasKey("Id");

                    b.ToTable("ClientVPN", (string)null);
                });

            modelBuilder.Entity("SIGA.Lib.Models.Concessao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GrupoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.Property<string>("NomeAbreviado")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("NomeAbreviado");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("CHAR");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("Concessao", (string)null);
                });

            modelBuilder.Entity("SIGA.Lib.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("PasswordHash");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Sobrenome");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "IX_Funcionario_Email")
                        .IsUnique();

                    b.ToTable("Funcionario", (string)null);
                });

            modelBuilder.Entity("SIGA.Lib.Models.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Nome");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("CHAR")
                        .HasColumnName("UF");

                    b.HasKey("Id");

                    b.ToTable("Grupo", (string)null);
                });

            modelBuilder.Entity("SIGA.Lib.Models.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Sigla");

                    b.HasKey("Id");

                    b.ToTable("Projeto", (string)null);
                });

            modelBuilder.Entity("SIGA.Lib.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("SIGA.Lib.Models.VPN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AcessoForaDoServidor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false)
                        .HasColumnName("AcessoForaDoServidor");

                    b.Property<int>("ClientVPNId")
                        .HasColumnType("int");

                    b.Property<int>("ConcessaoId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Descricao");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Host");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.Property<short>("Port")
                        .HasColumnType("SMALLINT")
                        .HasColumnName("Port");

                    b.HasKey("Id");

                    b.HasIndex("ClientVPNId")
                        .IsUnique();

                    b.HasIndex("ConcessaoId");

                    b.ToTable("VPN", (string)null);
                });

            modelBuilder.Entity("ConcessaoProjeto", b =>
                {
                    b.HasOne("SIGA.Lib.Models.Concessao", null)
                        .WithMany()
                        .HasForeignKey("ConcessaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ConcessaoProjeto_ConcessaoId");

                    b.HasOne("SIGA.Lib.Models.Projeto", null)
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ConcessaoProjeto_ProjetoId");
                });

            modelBuilder.Entity("FuncionarioAcesso", b =>
                {
                    b.HasOne("SIGA.Lib.Models.Acesso", null)
                        .WithMany()
                        .HasForeignKey("AcessoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FuncionarioAcesso_AcessoId");

                    b.HasOne("SIGA.Lib.Models.Funcionario", null)
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FuncionarioAcesso_FuncionarioId");
                });

            modelBuilder.Entity("FuncionarioProjeto", b =>
                {
                    b.HasOne("SIGA.Lib.Models.Funcionario", null)
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FuncionarioProjeto_FuncionarioId");

                    b.HasOne("SIGA.Lib.Models.Projeto", null)
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FuncionarioProjeto_ProjetoId");
                });

            modelBuilder.Entity("FuncionarioRole", b =>
                {
                    b.HasOne("SIGA.Lib.Models.Funcionario", null)
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FuncionarioRole_FuncionarioId");

                    b.HasOne("SIGA.Lib.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FuncionarioRole_RoleId");
                });

            modelBuilder.Entity("SIGA.Lib.Models.Acesso", b =>
                {
                    b.HasOne("SIGA.Lib.Models.Projeto", "Projeto")
                        .WithMany("Acessos")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Projeto_AcessoId");

                    b.HasOne("SIGA.Lib.Models.VPN", "VPN")
                        .WithMany("Acessos")
                        .HasForeignKey("VPNId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_VPN_AcessoId");

                    b.Navigation("Projeto");

                    b.Navigation("VPN");
                });

            modelBuilder.Entity("SIGA.Lib.Models.AnexoInstalacao", b =>
                {
                    b.HasOne("SIGA.Lib.Models.ClientVPN", "ClientVPN")
                        .WithMany("AnexosInstalacao")
                        .HasForeignKey("ClientVPNId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ClientVPN_AnexoInstalacaoId");

                    b.Navigation("ClientVPN");
                });

            modelBuilder.Entity("SIGA.Lib.Models.Concessao", b =>
                {
                    b.HasOne("SIGA.Lib.Models.Grupo", "Grupo")
                        .WithMany("Concessoes")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Grupo_ConcessaoId");

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("SIGA.Lib.Models.VPN", b =>
                {
                    b.HasOne("SIGA.Lib.Models.ClientVPN", "ClientVPN")
                        .WithOne("VPN")
                        .HasForeignKey("SIGA.Lib.Models.VPN", "ClientVPNId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_VPN_ClientId");

                    b.HasOne("SIGA.Lib.Models.Concessao", "Concessao")
                        .WithMany("VPNs")
                        .HasForeignKey("ConcessaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_VPN_ConcessaoId");

                    b.Navigation("ClientVPN");

                    b.Navigation("Concessao");
                });

            modelBuilder.Entity("SIGA.Lib.Models.ClientVPN", b =>
                {
                    b.Navigation("AnexosInstalacao");

                    b.Navigation("VPN")
                        .IsRequired();
                });

            modelBuilder.Entity("SIGA.Lib.Models.Concessao", b =>
                {
                    b.Navigation("VPNs");
                });

            modelBuilder.Entity("SIGA.Lib.Models.Grupo", b =>
                {
                    b.Navigation("Concessoes");
                });

            modelBuilder.Entity("SIGA.Lib.Models.Projeto", b =>
                {
                    b.Navigation("Acessos");
                });

            modelBuilder.Entity("SIGA.Lib.Models.VPN", b =>
                {
                    b.Navigation("Acessos");
                });
#pragma warning restore 612, 618
        }
    }
}
