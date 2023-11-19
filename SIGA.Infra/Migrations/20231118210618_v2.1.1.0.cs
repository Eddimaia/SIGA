using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIGA.Infra.Migrations
{
    /// <inheritdoc />
    public partial class v2110 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.CreateTable(
                name: "IdentityRole<byte>",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole<byte>");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
