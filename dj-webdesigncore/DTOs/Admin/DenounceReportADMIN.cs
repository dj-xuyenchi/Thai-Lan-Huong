using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class DenounceReportADMIN
    {
        public int denounceId { get; set; }
        public int senderId { get; set; }
        public string senderImg { get; set; }
        public string senderName { get; set; }
        public bool senderKYC { get; set; }
        public string vioImg { get; set; }
        public bool vioKYC { get; set; }
        public string vioName { get; set; }
        public string cmtDenounceContent { get; set; }
        public string note { get; set; }
        public string sendTime { get; set; }
        public string linkCmt { get; set; }
        public string typeDenounce { get; set; }
        public int VioCount { get; set; }
        public int vioId { get; set; }
    }
}
