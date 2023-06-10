using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class PostAdminDTO
    {
        public int Id { get; set; }
        public string PostImg { get; set; }
        public string PostMetaImg { get; set; }
        public string Title { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
    }
}
