using dj_webdesigncore.Enums.Else;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class AdviceContactDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime SendRequest { get; set; }
        public TypeAdviceEnum TypeAdvice { get; set; }
    }
}
