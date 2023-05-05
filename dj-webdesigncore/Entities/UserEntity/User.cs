using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.UserEntity
{
	public class User : BaseEntity
	{
		public string? UserName { get; set; }
		public string UserPass { get; set; }
		public byte[]? UserAvatarData { get; set; }
		public byte[]? UserAvatarData40x40 { get; set; }
		public string? UserEmail { get; set; }
		public string? UserFacebook { get; set; }
		public string? UserLinkedIn { get; set; }
		public string? UserFisrtName { get; set; }
		public string? UserLastName { get; set; }
		public string? NumberPhone { get; set; }
		public string? UserDetail { get; set; }
		public DateTime? Birthday { get; set; }
		public int? GenderId { get; set; }
		public  Gender? Gender { get; set; }
		public int? UserRoleId { get; set; }
		public  UserRole? Role { get; set; }
		public int? UserStatusId { get; set; }
        public string? WardCode { get; set; }
        [ForeignKey("WardCode")]
        public Ward? Ward { get; set; }
        public string? DistrictCode { get; set; }
        [ForeignKey("DistrictCode")]
        public District? District { get; set; }
        public string? ProvinceCode { get; set; }
        [ForeignKey("ProvinceCode")]
        public Province? Province { get; set; }
        public UserStatus? UserStatus { get; set; }
	}
}
