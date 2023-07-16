using dj_webdesigncore.Entities;
using dj_webdesigncore.Entities.BlogEntity;
using dj_webdesigncore.Entities.BusinessEntity;
using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Entities.PostEntity;
using dj_webdesigncore.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_actionlayer.DAO
{
    public class AppContext : DbContext
    {
        //protected AppContext(String urlDb)
        //{
        //	this.urlDb = urlDb;
        //}
        // Auth
        public DbSet<RefreshToken> refresh_token { get; set; }
        // Blog Entities
        public DbSet<Blog> blog { get; set; }
        public DbSet<BlogStatus> blog_status { get; set; }
        public DbSet<BlogType> blog_type { get; set; }

        // Course Entities
        public DbSet<Langue> langue { get; set; }
        public DbSet<MultiLangueCode> multi_langue_code { get; set; }
        public DbSet<LessonStatus> lesson_status { get; set; }
        public DbSet<PracticeLesson> practice_lesson { get; set; }
        public DbSet<VideoLesson> video_lesson { get; set; }
        public DbSet<QuestionLesson> question_lesson { get; set; }
        public DbSet<TestCase> test_case { get; set; }
        public DbSet<CourseProfit> course_profit { get; set; }
        public DbSet<CourseCourseProfit> course_course_profit { get; set; }
        public DbSet<CourseCourseRequire> course_course_require { get; set; }
        public DbSet<CourseRequire> course_require { get; set; }
        public DbSet<ChapterLesson> chapter_lesson { get; set; }
        public DbSet<CourseChapter> course_chapter { get; set; }
        public DbSet<Course> course { get; set; }
        public DbSet<CourseImage> course_image { get; set; }
        public DbSet<CourseLevel> course_level { get; set; }
        public DbSet<CourseStatus> course_status { get; set; }
        public DbSet<CourseType> course_type { get; set; }
        public DbSet<Lesson> lesson { get; set; }
        public DbSet<LessonType> lesson_type { get; set; }
        // Post Entities
        //public DbSet<PostSentence> post_sentence { get; set; }
        public DbSet<Post> post { get; set; }
        public DbSet<PostStatus> post_status { get; set; }
        // User Entities
        public DbSet<Notification> notification { get; set; }
        public DbSet<School> school { get; set; }
        public DbSet<SchoolType> school_type { get; set; }
        public DbSet<LearningExperience> learning_experience { get; set; }
        public DbSet<Experience> experience { get; set; }
        public DbSet<Ward> wards { get; set; }
        public DbSet<District> districts { get; set; }
        public DbSet<Province> provinces { get; set; }
        public DbSet<AdministrativeRegion> administrative_regions { get; set; }
        public DbSet<AdministrativeUnits> administrative_units { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Gender> gender { get; set; }
        public DbSet<UserRole> user_role { get; set; }
        public DbSet<UserStatus> user_status { get; set; }
        // Business Entities
        public DbSet<DenounceType> denounce_type { get; set; }
        public DbSet<CommentStatus> comment_status { get; set; }
        public DbSet<Denounce> denounce { get; set; }
        public DbSet<HomeNotification> home_notification { get; set; }
        public DbSet<Majors> majors { get; set; }
        public DbSet<UserCatalog> user_catalog { get; set; }
        public DbSet<VideoDoneData> video_done_data { get; set; }
        public DbSet<QuestionDoneData> question_done_data { get; set; }
        public DbSet<ConfirmEmail> confirm_email { get; set; }
        public DbSet<AdviceContact> advice_contact { get; set; }
        public DbSet<PracticeDoneData> practice_done_data { get; set; }
        public DbSet<Trophic> trophic { get; set; }
        public DbSet<UserTrophic> user_trophic { get; set; }
        public DbSet<UserLessonNote> user_lesson_note { get; set; }
        public DbSet<UserLessonCheckpoint> user_lesson_checkpoint { get; set; }
        public DbSet<CommentLesson> comment_lesson { get; set; }
        public DbSet<CommentPost> comment_post { get; set; }
        public DbSet<UserCourse> user_course { get; set; }
        public DbSet<UserLikeCommentLesson> user_like_comment_lesson { get; set; }
        public DbSet<UserLikeCommentPost> user_like_comment_post { get; set; }
        public DbSet<UserLikePost> user_like_post { get; set; }
        public DbSet<HomeContent> home_content { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  optionsBuilder.UseSqlServer(Settings.DBConnectHostingRemote());
            //  optionsBuilder.UseSqlServer(Settings.DBConnect());
            //   optionsBuilder.UseSqlServer(Settings.DBConnectVPS());
            optionsBuilder.UseSqlServer(Settings.DBConnectDeploy());
        }
    }
}
