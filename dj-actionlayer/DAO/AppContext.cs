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
		private readonly string urlDb;
		//protected AppContext(String urlDb)
		//{
		//	this.urlDb = urlDb;
		//}

		// Course Entities
		public DbSet<Course> course { get; set; }
		public DbSet<CourseCourseType> course_course_type { get; set; }
		public DbSet<CourseImage> course_image { get; set; }
		public DbSet<CourseLevel> course_level { get; set; }
		public DbSet<CourseStatus> course_status { get; set; }
		public DbSet<CourseType> course_type { get; set; }
		public DbSet<Lesson> lesson { get; set; }
		public DbSet<LessonCheckPoint> lesson_check_point { get; set; }
		public DbSet<LessonType> lesson_type { get; set; }
		// Post Entities
		public DbSet<Post> post { get; set; }
		public DbSet<PostStatus> post_status { get; set; }
		// User Entities
		public DbSet<User> user { get; set; }
		public DbSet<Gender> gender { get; set; }
		public DbSet<UserRole> user_role { get; set; }
		public DbSet<UserStatus> user_status { get; set; }
		// Business Entities
		public DbSet<CommentLesson> comment_lesson { get; set; }
		public DbSet<CommentPost> comment_post { get; set; }
		public DbSet<UserCourse> user_course { get; set; }
		public DbSet<UserLikeCommentLesson> user_like_comment_lesson { get; set; }
		public DbSet<UserLikeCommentPost> user_like_comment_post { get; set; }
		public DbSet<UserLikePost> user_like_post { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=dj_coding;Integrated Security=True;encrypt=true;trustservercertificate=true;");
	//		optionsBuilder.UseSqlServer(urlDb);
		}
	}
}
