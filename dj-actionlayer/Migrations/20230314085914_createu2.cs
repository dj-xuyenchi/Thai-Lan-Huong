using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dj_actionlayer.Migrations
{
    public partial class createu2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_user_role_UserRoleId",
                table: "user");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleId",
                table: "user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserStatusId",
                table: "user",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseStatusId",
                table: "course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_UserStatusId",
                table: "user",
                column: "UserStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_course_CourseStatusId",
                table: "course",
                column: "CourseStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_course_course_status_CourseStatusId",
                table: "course",
                column: "CourseStatusId",
                principalTable: "course_status",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_user_role_UserRoleId",
                table: "user",
                column: "UserRoleId",
                principalTable: "user_role",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_user_status_UserStatusId",
                table: "user",
                column: "UserStatusId",
                principalTable: "user_status",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_course_course_status_CourseStatusId",
                table: "course");

            migrationBuilder.DropForeignKey(
                name: "FK_user_user_role_UserRoleId",
                table: "user");

            migrationBuilder.DropForeignKey(
                name: "FK_user_user_status_UserStatusId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_UserStatusId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_course_CourseStatusId",
                table: "course");

            migrationBuilder.DropColumn(
                name: "UserStatusId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "CourseStatusId",
                table: "course");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleId",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_user_user_role_UserRoleId",
                table: "user",
                column: "UserRoleId",
                principalTable: "user_role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
