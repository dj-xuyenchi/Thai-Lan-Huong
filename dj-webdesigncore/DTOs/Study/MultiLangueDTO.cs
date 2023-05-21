using dj_webdesigncore.Entities.CourseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Study
{
    public class MultiLangueDTO
    {
        public int id {  get; set; }
        public string BeginCodeMethod { get; set; }
        public string CallTestCode { get; set; }
        public int LangueId { get; set; }
        public int PracticeId { get; set; }
    }
}
