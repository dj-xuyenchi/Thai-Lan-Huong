using dj_webdesigncore.Enums.CourseEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Lobby
{
    public class LessonDetailDTO
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string LessonTime { get; set; }
        public bool IsDone { get; set; }
        public LessonType LessonType { get; set; }
    }
}
