using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Study
{
    public class PracticeLessonDTO
    {
        public string Problem { get; set; }
        public string ProblemDetail { get; set; }
        public string BeginCodeMethod { get; set; }
        public string CallTestCode { get; set; }
        public string Input { get; set; }
        public string ExpectOutput { get; set; }
        public string Explain { get; set; }
        public string Suggest { get; set; }
        public List<TryTestCaseDTO> TestCase { get; set; }
    }
}
