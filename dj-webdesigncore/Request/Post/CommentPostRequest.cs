using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Request.Post
{
    public class CommentPostRequest
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string CommentContent { get; set; }
    }
}
