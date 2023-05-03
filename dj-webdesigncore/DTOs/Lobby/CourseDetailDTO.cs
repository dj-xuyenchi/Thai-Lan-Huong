using dj_webdesigncore.Entities.CourseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Lobby
{
    public class CourseDetailDTO
    {
        public string CourseTitle { get; set; }
        public bool isRegistered { get; set; }
        public int courseId { get; set; }
        public int lessonId { get; set; }
        public string CourseSubTitle { get; set; }
        public List<CourseProfit> CourseProfit { get; set; }
        public List<CourseRequire> CourseRequire { get; set; }
        public List<ChapterDetailDTO> ChapterDetail { get; set; }
        public int ChapterCount { get; set; }
        public int LessonCount { get; set; }
        public string TimeTotal { get; set; }
        public string IntroVideoPath { get; set; }
    }
}
