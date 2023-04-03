using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dj_actionlayer.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_lesson_note",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserLessonCheckpointId = table.Column<int>(type: "int", nullable: false),
                    NoteTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_lesson_note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_lesson_note_user_lesson_checkpoint_UserLessonCheckpointId",
                        column: x => x.UserLessonCheckpointId,
                        principalTable: "user_lesson_checkpoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_lesson_note_UserLessonCheckpointId",
                table: "user_lesson_note",
                column: "UserLessonCheckpointId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_lesson_note");
        }
    }
}
