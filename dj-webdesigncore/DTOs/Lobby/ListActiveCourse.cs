using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Lobby
{
    public class ListActiveCourse
    {
        public int StudyingStudent { get; set; }
        public int StudyedStudent { get; set; }
        public IList<CourseDTO> courseDTOs { get; set; }
    }
}
