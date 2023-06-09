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
                name: "blog_status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "blog_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "comment_status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment_status", x => x.Id);
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
                name: "denounce_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenounceCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DenounceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_denounce_type", x => x.Id);
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
                    province_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    administrative_unit_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts", x => x.code);
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
                name: "home_content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slide1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Slide2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Slide3 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Slide4 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Slide5 = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_home_content", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "langue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LangueName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_langue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lesson_status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lesson_status", x => x.Id);
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
                name: "majors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MajorsCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MajorsName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_majors", x => x.Id);
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
                });

            migrationBuilder.CreateTable(
                name: "school_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_school_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trophic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrophicCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrophicName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trophic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatalogName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_catalog", x => x.Id);
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
                name: "wards",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    full_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    district_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    administrative_unit_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wards", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    CmtCount = table.Column<int>(type: "int", nullable: false),
                    BlogImg = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    BlogLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    BlogTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blog_blog_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "blog_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_blog_blog_type_BlogTypeId",
                        column: x => x.BlogTypeId,
                        principalTable: "blog_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    CourseTypeId = table.Column<int>(type: "int", nullable: false),
                    IntroVideoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourceLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    VideoTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonStatusId = table.Column<int>(type: "int", nullable: false),
                    ResourceLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lesson_lesson_status_LessonStatusId",
                        column: x => x.LessonStatusId,
                        principalTable: "lesson_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lesson_lesson_type_LessonTypeId",
                        column: x => x.LessonTypeId,
                        principalTable: "lesson_type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "school",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_school", x => x.Id);
                    table.ForeignKey(
                        name: "FK_school_school_type_SchoolTypeId",
                        column: x => x.SchoolTypeId,
                        principalTable: "school_type",
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
                    UserAvatarData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserAvatarData40x40 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserCoverImg = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserFacebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserLinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserFisrtName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateAccount = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    UserRoleId = table.Column<int>(type: "int", nullable: true),
                    UserStatusId = table.Column<int>(type: "int", nullable: true),
                    WardCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DistrictCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProvinceCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CatalogId = table.Column<int>(type: "int", nullable: true),
                    AddressNow = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsKYC = table.Column<bool>(type: "bit", nullable: true),
                    KYCTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsLock = table.Column<bool>(type: "bit", nullable: true),
                    UnlockTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        name: "FK_user_user_catalog_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "user_catalog",
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
                    table.ForeignKey(
                        name: "FK_user_wards_WardCode",
                        column: x => x.WardCode,
                        principalTable: "wards",
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
                name: "practice_lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Problem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProblemDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeginCodeMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallTestCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Input = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectOutput = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suggest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    IsSupportMultiLangue = table.Column<bool>(type: "bit", nullable: true),
                    LangueDefaultId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_practice_lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_practice_lesson_langue_LangueDefaultId",
                        column: x => x.LangueDefaultId,
                        principalTable: "langue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_practice_lesson_lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "advice_contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsContact = table.Column<bool>(type: "bit", nullable: false),
                    SendRequest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserContactId = table.Column<int>(type: "int", nullable: true),
                    ContactTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    Evaluate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advice_contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_advice_contact_user_UserContactId",
                        column: x => x.UserContactId,
                        principalTable: "user",
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
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentLessonParentId = table.Column<int>(type: "int", nullable: true),
                    LikeCount = table.Column<int>(type: "int", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CommentStatusId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_comment_lesson_comment_status_CommentStatusId",
                        column: x => x.CommentStatusId,
                        principalTable: "comment_status",
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
                name: "confirm_email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RequiredDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConfirm = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_confirm_email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_confirm_email_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "denounce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserSendId = table.Column<int>(type: "int", nullable: false),
                    UserViolationId = table.Column<int>(type: "int", nullable: false),
                    ProveLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCheck = table.Column<bool>(type: "bit", nullable: false),
                    SendTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsViolation = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CmtId = table.Column<int>(type: "int", nullable: false),
                    DenounceTypeId = table.Column<int>(type: "int", nullable: true),
                    TypeCmt = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_denounce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_denounce_denounce_type_DenounceTypeId",
                        column: x => x.DenounceTypeId,
                        principalTable: "denounce_type",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_denounce_user_UserSendId",
                        column: x => x.UserSendId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "experience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Open = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Close = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_experience_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "home_notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPublicId = table.Column<int>(type: "int", nullable: false),
                    Img = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_home_notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_home_notification_user_UserPublicId",
                        column: x => x.UserPublicId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "learning_experience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    MajorsId = table.Column<int>(type: "int", nullable: false),
                    Open = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Close = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_learning_experience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_learning_experience_majors_MajorsId",
                        column: x => x.MajorsId,
                        principalTable: "majors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_learning_experience_school_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "school",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_learning_experience_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserSendId = table.Column<int>(type: "int", nullable: true),
                    IsSeen = table.Column<bool>(type: "bit", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemNotification = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notification_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostImgLinkMeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostAvatar = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PostMiniAvatar = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserCreateId = table.Column<int>(type: "int", nullable: true),
                    PostData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatePost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatePost = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
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
                name: "user_trophic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TrophicId = table.Column<int>(type: "int", nullable: false),
                    TakeTrophicDatetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_trophic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_trophic_trophic_TrophicId",
                        column: x => x.TrophicId,
                        principalTable: "trophic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_trophic_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "multi_langue_code",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeginCodeMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallTestCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangueId = table.Column<int>(type: "int", nullable: false),
                    PracticeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_multi_langue_code", x => x.Id);
                    table.ForeignKey(
                        name: "FK_multi_langue_code_langue_LangueId",
                        column: x => x.LangueId,
                        principalTable: "langue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_multi_langue_code_practice_lesson_PracticeId",
                        column: x => x.PracticeId,
                        principalTable: "practice_lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "practice_done_data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PracticeLessonId = table.Column<int>(type: "int", nullable: false),
                    DoneData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoneTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LangueId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_practice_done_data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_practice_done_data_langue_LangueId",
                        column: x => x.LangueId,
                        principalTable: "langue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_practice_done_data_practice_lesson_PracticeLessonId",
                        column: x => x.PracticeLessonId,
                        principalTable: "practice_lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_practice_done_data_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "test_case",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PracticeLessonId = table.Column<int>(type: "int", nullable: false),
                    InputDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Input = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectOutput = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortNumber = table.Column<int>(type: "int", nullable: false),
                    LockTestCase = table.Column<bool>(type: "bit", nullable: false)
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
                name: "question_done_data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionLessonId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<int>(type: "int", nullable: false),
                    DoneTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question_done_data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_question_done_data_question_lesson_QuestionLessonId",
                        column: x => x.QuestionLessonId,
                        principalTable: "question_lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_question_done_data_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "video_done_data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoLessonId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DoneTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_video_done_data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_video_done_data_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_video_done_data_video_lesson_VideoLessonId",
                        column: x => x.VideoLessonId,
                        principalTable: "video_lesson",
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
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    CommentStatusId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_comment_post_comment_status_CommentStatusId",
                        column: x => x.CommentStatusId,
                        principalTable: "comment_status",
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
                name: "IX_advice_contact_UserContactId",
                table: "advice_contact",
                column: "UserContactId");

            migrationBuilder.CreateIndex(
                name: "IX_blog_BlogTypeId",
                table: "blog",
                column: "BlogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_blog_StatusId",
                table: "blog",
                column: "StatusId");

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
                name: "IX_comment_lesson_CommentStatusId",
                table: "comment_lesson",
                column: "CommentStatusId");

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
                name: "IX_comment_post_CommentStatusId",
                table: "comment_post",
                column: "CommentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_post_PostId",
                table: "comment_post",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_post_UserId",
                table: "comment_post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_confirm_email_UserId",
                table: "confirm_email",
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
                name: "IX_denounce_DenounceTypeId",
                table: "denounce",
                column: "DenounceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_denounce_UserSendId",
                table: "denounce",
                column: "UserSendId");

            migrationBuilder.CreateIndex(
                name: "IX_experience_UserId",
                table: "experience",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_home_notification_UserPublicId",
                table: "home_notification",
                column: "UserPublicId");

            migrationBuilder.CreateIndex(
                name: "IX_learning_experience_MajorsId",
                table: "learning_experience",
                column: "MajorsId");

            migrationBuilder.CreateIndex(
                name: "IX_learning_experience_SchoolId",
                table: "learning_experience",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_learning_experience_UserId",
                table: "learning_experience",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_lesson_LessonStatusId",
                table: "lesson",
                column: "LessonStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_lesson_LessonTypeId",
                table: "lesson",
                column: "LessonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_multi_langue_code_LangueId",
                table: "multi_langue_code",
                column: "LangueId");

            migrationBuilder.CreateIndex(
                name: "IX_multi_langue_code_PracticeId",
                table: "multi_langue_code",
                column: "PracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_notification_UserId",
                table: "notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_post_PostStatusId",
                table: "post",
                column: "PostStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_post_UserCreateId",
                table: "post",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_practice_done_data_LangueId",
                table: "practice_done_data",
                column: "LangueId");

            migrationBuilder.CreateIndex(
                name: "IX_practice_done_data_PracticeLessonId",
                table: "practice_done_data",
                column: "PracticeLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_practice_done_data_UserId",
                table: "practice_done_data",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_practice_lesson_LangueDefaultId",
                table: "practice_lesson",
                column: "LangueDefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_practice_lesson_LessonId",
                table: "practice_lesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_question_done_data_QuestionLessonId",
                table: "question_done_data",
                column: "QuestionLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_question_done_data_UserId",
                table: "question_done_data",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_question_lesson_LessonId",
                table: "question_lesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_UserId",
                table: "refresh_token",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_school_SchoolTypeId",
                table: "school",
                column: "SchoolTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_test_case_PracticeLessonId",
                table: "test_case",
                column: "PracticeLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_user_CatalogId",
                table: "user",
                column: "CatalogId");

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
                name: "IX_user_trophic_TrophicId",
                table: "user_trophic",
                column: "TrophicId");

            migrationBuilder.CreateIndex(
                name: "IX_user_trophic_UserId",
                table: "user_trophic",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_video_done_data_UserId",
                table: "video_done_data",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_video_done_data_VideoLessonId",
                table: "video_done_data",
                column: "VideoLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_video_lesson_LessonId",
                table: "video_lesson",
                column: "LessonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrative_regions");

            migrationBuilder.DropTable(
                name: "administrative_units");

            migrationBuilder.DropTable(
                name: "advice_contact");

            migrationBuilder.DropTable(
                name: "blog");

            migrationBuilder.DropTable(
                name: "chapter_lesson");

            migrationBuilder.DropTable(
                name: "confirm_email");

            migrationBuilder.DropTable(
                name: "course_course_profit");

            migrationBuilder.DropTable(
                name: "course_course_require");

            migrationBuilder.DropTable(
                name: "course_image");

            migrationBuilder.DropTable(
                name: "denounce");

            migrationBuilder.DropTable(
                name: "experience");

            migrationBuilder.DropTable(
                name: "home_content");

            migrationBuilder.DropTable(
                name: "home_notification");

            migrationBuilder.DropTable(
                name: "learning_experience");

            migrationBuilder.DropTable(
                name: "multi_langue_code");

            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropTable(
                name: "practice_done_data");

            migrationBuilder.DropTable(
                name: "question_done_data");

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
                name: "user_trophic");

            migrationBuilder.DropTable(
                name: "video_done_data");

            migrationBuilder.DropTable(
                name: "blog_status");

            migrationBuilder.DropTable(
                name: "blog_type");

            migrationBuilder.DropTable(
                name: "course_chapter");

            migrationBuilder.DropTable(
                name: "course_profit");

            migrationBuilder.DropTable(
                name: "course_require");

            migrationBuilder.DropTable(
                name: "denounce_type");

            migrationBuilder.DropTable(
                name: "majors");

            migrationBuilder.DropTable(
                name: "school");

            migrationBuilder.DropTable(
                name: "question_lesson");

            migrationBuilder.DropTable(
                name: "practice_lesson");

            migrationBuilder.DropTable(
                name: "user_lesson_checkpoint");

            migrationBuilder.DropTable(
                name: "comment_lesson");

            migrationBuilder.DropTable(
                name: "comment_post");

            migrationBuilder.DropTable(
                name: "trophic");

            migrationBuilder.DropTable(
                name: "video_lesson");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "school_type");

            migrationBuilder.DropTable(
                name: "langue");

            migrationBuilder.DropTable(
                name: "comment_status");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "lesson");

            migrationBuilder.DropTable(
                name: "course_level");

            migrationBuilder.DropTable(
                name: "course_status");

            migrationBuilder.DropTable(
                name: "course_type");

            migrationBuilder.DropTable(
                name: "post_status");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "lesson_status");

            migrationBuilder.DropTable(
                name: "lesson_type");

            migrationBuilder.DropTable(
                name: "districts");

            migrationBuilder.DropTable(
                name: "gender");

            migrationBuilder.DropTable(
                name: "provinces");

            migrationBuilder.DropTable(
                name: "user_catalog");

            migrationBuilder.DropTable(
                name: "user_role");

            migrationBuilder.DropTable(
                name: "user_status");

            migrationBuilder.DropTable(
                name: "wards");
        }
    }
}
