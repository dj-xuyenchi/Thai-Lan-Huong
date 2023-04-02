using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.BusinessEntity
{
    public class UserLessonCheckpoint :BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public DateTime OpenLessonDateTime { get; set; }
        public bool IsDone { get; set; }
    }
}
