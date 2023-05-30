﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Lobby
{
    public class PostDTO
    {
        public int Id { get; set; }
        public byte[] PostImg { get; set; }
        public byte[] CreaterAvatar { get; set; }
        public string CreaterFullName { get; set; }
        public string PostTitle { get; set; }
        public int LikeCount { get; set; }
        public int CmtCount { get; set; }
    }
}
