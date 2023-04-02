using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.CourseEntity
{
	public class Course : BaseEntity
	{
		public string CourseCode { get; set; }
		public string CourseName { get; set; }
		public string CourseSubTitle { get; set; }
		public byte[]? CourseImageData { get; set; }
		public int? CourseLevelId { get; set; }
		public CourseLevel? CourseLevel { get;set; }
		public int LessonCount { get; set; }
		public int ChapterCount { get; set; }
		public string TimeLessonTotal { get; set; }
		public int RegisterCount { get; set; }
		public int DoneCount { get; set; }
		public int? CourseStatusId { get; set; }
		public CourseStatus? CourseStatus { get; set; }                   
	}
}
