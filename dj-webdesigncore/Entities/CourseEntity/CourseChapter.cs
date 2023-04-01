using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.CourseEntity
{
    public class CourseChapter : BaseEntity
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string ChapterName { get; set; }
        public string ChapterTotalTime { get; set; }
        public int ChapterLessonCount { get; set; }
        public DateTime ChapterCreateDateTime { get; set; }
        public int SortNumber { get; set; }
    }
}
