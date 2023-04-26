using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Lobby
{
    public class ChapterDetailDTO
    {
        public string ChapterTitle { get; set; }
        public int LessonCount { get; set; }
        public int ChapterId { get; set; }
        public List<LessonDetailDTO> LessonDetail { get; set; }
    }
}
