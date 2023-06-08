using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.BusinessEntity
{
	public class CommentLesson :BaseEntity
	{
		public int? LessonId { get; set; }
		public Lesson? Lesson { get; set; }
		public int? UserId { get; set; }
		public User? User { get; set; }
		public string? Comment { get; set; }
		public string? CommentImagePath { get; set; }
		public int? CommentLessonParentId { get; set; }
		public CommentLesson? CommentLessonParent { get; set; }
		public int? LikeCount { get; set; }
		public DateTime CreateDateTime { get; set; }
		public DateTime? UpdateDateTime { get; set; }
		public DateTime? DeleteDateTime { get; set; }
        public int? CommentStatusId { get; set; }
        public CommentStatus? CommentStatus { get; set; }
    }
}
