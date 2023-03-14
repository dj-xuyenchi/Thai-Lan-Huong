using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dj_actionlayer.Migrations
{
    public partial class createu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_user_UserRoleId",
                table: "user",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_user_role_UserRoleId",
                table: "user",
                column: "UserRoleId",
                principalTable: "user_role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_user_role_UserRoleId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_UserRoleId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "user");
        }
    }
}
