using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Post
{
    public class SuggestPostDTO
    {
        public int Id { get; set; }
        public string PostImg { get; set; }
        public string Title { get; set; }
        public int CmtCount { get; set; }
        public int LikeCount { get; set; }
        public int Status { get; set; }
    }
}
