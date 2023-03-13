using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.User
{
	public class User : BaseEntity
	{
		public string? UserName { get; set; }
		public string UserPass { get; set; }
		public byte[]? UserAvatar { get; set; }
		public string? UserEmail { get; set; }
		public string? UserFacebook { get; set; }
		public string? UserFisrtName { get; set; }
		public string? UserLastName { get; set; }
		public string? NumberPhone { get; set; }
		public DateOnly? Birthday { get; set; }
		public int GenderId { get; set; }
		public Gender Gender { get; set; }
	}
}
