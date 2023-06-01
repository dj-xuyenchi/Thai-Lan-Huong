using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Post
{
    public class PostMain
    {
        public PostItem HotPost { get; set; }
        public List<PostItem> PostCreateOrderBy { get; set; }
    }
}
