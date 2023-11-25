using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizAppBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class DBseedx3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("9cac93b0-73b4-4a5b-a4dd-41fbd4e7796c"));

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("9ce51e9d-cdba-4b3b-afcd-7f6fe5863e2e"), "Test your knowledge about countrys and citys.", "Geography Quiz", "e1d6aa61-4d5e-4ebe-b483-1ec222f9adad" },
                    { new Guid("b78f6877-6f78-449a-9393-fb7cdead3a20"), "Test your knowledge about world history.", "History Quiz", "e1d6aa61-4d5e-4ebe-b483-1ec222f9adad" },
                    { new Guid("e192cb77-44ff-4910-b820-f65e1059424d"), "Test your knowledge about world politics.", "Politics Quiz", "e1d6aa61-4d5e-4ebe-b483-1ec222f9adad" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("9ce51e9d-cdba-4b3b-afcd-7f6fe5863e2e"));

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("b78f6877-6f78-449a-9393-fb7cdead3a20"));

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("e192cb77-44ff-4910-b820-f65e1059424d"));

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Description", "Title", "UserId" },
                values: new object[] { new Guid("9cac93b0-73b4-4a5b-a4dd-41fbd4e7796c"), "Test your knowledge about world politics.", "Politics Quiz", "e1d6aa61-4d5e-4ebe-b483-1ec222f9adad" });
        }
    }
}
