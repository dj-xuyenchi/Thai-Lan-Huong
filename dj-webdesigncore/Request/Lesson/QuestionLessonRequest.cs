using System;
namespace dj_webdesigncore.Request.Lesson
{
	public class QuestionLessonRequest
	{
        public string lessonName { get; set; }
        public string lessonDescription { get; set; }
        public string lessonTime { get; set; }
        public string question { get; set; }
        public string answerA { get; set; }
        public string answerB { get; set; }
        public string answerC { get; set; }
        public string answerD { get; set; }
        public int answer { get; set; }
    }
}

