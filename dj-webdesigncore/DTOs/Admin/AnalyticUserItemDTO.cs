using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class AnalyticUserItemDTO
    {
        public string Category { get; set; }
        public int[] DataWeek { get; set; }
        public int[] DataMonth { get; set; }
    }
}
