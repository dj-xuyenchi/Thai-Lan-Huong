using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Request.Blog
{
    public class AddBlogRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int StatusId { get; set; }
    }
}
