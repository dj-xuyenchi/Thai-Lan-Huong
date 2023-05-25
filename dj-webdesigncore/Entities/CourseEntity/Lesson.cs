using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.CourseEntity
{
	public class Lesson :BaseEntity
	{
		public string LessonName { get; set; }
		public string LessonDescription { get; set;}
		public DateTime CreateDateTime { get; set; }
		public DateTime? UpdateDateTime { get; set; }
		public int? LessonTypeId { get; set; }
		public LessonType? LessonType { get; set; }
		public string VideoTime { get; set; }
		public int LessonStatusId { get; set; }
		public LessonStatus LessonStatus { get; set; }
		public string? ResourceLink { get; set; }
	}
}
