using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class AnalyticAppDTO
    {
        public List<AnalyticUserItemDTO> ListWeek { get; set; }
        public List<AnalyticUserItemDTO> ListMonth { get; set; }
    }
}
