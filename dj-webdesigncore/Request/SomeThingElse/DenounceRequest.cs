using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Request.SomeThingElse
{
    public class DenounceRequest
    {
        public int UserSendId { get; set; }
        public string Note { get; set; }
        public int CmtId { get; set; }
        public int TypeId { get; set; }
        public string URL { get; set; }
    }
}
