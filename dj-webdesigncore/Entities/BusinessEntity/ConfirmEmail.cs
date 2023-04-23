using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.BusinessEntity
{
    public class ConfirmEmail : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime RequiredDateTime { get; set; }
        public DateTime ExpiredDateTime { get; set; }
        public string Code { get; set; }
        public bool IsConfirm { get; set; }
    }
}
