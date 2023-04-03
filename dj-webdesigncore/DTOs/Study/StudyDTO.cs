using dj_webdesigncore.DTOs.Lobby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Study
{
    public class StudyDTO<T>
    {
        public T StudyDetail { get; set; }
        public List<LessonDetailDTO> LessonDetail { get; set; }

    }
}
