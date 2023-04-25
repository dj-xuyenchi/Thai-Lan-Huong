using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class GetCourseDTO
    {
        public List<CourseDetailDTO> list { get; set; }
        public int maxPage { get; set; }
    }
}
