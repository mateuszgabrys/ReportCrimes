using Microsoft.EntityFrameworkCore.Migrations;

namespace LawEnforcementAPI.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LawEnforcements",
                columns: new[] { "LawEnforcementId", "RankOfLawEnforcement" },
                values: new object[] { 1, "Police" });

            migrationBuilder.InsertData(
                table: "LawEnforcements",
                columns: new[] { "LawEnforcementId", "RankOfLawEnforcement" },
                values: new object[] { 2, "Officer" });

            migrationBuilder.InsertData(
                table: "LawEnforcements",
                columns: new[] { "LawEnforcementId", "RankOfLawEnforcement" },
                values: new object[] { 3, "Sherif" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LawEnforcements",
                keyColumn: "LawEnforcementId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LawEnforcements",
                keyColumn: "LawEnforcementId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LawEnforcements",
                keyColumn: "LawEnforcementId",
                keyValue: 3);
        }
    }
}
