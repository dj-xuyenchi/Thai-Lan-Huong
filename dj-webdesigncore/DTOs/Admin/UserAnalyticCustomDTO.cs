using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class UserAnalyticCustomDTO
    {
        public List<string> date { get; set; }
        public List<int> newUser { get; set; }
        public List<int> lockUser { get; set; }
        public List<int> lockForeverUser { get; set; }
     }
}
