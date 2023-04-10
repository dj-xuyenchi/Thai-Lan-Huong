using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dj_actionlayer.Migrations
{
    public partial class create1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentCount",
                table: "post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "PostAvatar",
                table: "post",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PostMiniAvatar",
                table: "post",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentCount",
                table: "post");

            migrationBuilder.DropColumn(
                name: "PostAvatar",
                table: "post");

            migrationBuilder.DropColumn(
                name: "PostMiniAvatar",
                table: "post");
        }
    }
}
