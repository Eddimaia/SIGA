﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SIGA.Infra.Data;

#nullable disable

namespace SIGA.Infra.Migrations
{
    [DbContext(typeof(SIGAAppDbContext))]
    [Migration("20231121034318_3.0.0.0")]
    partial class _3000
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityRole");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "FA17B140-A23D-42C0-A627-77AAE14CF19C",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "E938FC2D-9EC8-4C57-8889-5DAD0B21CECE",
                            Name = "Funcionario",
                            NormalizedName = "FUNCIONARIO"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SIGA.Domain.Entities.Acesso", b =>
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

                    b.Property<bool>("AcessoSimultaneo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false)
                        .HasColumnName("AcessoSimultaneo");

                    b.Property<bool>("Autenticacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false)
                        .HasColumnName("Autenticacao");

                    b.Property<bool>("BlAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(true)
                        .HasColumnName("BlAtivo");

                    b.Property<DateTime?>("DataExpiracao")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("DataExpiracao");

                    b.Property<bool>("Expiracao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false)
                        .HasColumnName("Expiracao");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Nome");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<byte>("QtdMaximaAcessoSimultaneo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TINYINT")
                        .HasDefaultValue((byte)0)
                        .HasColumnName("QtdMaximaAcessoSimultaneo");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Senha");

                    b.Property<byte?>("TipoAcessoId")
                        .HasColumnType("TINYINT");

                    b.Property<byte?>("TipoAutenticacaoAcessoId")
                        .HasColumnType("tinyint");

                    b.Property<int>("VPNId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.HasIndex("TipoAcessoId");

                    b.HasIndex("TipoAutenticacaoAcessoId");

                    b.HasIndex("VPNId");

                    b.ToTable("Acesso", (string)null);
                });

            modelBuilder.Entity("SIGA.Domain.Entities.AnexoInstalacao", b =>
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

            modelBuilder.Entity("SIGA.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("users", "Identity");
                });

            modelBuilder.Entity("SIGA.Domain.Entities.ClientVPN", b =>
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

                    b.Property<int>("VPNId")
                        .HasColumnType("int");

                    b.Property<string>("Versao")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Versao");

                    b.HasKey("Id");

                    b.HasIndex("VPNId")
                        .IsUnique();

                    b.ToTable("ClientVPN", (string)null);
                });

            modelBuilder.Entity("SIGA.Domain.Entities.Concessao", b =>
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
                        .HasColumnType("CHAR")
                        .HasColumnName("UF");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("Concessao", (string)null);
                });

            modelBuilder.Entity("SIGA.Domain.Entities.EmpresaVPN", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLINT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("NomeEmpresa")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("NomeEmpresa");

                    b.HasKey("Id");

                    b.ToTable("EmpresaVPN", (string)null);
                });

