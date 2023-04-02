using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.CourseEntity
{
    public class CourseRequire : BaseEntity
    {
        public string CourseRequireName { get; set; }
        public DateTime CourseRequireCreateDateTime { get; set; }
    }
}
