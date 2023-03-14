using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.CourseEntity
{
	public class LessonCheckPoint : BaseEntity
	{
		public string LessonCheckPointName { get; set; }
		public int SortNumber { get; set; }
	}
}
