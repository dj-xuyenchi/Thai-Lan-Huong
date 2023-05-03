using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.BusinessEntity
{
    public class VideoDoneData : BaseEntity
    {
        public int VideoLessonId { get; set; }
        public VideoLesson VideoLesson { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime? DoneTime { get; set; }
    }
}
