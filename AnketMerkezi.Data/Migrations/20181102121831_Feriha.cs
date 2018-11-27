using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnketMerkezi.Data.Migrations
{
    public partial class Feriha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddDate = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(maxLength: 25, nullable: false),
                    Password = table.Column<string>(maxLength: 25, nullable: false),
                    AccountType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    LinkCode = table.Column<string>(maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Surveys_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Surname = table.Column<string>(maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 15, nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserDetails_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyContents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 45, nullable: false),
                    DataType = table.Column<int>(nullable: false),
                    MaxLength = table.Column<int>(nullable: true),
                    MinLength = table.Column<int>(nullable: true),
                    IsRequired = table.Column<bool>(nullable: false),
                    SurveyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyContents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SurveyContents_Surveys_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Surveys",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyVisits",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddDate = table.Column<DateTime>(nullable: false),
                    IpAdress = table.Column<string>(maxLength: 25, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    DeviceType = table.Column<int>(nullable: false),
                    SurveyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyVisits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SurveyVisits_Surveys_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Surveys",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyVisitAnswers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddDate = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(maxLength: 750, nullable: false),
                    SurveyVisitID = table.Column<int>(nullable: false),
                    SurveyContentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyVisitAnswers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SurveyVisitAnswers_SurveyContents_SurveyContentID",
                        column: x => x.SurveyContentID,
                        principalTable: "SurveyContents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyVisitAnswers_SurveyVisits_SurveyVisitID",
                        column: x => x.SurveyVisitID,
                        principalTable: "SurveyVisits",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyContents_SurveyID",
                table: "SurveyContents",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_UserID",
                table: "Surveys",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyVisitAnswers_SurveyContentID",
                table: "SurveyVisitAnswers",
                column: "SurveyContentID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyVisitAnswers_SurveyVisitID",
                table: "SurveyVisitAnswers",
                column: "SurveyVisitID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyVisits_SurveyID",
                table: "SurveyVisits",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserID",
                table: "UserDetails",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyVisitAnswers");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "SurveyContents");

            migrationBuilder.DropTable(
                name: "SurveyVisits");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
