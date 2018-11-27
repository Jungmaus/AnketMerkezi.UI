using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnketMerkezi.Data.Migrations
{
    public partial class Ferihaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupportRequests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    SubjectType = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreaterWebUserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SupportRequests_Users_CreaterWebUserID",
                        column: x => x.CreaterWebUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserOrders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddDate = table.Column<DateTime>(nullable: false),
                    AccountType = table.Column<int>(nullable: false),
                    DayCount = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserOrders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupportRequestMessages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddDate = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(maxLength: 700, nullable: false),
                    SupportRequestID = table.Column<int>(nullable: false),
                    WebUserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportRequestMessages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SupportRequestMessages_SupportRequests_SupportRequestID",
                        column: x => x.SupportRequestID,
                        principalTable: "SupportRequests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportRequestMessages_Users_WebUserID",
                        column: x => x.WebUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupportRequestMessageDocuments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddDate = table.Column<DateTime>(nullable: false),
                    FileName = table.Column<string>(nullable: false),
                    FilePath = table.Column<string>(nullable: false),
                    SupportRequestMessageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportRequestMessageDocuments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SupportRequestMessageDocuments_SupportRequestMessages_SupportRequestMessageID",
                        column: x => x.SupportRequestMessageID,
                        principalTable: "SupportRequestMessages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequestMessageDocuments_SupportRequestMessageID",
                table: "SupportRequestMessageDocuments",
                column: "SupportRequestMessageID");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequestMessages_SupportRequestID",
                table: "SupportRequestMessages",
                column: "SupportRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequestMessages_WebUserID",
                table: "SupportRequestMessages",
                column: "WebUserID");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_CreaterWebUserID",
                table: "SupportRequests",
                column: "CreaterWebUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_UserID",
                table: "UserOrders",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupportRequestMessageDocuments");

            migrationBuilder.DropTable(
                name: "UserOrders");

            migrationBuilder.DropTable(
                name: "SupportRequestMessages");

            migrationBuilder.DropTable(
                name: "SupportRequests");
        }
    }
}
