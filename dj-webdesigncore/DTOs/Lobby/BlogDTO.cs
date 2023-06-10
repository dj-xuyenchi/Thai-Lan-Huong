using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Lobby
{
    public class BlogDTO
    {
        public int Stt { get; set; }
        public int Id { get; set; }
        public int IsActive { get; set; }
        public int ViewCount { get; set; }
        public int CmtCount { get; set; }
        public string Title { get; set; }
        public string BlogLink { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
        public string BlogImg { get; set; }
        public int StatusId { get; set; }
    }
}
