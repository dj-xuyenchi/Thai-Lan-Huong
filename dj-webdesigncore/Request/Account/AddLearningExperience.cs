using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Request.Account
{
    public class AddLearningExperience
    {
        public int userId { get; set; }
        public int school { get; set; }
        public int majors { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}
