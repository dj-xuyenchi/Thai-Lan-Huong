using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.UserDTO
{
    public class UserInforDTO
    {
        public int UserId { get; set; }
        public byte[] UserAvatarData40x40 { get; set; }
        public string UserEmail { get; set; }
        public string UserFacebook { get; set; }
        public string UserLinkedIn { get; set; }
        public string UserFisrtName { get; set; }
        public string UserLastName { get; set; }
        public string NumberPhone { get; set; }
        public string UserDetail { get; set; }
        public string Birthday { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public string Ward { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
    }
}
