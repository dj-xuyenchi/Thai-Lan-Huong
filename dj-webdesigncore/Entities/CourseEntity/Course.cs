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
		public string? CourseImageData { get; set; }
		public int? CourseLevelId { get; set; }
		public CourseLevel? CourseLevel { get;set; }
		public int LessonCount { get; set; }
		public int ChapterCount { get; set; }
		public string TimeLessonTotal { get; set; }
		public int RegisterCount { get; set; }
		public int DoneCount { get; set; }
		public int? CourseStatusId { get; set; }
		public CourseStatus? CourseStatus { get; set; }         
		public int CourseTypeId { get; set; }
		public CourseType CourseType { get; set; }
		public string? IntroVideoLink { get; set; }
		public string? ResourceLink { get; set; }
    }
}
