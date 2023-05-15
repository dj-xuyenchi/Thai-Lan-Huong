using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.UserEntity
{
    public class Notification : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int? UserSendId { get; set; }
        public bool IsSeen { get; set; }
        public string Content { get; set; }
        public DateTime Create { get; set; }
        public string? Link { get; set; }
        public bool SystemNotification { get; set; }
    }
}
