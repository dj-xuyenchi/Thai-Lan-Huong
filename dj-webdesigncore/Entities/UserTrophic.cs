using dj_webdesigncore.Entities.BusinessEntity;
using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities
{
    public class UserTrophic : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int TrophicId { get; set; }
        public Trophic Trophic { get; set; }
        public DateTime TakeTrophicDatetime { get; set; }
    }
}
