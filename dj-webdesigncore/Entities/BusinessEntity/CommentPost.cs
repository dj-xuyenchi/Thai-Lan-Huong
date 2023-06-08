using dj_webdesigncore.Entities.PostEntity;
using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.BusinessEntity
{
	public class CommentPost : BaseEntity
	{
		public int? UserId { get; set; }
		public User? User { get; set; }
		public int? PostId { get; set; }
		public Post? Post { get; set; }
		public string Comment { get; set; }
		public int? CommentPostParentId { get; set; }
		public CommentPost? CommentPostParent { get; set; }
		public DateTime CreateDateTime { get; set; }
		public DateTime? UpdateDateTime { get; set; }
		public DateTime? DeleteDateTime { get; set; }
		public bool IsDeleted { get; set; }
		public int LikeCount { get; set; }
		public int? CommentStatusId { get; set; }
		public CommentStatus? CommentStatus { get; set; }
	}
}
