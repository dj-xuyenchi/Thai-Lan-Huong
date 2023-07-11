using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.CourseEntity
{
    public class ChapterLesson : BaseEntity
    {
        public int CourseChapterId { get; set; }
        public CourseChapter CourseChapter { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; } 
        public int SortNumber { get; set; }
        public DateTime AddLessonToChapterDateTime { get; set; }
        
    }
}
