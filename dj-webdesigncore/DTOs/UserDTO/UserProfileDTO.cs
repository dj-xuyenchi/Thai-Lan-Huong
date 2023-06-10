using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.UserDTO
{
    public class UserProfileDTO
    {
        public string Avatar { get; set; }
        public string FullName { get; set; }
        public bool IsKYC { get; set; }
        public string WallImg { get; set; }
        public string Introduce { get; set; }
        public string JoinTime { get; set; }
        public List<ResigtedUserCourseDTO> ResigtedCourse { get; set; }
    }
}
