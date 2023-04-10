using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dj_actionlayer.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "administrative_regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrative_regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "administrative_units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    full_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    short_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    short_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrative_units", x => x.Id);
                });

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
                name: "course_profit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseProfitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseProfitCreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_profit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "course_require",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseRequireName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseRequireCreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_require", x => x.Id);
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
                name: "practice_lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Problem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProblemDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Input = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpecOutput = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suggest = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_practice_lesson", x => x.Id);
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
                name: "provinces",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    full_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    administrative_unit_id = table.Column<int>(type: "int", nullable: true),
                    administrative_region_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provinces", x => x.code);
                    table.ForeignKey(
                        name: "FK_provinces_administrative_regions_administrative_region_id",
                        column: x => x.administrative_region_id,
                        principalTable: "administrative_regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_provinces_administrative_units_administrative_unit_id",
                        column: x => x.administrative_unit_id,
                        principalTable: "administrative_units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseSubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CourseLevelId = table.Column<int>(type: "int", nullable: true),
                    LessonCount = table.Column<int>(type: "int", nullable: false),
                    ChapterCount = table.Column<int>(type: "int", nullable: false),
                    TimeLessonTotal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterCount = table.Column<int>(type: "int", nullable: false),
                    DoneCount = table.Column<int>(type: "int", nullable: false),
                    CourseStatusId = table.Column<int>(type: "int", nullable: true),
                    CourseTypeId = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_course_course_type_CourseTypeId",
                        column: x => x.CourseTypeId,
                        principalTable: "course_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LessonTypeId = table.Column<int>(type: "int", nullable: true),
                    VideoTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lesson_lesson_type_LessonTypeId",
                        column: x => x.LessonTypeId,
                        principalTable: "lesson_type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "test_case",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PracticeLessonId = table.Column<int>(type: "int", nullable: false),
                    Input = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpecOutput = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_case", x => x.Id);
                    table.ForeignKey(
                        name: "FK_test_case_practice_lesson_PracticeLessonId",
                        column: x => x.PracticeLessonId,
                        principalTable: "practice_lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "districts",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    full_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    province_code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    administrative_unit_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts", x => x.code);
                    table.ForeignKey(
                        name: "FK_districts_administrative_units_administrative_unit_id",
                        column: x => x.administrative_unit_id,
                        principalTable: "administrative_units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_districts_provinces_province_code",
                        column: x => x.province_code,
                        principalTable: "provinces",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "course_chapter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ChapterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChapterTotalTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChapterLessonCount = table.Column<int>(type: "int", nullable: false),
                    ChapterCreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_chapter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_course_chapter_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "course_course_profit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseProfitId = table.Column<int>(type: "int", nullable: false),
                    SortNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_course_profit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_course_course_profit_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_course_course_profit_course_profit_CourseProfitId",
                        column: x => x.CourseProfitId,
                        principalTable: "course_profit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "course_course_require",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseRequireId = table.Column<int>(type: "int", nullable: false),
                    SortNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_course_require", x => x.Id);
                    table.ForeignKey(
                        name: "FK_course_course_require_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_course_course_require_course_require_CourseRequireId",
                        column: x => x.CourseRequireId,
                        principalTable: "course_require",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "course_image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
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
                name: "question_lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question_lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_question_lesson_lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "video_lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    LessonLinkUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video_lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_video_lesson_lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wards",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    full_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    district_code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    administrative_unit_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wards", x => x.code);
                    table.ForeignKey(
                        name: "FK_wards_administrative_units_administrative_unit_id",
                        column: x => x.administrative_unit_id,
                        principalTable: "administrative_units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_wards_districts_district_code",
                        column: x => x.district_code,
                        principalTable: "districts",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "chapter_lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseChapterId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    SortNumber = table.Column<int>(type: "int", nullable: false),
                    AddLessonToChapterDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chapter_lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chapter_lesson_course_chapter_CourseChapterId",
                        column: x => x.CourseChapterId,
                        principalTable: "course_chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chapter_lesson_lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAvatarData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserAvatarData40x40 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserFacebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserFisrtName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    UserRoleId = table.Column<int>(type: "int", nullable: true),
                    UserStatusId = table.Column<int>(type: "int", nullable: true),
                    WardCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DistrictCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProvinceCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_districts_DistrictCode",
                        column: x => x.DistrictCode,
                        principalTable: "districts",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_user_gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "gender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_provinces_ProvinceCode",
                        column: x => x.ProvinceCode,
                        principalTable: "provinces",
                        principalColumn: "code");
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
                    table.ForeignKey(
                        name: "FK_user_wards_WardCode",
                        column: x => x.WardCode,
                        principalTable: "wards",
                        principalColumn: "code");
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
                name: "IX_chapter_lesson_CourseChapterId",
                table: "chapter_lesson",
                column: "CourseChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_chapter_lesson_LessonId",
                table: "chapter_lesson",
                column: "LessonId");

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
                name: "IX_course_CourseTypeId",
                table: "course",
                column: "CourseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_course_chapter_CourseId",
                table: "course_chapter",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_course_course_profit_CourseId",
                table: "course_course_profit",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_course_course_profit_CourseProfitId",
                table: "course_course_profit",
                column: "CourseProfitId");

            migrationBuilder.CreateIndex(
                name: "IX_course_course_require_CourseId",
                table: "course_course_require",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_course_course_require_CourseRequireId",
                table: "course_course_require",
                column: "CourseRequireId");

            migrationBuilder.CreateIndex(
                name: "IX_course_image_CourseId",
                table: "course_image",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_districts_administrative_unit_id",
                table: "districts",
                column: "administrative_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_districts_province_code",
                table: "districts",
                column: "province_code");

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
                name: "IX_provinces_administrative_region_id",
                table: "provinces",
                column: "administrative_region_id");

            migrationBuilder.CreateIndex(
                name: "IX_provinces_administrative_unit_id",
                table: "provinces",
                column: "administrative_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_question_lesson_LessonId",
                table: "question_lesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_UserId",
                table: "refresh_token",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_test_case_PracticeLessonId",
                table: "test_case",
                column: "PracticeLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_user_DistrictCode",
                table: "user",
                column: "DistrictCode");

            migrationBuilder.CreateIndex(
                name: "IX_user_GenderId",
                table: "user",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_user_ProvinceCode",
                table: "user",
                column: "ProvinceCode");

            migrationBuilder.CreateIndex(
                name: "IX_user_UserRoleId",
                table: "user",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_user_UserStatusId",
                table: "user",
                column: "UserStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_user_WardCode",
                table: "user",
                column: "WardCode");

            migrationBuilder.CreateIndex(
                name: "IX_user_course_CourseId",
                table: "user_course",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_user_course_UserId",
                table: "user_course",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_lesson_checkpoint_LessonId",
                table: "user_lesson_checkpoint",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_user_lesson_checkpoint_UserId",
                table: "user_lesson_checkpoint",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_lesson_note_UserLessonCheckpointId",
                table: "user_lesson_note",
                column: "UserLessonCheckpointId");

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

            migrationBuilder.CreateIndex(
                name: "IX_video_lesson_LessonId",
                table: "video_lesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_wards_administrative_unit_id",
                table: "wards",
                column: "administrative_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_wards_district_code",
                table: "wards",
                column: "district_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chapter_lesson");

            migrationBuilder.DropTable(
                name: "course_course_profit");

            migrationBuilder.DropTable(
                name: "course_course_require");

            migrationBuilder.DropTable(
                name: "course_image");

            migrationBuilder.DropTable(
                name: "question_lesson");

            migrationBuilder.DropTable(
                name: "refresh_token");

            migrationBuilder.DropTable(
                name: "test_case");

            migrationBuilder.DropTable(
                name: "user_course");

            migrationBuilder.DropTable(
                name: "user_lesson_note");

            migrationBuilder.DropTable(
                name: "user_like_comment_lesson");

            migrationBuilder.DropTable(
                name: "user_like_comment_post");

            migrationBuilder.DropTable(
                name: "user_like_post");

            migrationBuilder.DropTable(
                name: "video_lesson");

            migrationBuilder.DropTable(
                name: "course_chapter");

            migrationBuilder.DropTable(
                name: "course_profit");

            migrationBuilder.DropTable(
                name: "course_require");

            migrationBuilder.DropTable(
                name: "practice_lesson");

            migrationBuilder.DropTable(
                name: "user_lesson_checkpoint");

            migrationBuilder.DropTable(
                name: "comment_lesson");

            migrationBuilder.DropTable(
                name: "comment_post");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "lesson");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "course_level");

            migrationBuilder.DropTable(
                name: "course_status");

            migrationBuilder.DropTable(
                name: "course_type");

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

            migrationBuilder.DropTable(
                name: "wards");

            migrationBuilder.DropTable(
                name: "districts");

            migrationBuilder.DropTable(
                name: "provinces");

            migrationBuilder.DropTable(
                name: "administrative_regions");

            migrationBuilder.DropTable(
                name: "administrative_units");
        }
    }
}
