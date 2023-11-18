using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIGA.Infra.Migrations
{
    /// <inheritdoc />
    public partial class _2000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaVPN",
                columns: table => new
                {
                    Id = table.Column<short>(type: "SMALLINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEmpresa = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaVPN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: false),
                    PasswordHash = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    UF = table.Column<string>(type: "CHAR(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Sigla = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Squad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAcesso",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "TINYINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAcesso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAutenticacaoAcesso",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    NomeAppAutenticacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAutenticacaoAcesso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Concessao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    NomeAbreviado = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: false),
                    UF = table.Column<string>(type: "CHAR(2)", maxLength: 2, nullable: false),
                    GrupoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concessao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grupo_ConcessaoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioProjeto",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioProjeto", x => new { x.FuncionarioId, x.ProjetoId });
                    table.ForeignKey(
                        name: "FK_FuncionarioProjeto_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionarioProjeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioSquad",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    SquadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioSquad", x => new { x.FuncionarioId, x.SquadId });
                    table.ForeignKey(
                        name: "FK_FuncionarioSquad_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionarioSquad_SquadId",
                        column: x => x.SquadId,
                        principalTable: "Squad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcessaoProjeto",
                columns: table => new
                {
                    ConcessaoId = table.Column<int>(type: "int", nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcessaoProjeto", x => new { x.ConcessaoId, x.ProjetoId });
                    table.ForeignKey(
                        name: "FK_ConcessaoProjeto_ConcessaoId",
                        column: x => x.ConcessaoId,
                        principalTable: "Concessao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConcessaoProjeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VPN",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Host = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Port = table.Column<short>(type: "SMALLINT", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: false),
                    EmpresaVPNId = table.Column<short>(type: "SMALLINT", nullable: false),
                    ConcessaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VPN", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_VPN_ConcessaoVPNId",
                        column: x => x.ConcessaoId,
                        principalTable: "Concessao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_VPN_EmpresaVPNId",
                        column: x => x.EmpresaVPNId,
                        principalTable: "EmpresaVPN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acesso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR(35)", maxLength: 35, nullable: false),
                    Expiracao = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    DataExpiracao = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    Autenticacao = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    AcessoSimultaneo = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    QtdMaximaAcessoSimultaneo = table.Column<byte>(type: "TINYINT", nullable: false, defaultValue: (byte)0),
                    BlAtivo = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    AcessoForaDoServidor = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    TipoAcessoId = table.Column<byte>(type: "TINYINT", nullable: true),
                    TipoAutenticacaoAcessoId = table.Column<byte>(type: "tinyint", nullable: true),
                    VPNId = table.Column<int>(type: "int", nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acesso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acesso_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acesso_TipoAcessoId",
                        column: x => x.TipoAcessoId,
                        principalTable: "TipoAcesso",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Acesso_TipoAutenticacaoAcessoId",
                        column: x => x.TipoAutenticacaoAcessoId,
                        principalTable: "TipoAutenticacaoAcesso",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Acesso_VPNId",
                        column: x => x.VPNId,
                        principalTable: "VPN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientVPN",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    LinkDownload = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    Versao = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    DescricaoInstalacao = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    VPNId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientVPN", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientVPN_VPNId",
                        column: x => x.VPNId,
                        principalTable: "VPN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioAcesso",
                columns: table => new
                {
                    AcessoId = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioAcesso", x => new { x.AcessoId, x.FuncionarioId });
                    table.ForeignKey(
                        name: "FK_FuncionarioAcesso_AcessoId",
                        column: x => x.AcessoId,
                        principalTable: "Acesso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionarioAcesso_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnexoInstalacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caminho = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    ClientVPNId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnexoInstalacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientVPN_AnexoInstalacaoId",
                        column: x => x.ClientVPNId,
                        principalTable: "ClientVPN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projeto",
                columns: new[] { "Id", "Nome", "Sigla" },
                values: new object[,]
                {
                    { 1, "SUITS", "SUITS" },
                    { 2, "TOR", "TOR" },
                    { 3, "SIR", "SIR" },
                    { 4, "SAGA", "SAGA" },
                    { 5, "FADAMY PAY", "FPAY" }
                });

            migrationBuilder.InsertData(
                table: "Squad",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "TOR" },
                    { 3, "SUITS" },
                    { 4, "SIR" },
                    { 5, "SAGA" },
                    { 6, "Arrecadacao" },
                    { 7, "Coordenacao" }
                });

            migrationBuilder.InsertData(
                table: "TipoAcesso",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { (byte)1, "Database" },
                    { (byte)2, "Server" },
                    { (byte)3, "VPN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acesso_ProjetoId",
                table: "Acesso",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Acesso_TipoAcessoId",
                table: "Acesso",
                column: "TipoAcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Acesso_TipoAutenticacaoAcessoId",
                table: "Acesso",
                column: "TipoAutenticacaoAcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Acesso_VPNId",
                table: "Acesso",
                column: "VPNId");

            migrationBuilder.CreateIndex(
                name: "IX_AnexoInstalacao_ClientVPNId",
                table: "AnexoInstalacao",
                column: "ClientVPNId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClientVPN_VPNId",
                table: "ClientVPN",
                column: "VPNId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Concessao_GrupoId",
                table: "Concessao",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcessaoProjeto_ProjetoId",
                table: "ConcessaoProjeto",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_Email",
                table: "Funcionario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_Login",
                table: "Funcionario",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioAcesso_FuncionarioId",
                table: "FuncionarioAcesso",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioProjeto_ProjetoId",
                table: "FuncionarioProjeto",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioSquad_SquadId",
                table: "FuncionarioSquad",
                column: "SquadId");

            migrationBuilder.CreateIndex(
                name: "IX_VPN_ConcessaoId",
                table: "VPN",
                column: "ConcessaoId");

            migrationBuilder.CreateIndex(
                name: "IX_VPN_EmpresaVPNId",
                table: "VPN",
                column: "EmpresaVPNId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnexoInstalacao");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ConcessaoProjeto");

            migrationBuilder.DropTable(
                name: "FuncionarioAcesso");

            migrationBuilder.DropTable(
                name: "FuncionarioProjeto");

            migrationBuilder.DropTable(
                name: "FuncionarioSquad");

            migrationBuilder.DropTable(
                name: "ClientVPN");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Acesso");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Squad");

            migrationBuilder.DropTable(
                name: "Projeto");

            migrationBuilder.DropTable(
                name: "TipoAcesso");

            migrationBuilder.DropTable(
                name: "TipoAutenticacaoAcesso");

            migrationBuilder.DropTable(
                name: "VPN");

            migrationBuilder.DropTable(
                name: "Concessao");

            migrationBuilder.DropTable(
                name: "EmpresaVPN");

            migrationBuilder.DropTable(
                name: "Grupo");
        }
    }
}