            modelBuilder.Entity("SIGA.Domain.Entities.Equipe", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TINYINT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Equipe", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Nome = "Desenvolvimento"
                        },
                        new
                        {
                            Id = (byte)2,
                            Nome = "Suporte"
                        });
                });

            modelBuilder.Entity("SIGA.Domain.Entities.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte>("EquipeId")
                        .HasColumnType("TINYINT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Sobrenome");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipeId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Funcionario", (string)null);
                });

            modelBuilder.Entity("SIGA.Domain.Entities.Grupo", b =>
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

            modelBuilder.Entity("SIGA.Domain.Entities.Projeto", b =>
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "SUITS",
                            Sigla = "SUITS"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "TOR",
                            Sigla = "TOR"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "SIR",
                            Sigla = "SIR"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "SAGA",
                            Sigla = "SAGA"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "FADAMY PAY",
                            Sigla = "FPAY"
                        });
                });

            modelBuilder.Entity("SIGA.Domain.Entities.TipoAcesso", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TINYINT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("TipoAcesso", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Nome = "Database"
                        },
                        new
                        {
                            Id = (byte)2,
                            Nome = "Server"
                        },
                        new
                        {
                            Id = (byte)3,
                            Nome = "VPN"
                        });
                });

            modelBuilder.Entity("SIGA.Domain.Entities.TipoAutenticacaoAcesso", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("NomeAppAutenticacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoAutenticacaoAcesso");
                });

            modelBuilder.Entity("SIGA.Domain.Entities.VPN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConcessaoId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Descricao");

                    b.Property<short>("EmpresaVPNId")
                        .HasColumnType("SMALLINT");

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

                    b.HasIndex("ConcessaoId");

                    b.HasIndex("EmpresaVPNId");

                    b.ToTable("VPN", (string)null);
                });

            modelBuilder.Entity("ConcessaoProjeto", b =>
                {
                    b.HasOne("SIGA.Domain.Entities.Concessao", null)
                        .WithMany()
                        .HasForeignKey("ConcessaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ConcessaoProjeto_ConcessaoId");

                    b.HasOne("SIGA.Domain.Entities.Projeto", null)
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ConcessaoProjeto_ProjetoId");
                });

            modelBuilder.Entity("FuncionarioAcesso", b =>
                {
                    b.HasOne("SIGA.Domain.Entities.Acesso", null)
                        .WithMany()
                        .HasForeignKey("AcessoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FuncionarioAcesso_AcessoId");

                    b.HasOne("SIGA.Domain.Entities.Funcionario", null)
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FuncionarioAcesso_FuncionarioId");
                });

            modelBuilder.Entity("FuncionarioProjeto", b =>
                {
                    b.HasOne("SIGA.Domain.Entities.Funcionario", null)
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FuncionarioProjeto_FuncionarioId");

                    b.HasOne("SIGA.Domain.Entities.Projeto", null)
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_FuncionarioProjeto_ProjetoId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("SIGA.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("SIGA.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIGA.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("SIGA.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SIGA.Domain.Entities.Acesso", b =>
                {
                    b.HasOne("SIGA.Domain.Entities.Projeto", "Projeto")
                        .WithMany("Acessos")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Acesso_ProjetoId");

                    b.HasOne("SIGA.Domain.Entities.TipoAcesso", "TipoAcesso")
                        .WithMany("Acessos")
                        .HasForeignKey("TipoAcessoId")
                        .HasConstraintName("FK_Acesso_TipoAcessoId");

                    b.HasOne("SIGA.Domain.Entities.TipoAutenticacaoAcesso", "TipoAutenticacaoAcesso")
                        .WithMany("Acessos")
                        .HasForeignKey("TipoAutenticacaoAcessoId")
                        .HasConstraintName("FK_Acesso_TipoAutenticacaoAcessoId");

                    b.HasOne("SIGA.Domain.Entities.VPN", "VPN")
                        .WithMany("Acessos")
                        .HasForeignKey("VPNId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Acesso_VPNId");

                    b.Navigation("Projeto");

                    b.Navigation("TipoAcesso");

                    b.Navigation("TipoAutenticacaoAcesso");

                    b.Navigation("VPN");
                });

            modelBuilder.Entity("SIGA.Domain.Entities.AnexoInstalacao", b =>
                {
                    b.HasOne("SIGA.Domain.Entities.ClientVPN", "ClientVPN")
                        .WithMany("AnexosInstalacao")
                        .HasForeignKey("ClientVPNId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ClientVPN_AnexoInstalacaoId");

                    b.Navigation("ClientVPN");
                });

            modelBuilder.Entity("SIGA.Domain.Entities.ClientVPN", b =>
                {
                    b.HasOne("SIGA.Domain.Entities.VPN", "VPN")
                        .WithOne("ClientVPN")
                        .HasForeignKey("SIGA.Domain.Entities.ClientVPN", "VPNId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ClientVPN_VPNId");

                    b.Navigation("VPN");
                });

            modelBuilder.Entity("SIGA.Domain.Entities.Concessao", b =>
                {
                    b.HasOne("SIGA.Domain.Entities.Grupo", "Grupo")
                        .WithMany("Concessoes")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Grupo_ConcessaoId");

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("SIGA.Domain.Entities.Funcionario", b =>
                {
                    b.HasOne("SIGA.Domain.Entities.Equipe", "Equipe")
                        .WithMany("Funcionarios")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Funcionario_EquipeId");

                    b.HasOne("SIGA.Domain.Entities.ApplicationUser", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SIGA.Domain.Entities.VPN", b =>
                {
                    b.HasOne("SIGA.Domain.Entities.Concessao", "Concessao")
                        .WithMany("VPNs")
                        .HasForeignKey("ConcessaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_VPN_ConcessaoVPNId");

                    b.HasOne("SIGA.Domain.Entities.EmpresaVPN", "EmpresaVPN")
                        .WithMany("VPNs")
                        .HasForeignKey("EmpresaVPNId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_VPN_EmpresaVPNId");

                    b.Navigation("Concessao");

                    b.Navigation("EmpresaVPN");
                });

            modelBuilder.Entity("SIGA.Domain.Entities.ClientVPN", b =>
                {
                    b.Navigation("AnexosInstalacao");
                });

            modelBuilder.Entity("SIGA.Domain.Entities.Concessao", b =>
                {
                    b.Navigation("VPNs");
                });

            modelBuilder.Entity("SIGA.Domain.Entities.EmpresaVPN", b =>
                {
                    b.Navigation("VPNs");
                });

            modelBuilder.Entity("SIGA.Domain.Entities.Equipe", b =>
                {
                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("SIGA.Domain.Entities.Grupo", b =>
                {
                    b.Navigation("Concessoes");
                });

            modelBuilder.Entity("SIGA.Domain.Entities.Projeto", b =>
                {
                    b.Navigation("Acessos");
                });

            modelBuilder.Entity("SIGA.Domain.Entities.TipoAcesso", b =>
                {
                    b.Navigation("Acessos");
                });

            modelBuilder.Entity("SIGA.Domain.Entities.TipoAutenticacaoAcesso", b =>
                {
                    b.Navigation("Acessos");
                });

            modelBuilder.Entity("SIGA.Domain.Entities.VPN", b =>
                {
                    b.Navigation("Acessos");

                    b.Navigation("ClientVPN")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
