using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task5.Migrations
{
    public partial class DataAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Letter", "Number" },
                values: new object[,]
                {
                    { 1, "A", (byte)11 },
                    { 2, "B", (byte)10 },
                    { 3, "C", (byte)9 },
                    { 4, "D", (byte)8 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Math" },
                    { 2, "Biology" },
                    { 3, "Chemistry" },
                    { 4, "Phisics" }
                });

            migrationBuilder.InsertData(
                table: "ClassSubject",
                columns: new[] { "ClassesId", "SubjectsId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "ClassId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Gomel", 1, "Ivan", "Ivanov", "375293522222" },
                    { 2, "Minsk", 2, "Vasya", "Vasiliev", "375293522223" },
                    { 3, "Grodno", 3, "Kostya", "Kostilev", "375293521223" },
                    { 4, "Gomel", 4, "Max", "Maxov", "375293511223" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassSubject",
                keyColumns: new[] { "ClassesId", "SubjectsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ClassSubject",
                keyColumns: new[] { "ClassesId", "SubjectsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ClassSubject",
                keyColumns: new[] { "ClassesId", "SubjectsId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ClassSubject",
                keyColumns: new[] { "ClassesId", "SubjectsId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
