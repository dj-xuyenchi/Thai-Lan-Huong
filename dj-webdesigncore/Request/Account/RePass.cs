using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Request.Account
{
    public class RePass
    {
        public int Id { get; set; }
        public string OldPass { get; set; }
        public string NewPass { get; set; }
    }
}
