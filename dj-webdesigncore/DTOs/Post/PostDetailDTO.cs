using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Post
{
    public class PostDetailDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int LikeCount { get; set; }
        public bool IsLiked { get; set; }
        public byte[] CreaterImg { get; set; }
        public string CreaterFullName { get; set; }
        public bool IsCreaterKYC { get; set; }
        public string CreatePostTime { get; set; }
        public List<SuggestPostDTO> SuggestPost { get; set; }

    }
}
