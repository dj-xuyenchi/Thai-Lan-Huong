using dj_webdesigncore.Entities.CourseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class MultiLangueDTO
    {
        public int id { get; set; }
        public string LangueCode { get; set; }
        public string BeginCode { get; set; }
        public string CallTestCode { get; set; }
        public Langue langue { get; set; }
    }
}
