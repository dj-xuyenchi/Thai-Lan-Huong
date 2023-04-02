using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.CourseEntity
{
    public class CourseCourseRequire : BaseEntity
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int CourseRequireId { get; set; }
        public CourseRequire CourseRequire { get; set; }
        public int SortNumber { get; set; }
    }
}
