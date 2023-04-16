using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dj_actionlayer.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpecOutput",
                table: "practice_lesson",
                newName: "ExpectOutput");

            migrationBuilder.AddColumn<string>(
                name: "BeginCodeMethod",
                table: "practice_lesson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CallTestCode",
                table: "practice_lesson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeginCodeMethod",
                table: "practice_lesson");

            migrationBuilder.DropColumn(
                name: "CallTestCode",
                table: "practice_lesson");

            migrationBuilder.RenameColumn(
                name: "ExpectOutput",
                table: "practice_lesson",
                newName: "ExpecOutput");
        }
    }
}
