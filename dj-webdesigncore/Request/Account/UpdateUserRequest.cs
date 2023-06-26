using dj_webdesigncore.Entities.BusinessEntity;
using dj_webdesigncore.Entities.UserEntity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Request.Account
{
    public class UpdateUserRequest
    {
        public int? userId { get; set; }
        public bool isChangePass { get; set; }
        public string userName { get; set; }
        public string userPass { get; set; }
        public string facebook { get; set; }
        public string linkedIn { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string sdt { get; set; }
        public string detail { get; set; }
        public DateTime birthday { get; set; }
        public int? gender { get; set; }
        public string province { get; set; }
        public string ward { get; set; }
        public string district { get; set; }
        public string addressNow { get; set; }
        public int? catalog { get; set; }
        public int roleId { get; set; }
        public string email { get; set; }
        public bool isKYC { get; set; }
        public int statusId { get; set; }
        public int lockOpt { get; set; }
    }
}
