using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Request.Lesson
{
    public class AddMultiLangue
    {
        public int id { get; set; }
        public int practiceLessonId { get; set; }
        public string beginCode { get; set; }
        public string callTestCode { get; set; }
        public int langueId { get; set; }
    }
}
