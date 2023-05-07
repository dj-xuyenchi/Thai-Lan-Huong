using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Request.FunixRequest
{
    public class PracticeLessonGPT
    {
        public string problem { get; set; }
        public string problemDetail { get; set; }
        public string codeBegin { get; set; }
        public string explain { get; set; }
        public string suggest { get; set; }
        public List<TestCaseGPT> testCases { get; set; }
    }
}
