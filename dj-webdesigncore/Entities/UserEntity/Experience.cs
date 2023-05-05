using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.UserEntity
{
    public class Experience : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Detail { get; set; }
        public DateTime Open { get; set; }
        public DateTime? Close { get; set; }
        public string Position { get; set; }
    }
}
