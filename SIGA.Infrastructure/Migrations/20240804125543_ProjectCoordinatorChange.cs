using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProjectCoordinatorChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoordinatorProject_ApplicationUser",
                table: "CoordinatorProject");

            migrationBuilder.DropForeignKey(
                name: "FK_CoordinatorProject_Project",
                table: "CoordinatorProject");

            migrationBuilder.DropForeignKey(
                name: "FK_CoordinatorProject_Project_ProjectId1",
                table: "CoordinatorProject");

            migrationBuilder.DropIndex(
                name: "IX_CoordinatorProject_ProjectId1",
                table: "CoordinatorProject");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "CoordinatorProject");

            migrationBuilder.AddColumn<int>(
                name: "CoordinatorId",
                table: "Project",
                type: "INT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CoordinatorProject",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CoordinatorId",
                table: "Project",
                column: "CoordinatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoordinatorProject_ApplicationUser_ApplicationUserId",
                table: "CoordinatorProject",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoordinatorProject_Project_ProjectId",
                table: "CoordinatorProject",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_CoordinatorId",
                table: "Project",
                column: "CoordinatorId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.DropTable(name: "CoordinatorProject");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoordinatorProject_ApplicationUser_ApplicationUserId",
                table: "CoordinatorProject");

            migrationBuilder.DropForeignKey(
                name: "FK_CoordinatorProject_Project_ProjectId",
                table: "CoordinatorProject");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_CoordinatorId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_CoordinatorId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CoordinatorId",
                table: "Project");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CoordinatorProject",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId1",
                table: "CoordinatorProject",
                type: "INT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoordinatorProject_ProjectId1",
                table: "CoordinatorProject",
                column: "ProjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CoordinatorProject_ApplicationUser",
                table: "CoordinatorProject",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoordinatorProject_Project",
                table: "CoordinatorProject",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoordinatorProject_Project_ProjectId1",
                table: "CoordinatorProject",
                column: "ProjectId1",
                principalTable: "Project",
                principalColumn: "Id");
        }
    }
}
