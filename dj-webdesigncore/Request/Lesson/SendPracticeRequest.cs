using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Request.Lesson
{
    public class SendPracticeRequest
    {
        public int UserId { get; set; }
        public int LessonId { get; set; }
        public int ChapterId { get; set; }
        public string Code { get; set; }
        public int langueId { get; set; }
    }
}
