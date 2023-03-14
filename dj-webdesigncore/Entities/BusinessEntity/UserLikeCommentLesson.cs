using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.BusinessEntity
{
	public  class UserLikeCommentLesson : BaseEntity
	{
		public int? UserId { get; set; }
		public User? User { get; set; }
		public int? CommentLessonId { get; set; }
		public CommentLesson? CommentLesson { get; set; }
		public DateTime CreateDateTime { get; set; }
		public bool IsDeleted { get; set; }
	}
}
