using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dj_actionlayer.Migrations
{
    public partial class cc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "course_level",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LevelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_level", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "course_status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "course_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lesson_check_point",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonCheckPointName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lesson_check_point", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lesson_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lesson_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "post_status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseLevelId = table.Column<int>(type: "int", nullable: true),
                    LessonCount = table.Column<int>(type: "int", nullable: false),
                    TimeLessonTotal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterCount = table.Column<int>(type: "int", nullable: false),
                    DoneCount = table.Column<int>(type: "int", nullable: false),
                    CourseStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_course_course_level_CourseLevelId",
                        column: x => x.CourseLevelId,
                        principalTable: "course_level",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_course_course_status_CourseStatusId",
                        column: x => x.CourseStatusId,
                        principalTable: "course_status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoutubeUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LessonTypeId = table.Column<int>(type: "int", nullable: true),
                    LessonCheckPointId = table.Column<int>(type: "int", nullable: true),
                    VideoTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lesson_lesson_check_point_LessonCheckPointId",
                        column: x => x.LessonCheckPointId,
                        principalTable: "lesson_check_point",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_lesson_lesson_type_LessonTypeId",
                        column: x => x.LessonTypeId,
                        principalTable: "lesson_type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAvatarPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserFacebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserFisrtName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    UserRoleId = table.Column<int>(type: "int", nullable: true),
                    UserStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "gender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_user_role_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "user_role",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_user_status_UserStatusId",
                        column: x => x.UserStatusId,
                        principalTable: "user_status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "course_course_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    CourseTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_course_type", x => x.Id);
                    table.ForeignKey(
                        name: "FK_course_course_type_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_course_course_type_course_type_CourseTypeId",
                        column: x => x.CourseTypeId,
                        principalTable: "course_type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "course_image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortNumber = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_course_image_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "course",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "comment_lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentLessonParentId = table.Column<int>(type: "int", nullable: true),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment_lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comment_lesson_comment_lesson_CommentLessonParentId",
                        column: x => x.CommentLessonParentId,
                        principalTable: "comment_lesson",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_comment_lesson_lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "lesson",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_comment_lesson_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCreateId = table.Column<int>(type: "int", nullable: true),
                    CreatePost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatePost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    PostStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_post_post_status_PostStatusId",
                        column: x => x.PostStatusId,
                        principalTable: "post_status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_post_user_UserCreateId",
                        column: x => x.UserCreateId,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "refresh_token",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refresh_token_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    isDone = table.Column<bool>(type: "bit", nullable: false),
                    ResisterDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastTimeStudyDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonePercent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_course_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_course_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "user_like_comment_lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CommentLessonId = table.Column<int>(type: "int", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_like_comment_lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_like_comment_lesson_comment_lesson_CommentLessonId",
                        column: x => x.CommentLessonId,
                        principalTable: "comment_lesson",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_like_comment_lesson_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "comment_post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentPostParentId = table.Column<int>(type: "int", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment_post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comment_post_comment_post_CommentPostParentId",
                        column: x => x.CommentPostParentId,
                        principalTable: "comment_post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_comment_post_post_PostId",
                        column: x => x.PostId,
                        principalTable: "post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_comment_post_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "user_like_post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    LikeDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_like_post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_like_post_post_PostId",
                        column: x => x.PostId,
                        principalTable: "post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_like_post_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "user_like_comment_post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CommentPostId = table.Column<int>(type: "int", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_like_comment_post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_like_comment_post_comment_post_CommentPostId",
                        column: x => x.CommentPostId,
                        principalTable: "comment_post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_like_comment_post_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_comment_lesson_CommentLessonParentId",
                table: "comment_lesson",
                column: "CommentLessonParentId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_lesson_LessonId",
                table: "comment_lesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_lesson_UserId",
                table: "comment_lesson",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_post_CommentPostParentId",
                table: "comment_post",
                column: "CommentPostParentId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_post_PostId",
                table: "comment_post",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_post_UserId",
                table: "comment_post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_course_CourseLevelId",
                table: "course",
                column: "CourseLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_course_CourseStatusId",
                table: "course",
                column: "CourseStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_course_course_type_CourseId",
                table: "course_course_type",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_course_course_type_CourseTypeId",
                table: "course_course_type",
                column: "CourseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_course_image_CourseId",
                table: "course_image",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_lesson_LessonCheckPointId",
                table: "lesson",
                column: "LessonCheckPointId");

            migrationBuilder.CreateIndex(
                name: "IX_lesson_LessonTypeId",
                table: "lesson",
                column: "LessonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_post_PostStatusId",
                table: "post",
                column: "PostStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_post_UserCreateId",
                table: "post",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_UserId",
                table: "refresh_token",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_GenderId",
                table: "user",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_user_UserRoleId",
                table: "user",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_user_UserStatusId",
                table: "user",
                column: "UserStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_user_course_CourseId",
                table: "user_course",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_user_course_UserId",
                table: "user_course",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_like_comment_lesson_CommentLessonId",
                table: "user_like_comment_lesson",
                column: "CommentLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_user_like_comment_lesson_UserId",
                table: "user_like_comment_lesson",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_like_comment_post_CommentPostId",
                table: "user_like_comment_post",
                column: "CommentPostId");

            migrationBuilder.CreateIndex(
                name: "IX_user_like_comment_post_UserId",
                table: "user_like_comment_post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_like_post_PostId",
                table: "user_like_post",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_user_like_post_UserId",
                table: "user_like_post",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "course_course_type");

            migrationBuilder.DropTable(
                name: "course_image");

            migrationBuilder.DropTable(
                name: "refresh_token");

            migrationBuilder.DropTable(
                name: "user_course");

            migrationBuilder.DropTable(
                name: "user_like_comment_lesson");

            migrationBuilder.DropTable(
                name: "user_like_comment_post");

            migrationBuilder.DropTable(
                name: "user_like_post");

            migrationBuilder.DropTable(
                name: "course_type");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "comment_lesson");

            migrationBuilder.DropTable(
                name: "comment_post");

            migrationBuilder.DropTable(
                name: "course_level");

            migrationBuilder.DropTable(
                name: "course_status");

            migrationBuilder.DropTable(
                name: "lesson");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "lesson_check_point");

            migrationBuilder.DropTable(
                name: "lesson_type");

            migrationBuilder.DropTable(
                name: "post_status");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "gender");

            migrationBuilder.DropTable(
                name: "user_role");

            migrationBuilder.DropTable(
                name: "user_status");
        }
    }
}
