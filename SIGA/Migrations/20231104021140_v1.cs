using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGA.API.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concessao_Grupo_GrupoId",
                table: "Concessao");

            migrationBuilder.DropForeignKey(
                name: "FK_Concessao_Projeto_ProjetoId",
                table: "Concessao");

            migrationBuilder.DropForeignKey(
                name: "FK_VPN_Concessao_ConcessaoId",
                table: "VPN");

            migrationBuilder.DropIndex(
                name: "IX_Concessao_ProjetoId",
                table: "Concessao");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "Concessao");

            migrationBuilder.RenameColumn(
                name: "UF",
                table: "Concessao",
                newName: "CHAR");

            migrationBuilder.AlterColumn<int>(
                name: "ConcessaoId",
                table: "VPN",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Projeto",
                type: "NVARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Sigla",
                table: "Projeto",
                type: "NVARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Funcionario",
                type: "NVARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Concessao",
                type: "NVARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CHAR",
                table: "Concessao",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "NomeAbreviado",
                table: "Concessao",
                type: "NVARCHAR(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_ConcessaoProjeto_ProjetoId",
                table: "ConcessaoProjeto",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupo_ConcessaoId",
                table: "Concessao",
                column: "GrupoId",
                principalTable: "Grupo",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupo_ConcessaoId",
                table: "Concessao");

            migrationBuilder.DropForeignKey(
                name: "FK_VPN_ConcessaoId",
                table: "VPN");

            migrationBuilder.DropTable(
                name: "ConcessaoProjeto");

            migrationBuilder.DropColumn(
                name: "Sigla",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "NomeAbreviado",
                table: "Concessao");

            migrationBuilder.RenameColumn(
                name: "CHAR",
                table: "Concessao",
                newName: "UF");

            migrationBuilder.AlterColumn<int>(
                name: "ConcessaoId",
                table: "VPN",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Projeto",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Concessao",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                table: "Concessao",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "Concessao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Concessao_ProjetoId",
                table: "Concessao",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Concessao_Grupo_GrupoId",
                table: "Concessao",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Concessao_Projeto_ProjetoId",
                table: "Concessao",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VPN_Concessao_ConcessaoId",
                table: "VPN",
                column: "ConcessaoId",
                principalTable: "Concessao",
                principalColumn: "Id");
        }
    }
}
