using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGA.API.Migrations
{
    /// <inheritdoc />
    public partial class v101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "VPN",
                newName: "ClientVPNId");

            migrationBuilder.RenameIndex(
                name: "IX_VPN_ClientId",
                table: "VPN",
                newName: "IX_VPN_ClientVPNId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientVPNId",
                table: "VPN",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_VPN_ClientVPNId",
                table: "VPN",
                newName: "IX_VPN_ClientId");
        }
    }
}
