using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class ChapterCourseInfo
    {
        public int id { get; set; }
        public int sortNumber { get; set; }
        public string name { get; set; }
        public int lessonCount { get; set; }
        public string totalTime { get; set; }
    }
}
