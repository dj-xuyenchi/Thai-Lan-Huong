using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.UserDTO
{
    public class NotificationDTO
    {
        public int NotificationId { get; set; }
        public string Content { get; set; }
        public string Avatar { get; set; }
        public bool IsKYC { get; set; }
        public string Link { get; set; }
        public bool IsSeen { get; set; }
        public string SendTime { get; set; }
    }
}
