using dj_webdesigncore.Entities.CourseEntity;
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
        public int ChapterLessonId { get; set; }
        public int SortNumber { get; set; }
        public string LessonName { get; set; }
        public string LessonDescription { get; set; }
        public string CreateDateTime { get; set; }
        public string? UpdateDateTime { get; set; }
        public int practiceId { get; set; }
        public string LessonType { get; set; }
        public string VideoTime { get; set; }
        public int LessonTypeId { get; set; }
        public string linkVideo { get; set; }
        public string question { get; set; }
        public string answerA { get; set; }
        public string answerB { get; set; }
        public string answerC { get; set; }
        public string answerD { get; set; }
        public string answer { get; set; }
        public string problem { get; set; }
        public string problemDetail { get; set; }
        public string beginCode { get; set; }
        public string caseDefaultDetail { get; set; }
        public string callTestCode { get; set; }
        public string inputExemple { get; set; }
        public string outputExemple { get; set; }
        public string explainCode { get; set; }
        public string suggest { get; set; }
        public bool isSupportMultiLangue { get; set; }
        public Langue langue { get; set; }
        //
        public int stt { get; set; }
    }
}
