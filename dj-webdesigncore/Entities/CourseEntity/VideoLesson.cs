using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.CourseEntity
{
    public class VideoLesson : BaseEntity
    {
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public string LessonLinkUrl { get; set; }
    }
}
