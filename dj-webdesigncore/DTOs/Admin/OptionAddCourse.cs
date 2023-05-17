using dj_webdesigncore.Entities.CourseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class OptionAddCourse
    {
        public List<CourseType> Type { get; set; }
        public List<CourseLevel> Level { get; set; }
        public List<CourseStatus> Status { get; set; }
    }
}
