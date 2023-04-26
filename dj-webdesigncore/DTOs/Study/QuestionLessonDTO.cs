using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dj_webdesigncore.Entities.CourseEntity;

namespace dj_webdesigncore.DTOs.Study
{
    public class QuestionLessonDTO
    {
        public int LessonId { get; set; }
        public string Question { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
    }
}
