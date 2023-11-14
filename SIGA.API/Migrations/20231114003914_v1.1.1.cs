using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGA.API.Migrations
{
    /// <inheritdoc />
    public partial class v111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientVPN_VPNId",
                table: "VPN");

            migrationBuilder.DropIndex(
                name: "IX_VPN_VPNId",
                table: "VPN");

            migrationBuilder.DropColumn(
                name: "VPNId",
                table: "VPN");

            migrationBuilder.AddColumn<int>(
                name: "VPNId",
                table: "ClientVPN",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClientVPN_VPNId",
                table: "ClientVPN",
                column: "VPNId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientVPN_VPNId",
                table: "ClientVPN",
                column: "VPNId",
                principalTable: "VPN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientVPN_VPNId",
                table: "ClientVPN");

            migrationBuilder.DropIndex(
                name: "IX_ClientVPN_VPNId",
                table: "ClientVPN");

            migrationBuilder.DropColumn(
                name: "VPNId",
                table: "ClientVPN");

            migrationBuilder.AddColumn<int>(
                name: "VPNId",
                table: "VPN",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VPN_VPNId",
                table: "VPN",
                column: "VPNId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientVPN_VPNId",
                table: "VPN",
                column: "VPNId",
                principalTable: "ClientVPN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
