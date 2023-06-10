using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.BlogEntity
{
    public class Blog : BaseEntity
    {
        public int ViewCount { get; set; }
        public int CmtCount { get; set; }
        public string BlogImg { get; set; }
        public string BlogLink { get; set; }
        public string BlogTitle { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int StatusId { get; set; }
        public BlogStatus Status { get; set; }
        public int BlogTypeId { get; set; }
        public BlogType BlogType { get; set; }
    }
}
