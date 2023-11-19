using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIGA.Infra.Migrations
{
    /// <inheritdoc />
    public partial class v2140 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16c62d81-281b-43ac-acd3-1398511f5350", null, "Arrecadacao", null },
                    { "2dfea080-0df4-446a-b16d-b92a8c88b39c", null, "SAGA", null },
                    { "45e50187-6b3e-4831-9511-9b1cdd940b37", null, "SUITS", null },
                    { "47460b9d-fdcc-4056-8d1f-45ea876ed94e", null, "SIR", null },
                    { "5894ca87-4d3a-4de1-b67e-87cb0585dfe2", null, "Coordenacao", null },
                    { "a694ce2c-d3ee-4e5d-b3b4-d06ea17af1dc", null, "TOR", null },
                    { "e1d9cc3f-a856-4168-ad7c-5ef845dc7fc4", null, "Admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16c62d81-281b-43ac-acd3-1398511f5350");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dfea080-0df4-446a-b16d-b92a8c88b39c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45e50187-6b3e-4831-9511-9b1cdd940b37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47460b9d-fdcc-4056-8d1f-45ea876ed94e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5894ca87-4d3a-4de1-b67e-87cb0585dfe2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a694ce2c-d3ee-4e5d-b3b4-d06ea17af1dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1d9cc3f-a856-4168-ad7c-5ef845dc7fc4");

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
    }
}
