﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Study
{
    public class SubComment
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int LikeCount { get; set; }
        public byte[] UserAvatar { get; set; }
        public string Comment { get; set; }
        public string CommentDate { get; set; }
    }
}
