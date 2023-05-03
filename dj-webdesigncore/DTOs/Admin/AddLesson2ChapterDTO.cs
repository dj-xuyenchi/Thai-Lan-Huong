using dj_webdesigncore.Enums.CourseEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class AddLesson2ChapterDTO
    {
        public AddStatusEnum Status { get; set; }
        public string Mes { get; set; }
    }
}
