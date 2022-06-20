using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.DataAccessLayer.Migrations
{
    public partial class Add_Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "cd26f4cb-8926-4398-b5ef-009c622f9a25", "TeamLead", "TEAMLEAD" },
                    { 2, "792c0253-0767-4cd7-acc5-daff09295771", "Senior", "SENIOR" },
                    { 3, "5d6ee575-30fa-4096-b775-4e56becd31b9", "Middle", "MIDDLE" },
                    { 4, "4e2bd1af-0420-450a-9606-3b82cba4f51d", "Junior", "JUNIOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
