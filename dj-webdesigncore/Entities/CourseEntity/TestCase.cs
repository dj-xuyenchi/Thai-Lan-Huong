using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.CourseEntity
{
    public class TestCase : BaseEntity
    {
        public int PracticeLessonId { get; set; }
        public PracticeLesson PracticeLesson { get; set; }
        public string? InputDetail { get; set; }
        public string? Input { get; set; }
        public string ExpectOutput { get; set; }
        public int SortNumber { get; set; }
        public bool LockTestCase { get; set; }
    }
}
