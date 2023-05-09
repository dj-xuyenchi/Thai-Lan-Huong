using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.BusinessEntity
{
    public class AdviceContact : BaseEntity
    {
        public string Name { get; set; }
        public string Sdt { get; set; }
        public bool IsContact { get; set; }
        public DateTime SendRequest { get;set; }
        public int? UserContactId { get; set; }
        public User? UserContact { get; set; }
        public DateTime? ContactTime { get; set; }
        public int? Rate { get; set; }
        public string? Evaluate { get; set; }
    }
}
