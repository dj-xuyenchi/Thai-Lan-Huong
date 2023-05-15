using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.CourseEntity
{
    public class MultiLangueCode : BaseEntity
    {
        public string BeginCodeMethod { get; set; }
        public string CallTestCode { get; set; }
        public int LangueId { get; set; }
        public Langue Langue { get; set; }
        public int PracticeId { get; set; }
        public PracticeLesson Practice { get; set; }
    }
}
