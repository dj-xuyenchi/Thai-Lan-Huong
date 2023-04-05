using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Lobby
{
    public class CourseListDTO
    {
        public bool IsEmpty { get; set; }
        public string CourseType { get; set; }
        public List<CourseDTO> CourseListByType { get; set; }
    }
}
