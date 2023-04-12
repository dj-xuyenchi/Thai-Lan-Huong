using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dj_actionlayer.Migrations
{
    public partial class updatepracetive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "practice_lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_practice_lesson_LessonId",
                table: "practice_lesson",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_practice_lesson_lesson_LessonId",
                table: "practice_lesson",
                column: "LessonId",
                principalTable: "lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_practice_lesson_lesson_LessonId",
                table: "practice_lesson");

            migrationBuilder.DropIndex(
                name: "IX_practice_lesson_LessonId",
                table: "practice_lesson");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "practice_lesson");
        }
    }
}
