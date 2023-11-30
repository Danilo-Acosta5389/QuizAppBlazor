using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizAppBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedLinkId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "Score");

            migrationBuilder.AddColumn<string>(
                name: "LinkId",
                table: "Score",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkId",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkId",
                table: "Score");

            migrationBuilder.DropColumn(
                name: "LinkId",
                table: "Questions");

            migrationBuilder.AddColumn<Guid>(
                name: "QuizId",
                table: "Score",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
