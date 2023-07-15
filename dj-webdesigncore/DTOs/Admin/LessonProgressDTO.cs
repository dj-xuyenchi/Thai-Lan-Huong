using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class LessonProgressDTO
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string Time { get; set; }
        public bool IsDone { get; set; }
        public string OpenTime { get; set; }
        public string LessonType { get; set; }
        public int LessonTypeId { get; set; }

    }
}
