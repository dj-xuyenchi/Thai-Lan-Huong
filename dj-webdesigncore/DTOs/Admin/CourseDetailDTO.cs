using dj_webdesigncore.Entities.CourseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class CourseDetailDTO
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string CourseSubTitle { get; set; }
        public string CourseImageData { get; set; }
        public int CourseLevelId { get; set; }
        public string CourseLevel { get; set; }
        public string LessonCount { get; set; }
        public string ChapterCount { get; set; }
        public string TimeLessonTotal { get; set; }
        public int RegisterCount { get; set; }
        public int DoneCount { get; set; }
        public int CourseStatusId { get; set; }
        public string LinkVideoIntro { get; set; }
        public string CourseStatus { get; set; }
        public int CourseTypeId { get; set; }
        public string CourseType { get; set; }
    }
}
