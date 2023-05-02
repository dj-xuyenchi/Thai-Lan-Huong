using System;
namespace dj_webdesigncore.Request.Chapter
{
	public class UpdateChapterRequest
	{
        public int ChapterId { get; set; }
        public string ChapterName { get; set; }
        public string ChapterTotalTime { get; set; }
        public int LessonCount { get; set; }
    }
}

