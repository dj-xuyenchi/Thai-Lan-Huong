using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Request.SomeThingElse
{
    public class ConfirmDenounceRequest
    {
        public int DenounceId { get; set; }
        public int VioId { get;set; }
        public int UserCheckId { get; set; }
        public int LockOpt { get; set; }
        public bool IsVio { get; set; }
    }
}
