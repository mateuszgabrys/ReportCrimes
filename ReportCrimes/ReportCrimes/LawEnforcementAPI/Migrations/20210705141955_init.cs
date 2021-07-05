using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LawEnforcementAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LawEnforcements",
                columns: table => new
                {
                    LawEnforcementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankOfLawEnforcement = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawEnforcements", x => x.LawEnforcementId);
                });

            migrationBuilder.CreateTable(
                name: "CrimeEvents",
                columns: table => new
                {
                    CrimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfEvent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeOfEvent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfEvent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportingPersonEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LawEnforcementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeEvents", x => x.CrimeId);
                    table.ForeignKey(
                        name: "FK_CrimeEvents_LawEnforcements_LawEnforcementId",
                        column: x => x.LawEnforcementId,
                        principalTable: "LawEnforcements",
                        principalColumn: "LawEnforcementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrimeEvents_LawEnforcementId",
                table: "CrimeEvents",
                column: "LawEnforcementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrimeEvents");

            migrationBuilder.DropTable(
                name: "LawEnforcements");
        }
    }
}
