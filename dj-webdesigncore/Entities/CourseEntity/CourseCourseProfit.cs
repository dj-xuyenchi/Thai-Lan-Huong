using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.CourseEntity
{
    public class CourseCourseProfit : BaseEntity
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int CourseProfitId { get; set; }
        public CourseProfit CourseProfit { get; set; }
        public int SortNumber { get; set; }
    }
}
