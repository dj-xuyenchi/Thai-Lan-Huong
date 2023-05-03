using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Request.Chapter
{
    public class UpdateSortNumberLessonRequest
    {
        public int LessonId { get; set; }
        public int Id { get; set; }
        public int SortNumber { get; set; }
        public int CourseChapterId { get; set; }
    }
}
