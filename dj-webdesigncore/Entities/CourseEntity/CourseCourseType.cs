using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.CourseEntity
{
	public class CourseCourseType : BaseEntity
	{
		public int? CourseId { get; set; }
		public Course? Course { get; set; }
		public int? CourseTypeId { get; set; }
		public CourseType? CourseType { get; set; }
	}
}
