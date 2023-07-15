using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class UserCourseProgress
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string CourseName { get; set; }
        public List<ChapterProgressDTO> Progress { get; set; }
    }
}
