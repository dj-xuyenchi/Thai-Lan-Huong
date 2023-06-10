using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.CourseEntity
{
	public class CourseImage : BaseEntity
	{
		public string CourseImageData { get; set; }
		public int SortNumber { get; set; }
		public int? CourseId { get; set; }
		public Course? Course { get; set; }
	}
}
