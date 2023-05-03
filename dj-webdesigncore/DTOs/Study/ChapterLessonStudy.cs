using dj_webdesigncore.DTOs.Lobby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Study
{
    public class ChapterLessonStudy
    {
        public List<ChapterDetailDTO> ChapterLesson { get; set; }
        public string CourseName { get; set; }
        public string UpdateTime { get; set; }
    }
}
