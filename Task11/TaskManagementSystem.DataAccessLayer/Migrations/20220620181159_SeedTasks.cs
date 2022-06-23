using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.DataAccessLayer.Migrations
{
    public partial class SeedTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6e77333e-010d-4943-aa6c-b82352031611");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "dad524ff-4d1d-4018-9496-e3156eb4fd48");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "d686e175-7615-48e4-a4aa-27a776d22dc3");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "7eb552a8-2ef3-4f47-87c6-1b914736ab9d");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleEntityId", "SecurityStamp", "TwoFactorEnabled", "FullName" },
                values: new object[,]
                {
                    { 1, 0, "496b8d7f-c6e2-4022-a5fd-26f932f78c4c", "ivan@gmail.com", false, false, null, null, null, "ivanivan", null, null, false, null, null, false, "Ivan Ivanov" },
                    { 2, 0, "1d49d2c0-1b00-4b8a-812d-d1811f4b8d93", "vasya@gmail.com", false, false, null, null, null, "123", null, null, false, null, null, false, "Vasya Vasiliev" },
                    { 3, 0, "50cf655e-84d5-434e-bd86-1af32704b0b0", "petya@gmail.com", false, false, null, null, null, "qwerty", null, null, false, null, null, false, "Petya Petrov" },
                    { 4, 0, "47d72839-9224-4aeb-8325-06c4d0438c2d", "Katya@gmail.com", false, false, null, null, null, "qwerty123", null, null, false, null, null, false, "Katya Vasilenko" },
                    { 5, 0, "7345646f-5bb6-4086-8124-398c8db1b79c", "vika@gmail.com", false, false, null, null, null, "qwerty111", null, null, false, null, null, false, "Vika Viktorieva" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 1, 4 },
                    { 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatorId", "Description", "Name", "PerformerId", "Status" },
                values: new object[,]
                {
                    { 1, 1, "", "Create", 2, 0 },
                    { 2, 2, "", "Push", 3, 0 },
                    { 3, 3, "", "Delete", 4, 0 },
                    { 4, 4, "", "Read", 5, 0 },
                    { 5, 5, "", "Edit", 1, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "55f490ab-792e-45ad-b6f4-5e534340bbef");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "44c928df-1954-4de3-8f50-099fc6978dc3");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f69795af-cd11-43ae-8c94-1d947102253c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "bfa637f8-8bf2-422a-bc3d-1ce3ed711541");
        }
    }
}
