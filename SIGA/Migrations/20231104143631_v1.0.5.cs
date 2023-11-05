using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGA.API.Migrations
{
    /// <inheritdoc />
    public partial class v105 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CHAR",
                table: "Concessao",
                newName: "UF");

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                table: "Concessao",
                type: "CHAR(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UF",
                table: "Concessao",
                newName: "CHAR");

            migrationBuilder.AlterColumn<string>(
                name: "CHAR",
                table: "Concessao",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(2)",
                oldMaxLength: 2);
        }
    }
}
