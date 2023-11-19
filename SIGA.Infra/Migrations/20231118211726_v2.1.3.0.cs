using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIGA.Infra.Migrations
{
    /// <inheritdoc />
    public partial class v2130 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole<byte>");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09e65a84-7225-4f99-876c-9d30c9fd724f", null, "TOR", null },
                    { "0c301dca-cd71-411d-b81e-74339515dbe5", null, "Coordenacao", null },
                    { "35bf1432-6350-419f-8faf-bc40f12d1e1d", null, "SUITS", null },
                    { "3aa975fd-9707-41ad-bbf9-7418769a8d8e", null, "SIR", null },
                    { "9ede177a-4356-411c-ba66-309e189d95bd", null, "SAGA", null },
                    { "afdaaa44-fefb-40ac-9401-cac279795ca9", null, "Admin", null },
                    { "d62d077a-e4ff-4dec-bba7-02387cb9299e", null, "Arrecadacao", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09e65a84-7225-4f99-876c-9d30c9fd724f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c301dca-cd71-411d-b81e-74339515dbe5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35bf1432-6350-419f-8faf-bc40f12d1e1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3aa975fd-9707-41ad-bbf9-7418769a8d8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ede177a-4356-411c-ba66-309e189d95bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afdaaa44-fefb-40ac-9401-cac279795ca9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d62d077a-e4ff-4dec-bba7-02387cb9299e");

            migrationBuilder.CreateTable(
                name: "IdentityRole<byte>",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole<byte>", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole<byte>",
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
        }
    }
}
