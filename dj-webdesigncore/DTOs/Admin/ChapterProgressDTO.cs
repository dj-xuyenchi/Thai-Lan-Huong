using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class ChapterProgressDTO
    {
        public string Name { get; set; }
        public List<LessonProgressDTO> LessonProgressDTOs { get; set; }
    }
}
