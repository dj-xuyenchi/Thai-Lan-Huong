using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Study
{
    public class CommentDetailDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserAvatar { get; set; }
        public int LikeCount { get; set; }
        public int CommentId { get; set; }
        public bool IsLike { get; set; }
        public string Comment { get; set; }
        public List<SubComment>  SubComment { get; set; }
        public string CommentDate { get; set; }
        public bool IsKYC { get; set; }
    }
}
