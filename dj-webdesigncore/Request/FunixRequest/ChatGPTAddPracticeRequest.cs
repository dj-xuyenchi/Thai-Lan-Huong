using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Request.FunixRequest
{
    public class ChatGPTAddPracticeRequest
    {
        public string tenBai { get; set; }
        public PracticeLessonGPT practiceLesson { get; set; }
    }
}
