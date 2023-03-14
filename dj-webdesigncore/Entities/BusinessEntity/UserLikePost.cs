using dj_webdesigncore.Entities.PostEntity;
using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.BusinessEntity
{
	public class UserLikePost : BaseEntity
	{
		public int? UserId { get; set; }
		public User? User { get; set; }
		public int? PostId { get; set; }
		public Post? Post { get; set; }
		public DateTime LikeDateTime { get; set; }
		public bool IsDeleted { get; set; }
	}
}
