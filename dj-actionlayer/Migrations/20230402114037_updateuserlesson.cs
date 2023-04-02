using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dj_actionlayer.Migrations
{
    public partial class updateuserlesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_lesson_checkpoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    OpenLessonDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_lesson_checkpoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_lesson_checkpoint_lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_lesson_checkpoint_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_lesson_checkpoint_LessonId",
                table: "user_lesson_checkpoint",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_user_lesson_checkpoint_UserId",
                table: "user_lesson_checkpoint",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_lesson_checkpoint");
        }
    }
}
