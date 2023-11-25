using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizAppBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class DBSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Description", "Title", "UserId" },
                values: new object[] { new Guid("9cac93b0-73b4-4a5b-a4dd-41fbd4e7796c"), "Test your knowledge about world politics.", "Politics Quiz", "e1d6aa61-4d5e-4ebe-b483-1ec222f9adad" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("9cac93b0-73b4-4a5b-a4dd-41fbd4e7796c"));
        }
    }
}
