using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class ListStudentOfCourse
    {
        public int StudentId { get; set; }
        public string StudentAvatar { get; set; }
        public string StudentName { get; set; }
        public string ThisProcess { get; set; }
        public string Evalute { get; set; }
        public bool IsKYC { get; set; }
    }
}
