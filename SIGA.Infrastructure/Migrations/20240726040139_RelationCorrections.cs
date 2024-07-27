using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelationCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserClaim_Role_RolesId",
                table: "ApplicationUserClaim");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserClaim_RolesId",
                table: "ApplicationUserClaim");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "ApplicationUserClaim");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolesId",
                table: "ApplicationUserClaim",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserClaim_RolesId",
                table: "ApplicationUserClaim",
                column: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserClaim_Role_RolesId",
                table: "ApplicationUserClaim",
                column: "RolesId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
