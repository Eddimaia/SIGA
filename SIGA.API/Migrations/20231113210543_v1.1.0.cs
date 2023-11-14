using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIGA.API.Migrations
{
    /// <inheritdoc />
    public partial class v110 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_AcessoId",
                table: "Acesso");

            migrationBuilder.DropForeignKey(
                name: "FK_VPN_AcessoId",
                table: "Acesso");

            migrationBuilder.DropForeignKey(
                name: "FK_VPN_ClientId",
                table: "VPN");

            migrationBuilder.DropForeignKey(
                name: "FK_VPN_ConcessaoId",
                table: "VPN");

            migrationBuilder.DropIndex(
                name: "IX_VPN_ClientVPNId",
                table: "VPN");

            migrationBuilder.DropIndex(
                name: "IX_VPN_ConcessaoId",
                table: "VPN");

            migrationBuilder.DropColumn(
                name: "AcessoForaDoServidor",
                table: "VPN");

            migrationBuilder.DropColumn(
                name: "TipoAcesso",
                table: "Acesso");

            migrationBuilder.RenameColumn(
                name: "ConcessaoId",
                table: "VPN",
                newName: "VPNId");

            migrationBuilder.RenameColumn(
                name: "ClientVPNId",
                table: "VPN",
                newName: "ConcessaoVPNId");

            migrationBuilder.AddColumn<short>(
                name: "EmpresaVPNId",
                table: "VPN",
                type: "SMALLINT",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<bool>(
                name: "Expiracao",
                table: "Acesso",
                type: "BIT",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "AcessoForaDoServidor",
                table: "Acesso",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AcessoSimultaneo",
                table: "Acesso",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Autenticacao",
                table: "Acesso",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BlAtivo",
                table: "Acesso",
                type: "BIT",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<byte>(
                name: "QtdMaximaAcessoSimultaneo",
                table: "Acesso",
                type: "TINYINT",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "TipoAcessoId",
                table: "Acesso",
                type: "TINYINT",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "TipoAutenticacaoAcessoId",
                table: "Acesso",
                type: "tinyint",
                nullable: true);

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
                name: "IX_VPN_ConcessaoVPNId",
                table: "VPN",
                column: "ConcessaoVPNId");

            migrationBuilder.CreateIndex(
                name: "IX_VPN_EmpresaVPNId",
                table: "VPN",
                column: "EmpresaVPNId");

            migrationBuilder.CreateIndex(
                name: "IX_VPN_VPNId",
                table: "VPN",
                column: "VPNId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acesso_TipoAcessoId",
                table: "Acesso",
                column: "TipoAcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Acesso_TipoAutenticacaoAcessoId",
                table: "Acesso",
                column: "TipoAutenticacaoAcessoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acesso_ProjetoId",
                table: "Acesso",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Acesso_TipoAcessoId",
                table: "Acesso",
                column: "TipoAcessoId",
                principalTable: "TipoAcesso",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Acesso_TipoAutenticacaoAcessoId",
                table: "Acesso",
                column: "TipoAutenticacaoAcessoId",
                principalTable: "TipoAutenticacaoAcesso",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Acesso_VPNId",
                table: "Acesso",
                column: "VPNId",
                principalTable: "VPN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientVPN_VPNId",
                table: "VPN",
                column: "VPNId",
                principalTable: "ClientVPN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Fk_VPN_ConcessaoVPNId",
                table: "VPN",
                column: "ConcessaoVPNId",
                principalTable: "Concessao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "Fk_VPN_EmpresaVPNId",
                table: "VPN",
                column: "EmpresaVPNId",
                principalTable: "EmpresaVPN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acesso_ProjetoId",
                table: "Acesso");

            migrationBuilder.DropForeignKey(
                name: "FK_Acesso_TipoAcessoId",
                table: "Acesso");

            migrationBuilder.DropForeignKey(
                name: "FK_Acesso_TipoAutenticacaoAcessoId",
                table: "Acesso");

            migrationBuilder.DropForeignKey(
                name: "FK_Acesso_VPNId",
                table: "Acesso");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientVPN_VPNId",
                table: "VPN");

            migrationBuilder.DropForeignKey(
                name: "Fk_VPN_ConcessaoVPNId",
                table: "VPN");

            migrationBuilder.DropForeignKey(
                name: "Fk_VPN_EmpresaVPNId",
                table: "VPN");

            migrationBuilder.DropTable(
                name: "EmpresaVPN");

            migrationBuilder.DropTable(
                name: "TipoAcesso");

            migrationBuilder.DropTable(
                name: "TipoAutenticacaoAcesso");

            migrationBuilder.DropIndex(
                name: "IX_VPN_ConcessaoVPNId",
                table: "VPN");

            migrationBuilder.DropIndex(
                name: "IX_VPN_EmpresaVPNId",
                table: "VPN");

            migrationBuilder.DropIndex(
                name: "IX_VPN_VPNId",
                table: "VPN");

            migrationBuilder.DropIndex(
                name: "IX_Acesso_TipoAcessoId",
                table: "Acesso");

            migrationBuilder.DropIndex(
                name: "IX_Acesso_TipoAutenticacaoAcessoId",
                table: "Acesso");

            migrationBuilder.DropColumn(
                name: "EmpresaVPNId",
                table: "VPN");

            migrationBuilder.DropColumn(
                name: "AcessoForaDoServidor",
                table: "Acesso");

            migrationBuilder.DropColumn(
                name: "AcessoSimultaneo",
                table: "Acesso");

            migrationBuilder.DropColumn(
                name: "Autenticacao",
                table: "Acesso");

            migrationBuilder.DropColumn(
                name: "BlAtivo",
                table: "Acesso");

            migrationBuilder.DropColumn(
                name: "QtdMaximaAcessoSimultaneo",
                table: "Acesso");

            migrationBuilder.DropColumn(
                name: "TipoAcessoId",
                table: "Acesso");

            migrationBuilder.DropColumn(
                name: "TipoAutenticacaoAcessoId",
                table: "Acesso");

            migrationBuilder.RenameColumn(
                name: "VPNId",
                table: "VPN",
                newName: "ConcessaoId");

            migrationBuilder.RenameColumn(
                name: "ConcessaoVPNId",
                table: "VPN",
                newName: "ClientVPNId");

            migrationBuilder.AddColumn<bool>(
                name: "AcessoForaDoServidor",
                table: "VPN",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Expiracao",
                table: "Acesso",
                type: "BIT",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "TipoAcesso",
                table: "Acesso",
                type: "TINYINT",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_VPN_ClientVPNId",
                table: "VPN",
                column: "ClientVPNId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VPN_ConcessaoId",
                table: "VPN",
                column: "ConcessaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_AcessoId",
                table: "Acesso",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VPN_AcessoId",
                table: "Acesso",
                column: "VPNId",
                principalTable: "VPN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VPN_ClientId",
                table: "VPN",
                column: "ClientVPNId",
                principalTable: "ClientVPN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VPN_ConcessaoId",
                table: "VPN",
                column: "ConcessaoId",
                principalTable: "Concessao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
