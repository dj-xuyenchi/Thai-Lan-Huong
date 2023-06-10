using dj_webdesigncore.Enums.ApiEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.UserDTO
{
    public class UpdateDTO
    {
        public ActionStatus status { get; set; }
        public string avatar { get; set; }
        public string nickName { get; set; }
        public string name { get; set; }
    }
}
