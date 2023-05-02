using System;
namespace dj_webdesigncore.Request.Chapter
{
	public class AddChapterRequest
	{
		public int CourseId { get; set; }
		public string ChapterName { get; set; }
		public string ChapterTotalTime { get; set; }
	}
}

