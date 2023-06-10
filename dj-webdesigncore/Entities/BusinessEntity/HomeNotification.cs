using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.BusinessEntity
{
    public class HomeNotification : BaseEntity
    {
        public string Title { get; set; }
        public DateTime Create { get; set; }
        public string Content { get; set; }
        public int UserPublicId { get; set; }
        public User UserPublic { get; set; }
        public string? Img { get; set; }
    }
}
