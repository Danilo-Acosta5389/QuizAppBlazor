using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizAppBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUserTextInputfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserTextInput",
                table: "Questions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserTextInput",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
