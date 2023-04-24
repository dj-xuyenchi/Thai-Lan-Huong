using System;
namespace dj_webdesigncore.Request.Lesson
{
	public class CommentLessonRequest
	{
		public int UserId { get; set; }
		public int LessonId { get; set; }
		public int CourseId { get; set; }
		public string CommentContent { get; set; }
	}
}

