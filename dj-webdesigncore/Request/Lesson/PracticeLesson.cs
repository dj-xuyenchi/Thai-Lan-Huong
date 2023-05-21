using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Request.Lesson
{
    public class PracticeLesson
    {
        public string lessonName { get; set; }
        public string lessonDescription { get; set; }
        public string lessonTime { get; set; }
        public string problem { get; set; }
        public string problemDetail { get; set; }
        public string? caseDefaultDetail { get; set; }
        public string? callTestCode { get; set; }
        public string? beginCode  { get; set; }
        public string? inputExemple  { get; set; }
        public string outputExemple  { get; set; }
        public string explainCode { get; set; }
        public string suggest { get; set; }
        public int langueId { get; set; }
        public bool isSupportMutilLangue { get; set; }
    }
}
