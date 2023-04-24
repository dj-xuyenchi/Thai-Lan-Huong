using dj_webdesigncore.Enums.CourseEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Study
{
    public class TryTestCaseDTO
    {
        public string Input { get; set; }
        public string Output { get; set; }
        public string ExpectOutput { get; set; }
        public TestCaseEnum Result { get; set; }
        public string RunTimeTotal { get; set; }
        public bool LockTestCase { get; set; }
    }
}
