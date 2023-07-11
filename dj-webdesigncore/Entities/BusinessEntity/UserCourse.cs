using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.BusinessEntity
{
	public class UserCourse : BaseEntity
	{
		public int? UserId { get; set; }
		public User? User { get; set; }
		public int? CourseId { get; set; }
		public Course? Course { get; set; }
		public bool isDone { get; set; }
		public DateTime ResisterDateTime { get; set; }
		public DateTime LastTimeStudyDateTime { get; set; }
		public int DonePercent { get; set; }
		public DateTime? DoneTime { get; set; }
		public int? LessonProcessId { get; set; }
		public Lesson? LessonProcess { get; set; }

    }
}
