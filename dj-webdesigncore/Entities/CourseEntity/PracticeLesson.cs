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
        public string? BeginCodeMethod { get; set; }
        public string? CallTestCode { get; set; }
        public string? Input { get; set;}
        public string ExpectOutput { get; set;}
        public string? Explain { get; set;}
        public string? Suggest { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public bool? IsSupportMultiLangue { get; set; }
        public int? LangueDefaultId { get; set; }
        public Langue? LangueDefault { get; set; }
        public IEnumerable<TestCase> testCases { get; set; }
    }
}
