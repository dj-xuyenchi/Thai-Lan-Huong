using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.UserEntity
{
    public class LearningExperience : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public int MajorsId { get; set; }
        public Majors Majors { get; set; }
        public DateTime Open { get; set; }
        public DateTime Close { get; set; }
    }
}
