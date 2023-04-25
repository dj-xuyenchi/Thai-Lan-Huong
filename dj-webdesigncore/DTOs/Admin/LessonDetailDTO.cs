using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class LessonDetailDTO
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string LessonDescription { get; set; }
        public string CreateDateTime { get; set; }
        public string? UpdateDateTime { get; set; }
        public string LessonType { get; set; }
        public string VideoTime { get; set; }
        public int LessonTypeId { get; set; }
    }
}
