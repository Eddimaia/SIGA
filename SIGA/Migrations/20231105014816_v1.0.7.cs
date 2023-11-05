using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGA.API.Migrations
{
    /// <inheritdoc />
    public partial class v107 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_Login",
                table: "Funcionario",
                column: "Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Funcionario_Login",
                table: "Funcionario");
        }
    }
}
