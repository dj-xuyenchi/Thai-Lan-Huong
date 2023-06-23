using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class UserAnalyticCustomDTO
    {
        public string[] date { get; set; }
        public int[] newUser { get; set; }
        public int[] lockUser { get; set; }
        public int[] lockForeverUser { get; set; }
     }
}
