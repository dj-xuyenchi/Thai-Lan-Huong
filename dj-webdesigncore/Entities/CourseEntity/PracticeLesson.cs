using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.CourseEntity
{
    public class PracticeLesson : BaseEntity
    {
        public string Problem { get; set; }
        public string ProblemDetail { get; set;}
        public string Input { get; set;}
        public string ExpecOutput { get; set;}
        public string Explain { get; set;}
        public string Suggest { get; set; }
        
    }
}
