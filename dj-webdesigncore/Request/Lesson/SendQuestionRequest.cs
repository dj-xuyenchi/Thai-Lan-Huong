using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Request.Lesson
{
    public class SendQuestionRequest
    {
        public int UserId { get; set; }
        public int LessonId { get; set; }
        public int CourseId { get; set; }
        public int ChapterId { get; set; }
        public int Answer { get; set; }
    }
}
