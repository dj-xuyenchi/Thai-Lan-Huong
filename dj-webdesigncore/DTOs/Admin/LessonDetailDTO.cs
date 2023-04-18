using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class LessonDetailDTO
    {
        public string LessonName { get; set; }
        public string LessonDescription { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public string LessonType { get; set; }
        public string VideoTime { get; set; }
    }
}
