using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIGA.Infra.Migrations
{
    /// <inheritdoc />
    public partial class v2150 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role");

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
    }
}
