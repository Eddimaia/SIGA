using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SIGA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoNomeTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Login = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    UserName = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "DATETIME2(0)", nullable: false),
                    LastLoginDate = table.Column<DateTimeOffset>(type: "DATETIMEOFFSET", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "DATETIMEOFFSET", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "BIT", nullable: false),
                    IsPhoneNumberConfirmed = table.Column<bool>(type: "BIT", nullable: false),
                    IsEmployed = table.Column<bool>(type: "BIT", nullable: false),
                    IsProjectCoordinator = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Acronym = table.Column<string>(type: "VARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatabaseType",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "TINYINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Acronym = table.Column<string>(type: "VARCHAR(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vpn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Host = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Version = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    IconPath = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Domain = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ClientId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vpn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VPN_CLIENT",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DatabaseAccess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    ClientId = table.Column<int>(type: "INT", nullable: false),
                    DataBaseTypeId = table.Column<byte>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatabseAccess_Client",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DatabseAccess_DatabaseType",
                        column: x => x.DataBaseTypeId,
                        principalTable: "DatabaseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<int>(type: "INT", nullable: false),
                    ProjectId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProject_ApplicationUser",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProject_Project",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "INT", nullable: false),
                    ProjectId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientProject_Client",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientProject_Project",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoordinatorProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<int>(type: "INT", nullable: false),
                    ProjectId = table.Column<int>(type: "INT", nullable: false),
                    ProjectId1 = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoordinatorProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoordinatorProject_ApplicationUser",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoordinatorProject_Project",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoordinatorProject_Project_ProjectId1",
                        column: x => x.ProjectId1,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<int>(type: "INT", nullable: false),
                    ClaimId = table.Column<int>(type: "INT", nullable: false),
                    RolesId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUserClaim_Role_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClaim_ApplicationUser",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClaim_Claim",
                        column: x => x.ClaimId,
                        principalTable: "Claim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<int>(type: "INT", nullable: false),
                    RoleId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleMapper_ApplicationUser",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleMapper_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VpnAccess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "INT", nullable: false),
                    VpnId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VpnAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VpnAccess_ApplicationUser",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VpnAccess_Vpn",
                        column: x => x.VpnId,
                        principalTable: "Vpn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DatabaseAcessProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatabaseAccessId = table.Column<int>(type: "INT", nullable: false),
                    ProjectId = table.Column<int>(type: "INT", nullable: false),
                    ProjectId1 = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseAcessProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatabaseAcessProject_DatabaseAccess",
                        column: x => x.DatabaseAccessId,
                        principalTable: "DatabaseAccess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatabaseAcessProject_Project",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatabaseAcessProject_Project_ProjectId1",
                        column: x => x.ProjectId1,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DatabaseType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, "SqlServer" },
                    { (byte)2, "PostgreSql" },
                    { (byte)3, "MySql" },
                    { (byte)4, "OracleDb" },
                    { (byte)6, "MongoDb" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserClaim_ApplicationUserId",
                table: "ApplicationUserClaim",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserClaim_ClaimId",
                table: "ApplicationUserClaim",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserClaim_RolesId",
                table: "ApplicationUserClaim",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserProject_ApplicationUserId",
                table: "ApplicationUserProject",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserProject_ProjectId",
                table: "ApplicationUserProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRole_ApplicationUserId",
                table: "ApplicationUserRole",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRole_RoleId",
                table: "ApplicationUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientProject_ClientId",
                table: "ClientProject",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientProject_ProjectId",
                table: "ClientProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CoordinatorProject_ApplicationUserId",
                table: "CoordinatorProject",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CoordinatorProject_ProjectId",
                table: "CoordinatorProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CoordinatorProject_ProjectId1",
                table: "CoordinatorProject",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseAccess_ClientId",
                table: "DatabaseAccess",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseAccess_DataBaseTypeId",
                table: "DatabaseAccess",
                column: "DataBaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseAcessProject_DatabaseAccessId",
                table: "DatabaseAcessProject",
                column: "DatabaseAccessId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseAcessProject_ProjectId",
                table: "DatabaseAcessProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseAcessProject_ProjectId1",
                table: "DatabaseAcessProject",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_Vpn_ClientId",
                table: "Vpn",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_VpnAccess_ApplicationUserId",
                table: "VpnAccess",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VpnAccess_VpnId",
                table: "VpnAccess",
                column: "VpnId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserClaim");

            migrationBuilder.DropTable(
                name: "ApplicationUserProject");

            migrationBuilder.DropTable(
                name: "ApplicationUserRole");

            migrationBuilder.DropTable(
                name: "ClientProject");

            migrationBuilder.DropTable(
                name: "CoordinatorProject");

            migrationBuilder.DropTable(
                name: "DatabaseAcessProject");

            migrationBuilder.DropTable(
                name: "VpnAccess");

            migrationBuilder.DropTable(
                name: "Claim");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "DatabaseAccess");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Vpn");

            migrationBuilder.DropTable(
                name: "DatabaseType");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
