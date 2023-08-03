using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class CourseAnaDTO
    {
        public List<string> ListCourse { get; set; }
        public List<int> CourseId { get; set; }
        public List<int> Total { get; set; }
        public List<int> Learning { get;set; }
        public List<int> Done { get;set; }
    }
}
