using dj_webdesigncore.Enums.CourseEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Study
{
    public class RegisterCourseDTO
    {
        public RegisterEnum Status { get; set; }
        public string Mes { get; set; }
        public int CourseId { get; set; }
        public int LessonId { get; set; }
        public int ChapterId { get; set; }
    }
}
