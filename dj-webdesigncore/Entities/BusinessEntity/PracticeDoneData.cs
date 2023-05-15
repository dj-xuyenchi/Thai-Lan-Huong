using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.BusinessEntity
{
    public class PracticeDoneData : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public PracticeLesson PracticeLesson { get; set; }
        public int PracticeLessonId { get; set; }
        public string DoneData { get; set; }
        public DateTime? DoneTime { get; set; }
        public int? LangueId { get; set; }
        public Langue? Langue { get; set; }
    }
}
