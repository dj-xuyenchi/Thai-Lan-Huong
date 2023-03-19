﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.UserEntity
{
	public class User : BaseEntity
	{
		public string? UserName { get; set; }
		public string UserPass { get; set; }
		public string UserAvatarPath { get; set; }
		public string? UserEmail { get; set; }
		public string? UserFacebook { get; set; }
		public string? UserFisrtName { get; set; }
		public string? UserLastName { get; set; }
		public string? NumberPhone { get; set; }
		public DateTime? Birthday { get; set; }
		public int? GenderId { get; set; }
		public  Gender? Gender { get; set; }
		public int? UserRoleId { get; set; }
		public  UserRole? Role { get; set; }
		public int? UserStatusId { get; set; }
		public UserStatus? UserStatus { get; set; }
	}
}