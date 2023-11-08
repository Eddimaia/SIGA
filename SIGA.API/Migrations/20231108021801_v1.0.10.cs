using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIGA.API.Migrations
{
    /// <inheritdoc />
    public partial class v1010 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"DELETE [Projeto]
                                   DBCC CHECKIDENT([Projeto], RESEED, 1)");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projeto",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projeto",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projeto",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projeto",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projeto",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
