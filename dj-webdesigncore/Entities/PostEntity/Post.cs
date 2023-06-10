using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.PostEntity
{
	public class Post : BaseEntity
	{
		public string? PostTitle { get; set; }
		public string? PostDescription { get; set; }
		public string? PostImgLinkMeta { get; set; }
		public string? PostAvatar { get; set; }
	
		public int? UserCreateId { get; set; }
		public string PostData { get; set; }
		public User? UserCreate { get; set; }
		public DateTime CreatePost { get; set; }
		public DateTime? UpdatePost { get; set; }
		public int LikeCount { get; set; }
		public int CommentCount { get; set; }
		public int? PostStatusId { get; set; }
		public PostStatus? PostStatus { get; set; }
	}
}
