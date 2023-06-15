using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Request.Post
{
    public class UpdatePostAdminRequest
    {
        public int PostId { get; set; }
        public string PostData { get; set; }
        public string PostTitle { get;set; }
        public int PostStatusId { get; set; }
    }
}
