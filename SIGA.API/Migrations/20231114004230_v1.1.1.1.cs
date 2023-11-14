using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGA.API.Migrations
{
    /// <inheritdoc />
    public partial class v1111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConcessaoVPNId",
                table: "VPN",
                newName: "ConcessaoId");

            migrationBuilder.RenameIndex(
                name: "IX_VPN_ConcessaoVPNId",
                table: "VPN",
                newName: "IX_VPN_ConcessaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConcessaoId",
                table: "VPN",
                newName: "ConcessaoVPNId");

            migrationBuilder.RenameIndex(
                name: "IX_VPN_ConcessaoId",
                table: "VPN",
                newName: "IX_VPN_ConcessaoVPNId");
        }
    }
}
