using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIGA.Infra.Migrations
{
    /// <inheritdoc />
    public partial class v2100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionarioSquad");

            migrationBuilder.DropTable(
                name: "Squad");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_Email",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_Login",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Funcionario");

            migrationBuilder.AddColumn<byte>(
                name: "EquipeId",
                table: "Funcionario",
                type: "TINYINT",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Funcionario",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "TINYINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Equipe",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { (byte)1, "Desenvolvimento" },
                    { (byte)2, "Suporte" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { (byte)1, null, "Admin", null },
                    { (byte)2, null, "TOR", null },
                    { (byte)3, null, "SUITS", null },
                    { (byte)4, null, "SIR", null },
                    { (byte)5, null, "SAGA", null },
                    { (byte)6, null, "Arrecadacao", null },
                    { (byte)7, null, "Coordenacao", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_EquipeId",
                table: "Funcionario",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_UsuarioId",
                table: "Funcionario",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_EquipeId",
                table: "Funcionario",
                column: "EquipeId",
                principalTable: "Equipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_UsuarioId",
                table: "Funcionario",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_EquipeId",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_UsuarioId",
                table: "Funcionario");

            migrationBuilder.DropTable(
                name: "Equipe");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_EquipeId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_UsuarioId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "EquipeId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Funcionario");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Funcionario",
                type: "VARCHAR(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Funcionario",
                type: "VARCHAR(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Funcionario",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

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
                name: "IX_FuncionarioSquad_SquadId",
                table: "FuncionarioSquad",
                column: "SquadId");
        }
    }
}
