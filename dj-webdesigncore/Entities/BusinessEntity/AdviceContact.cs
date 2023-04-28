using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.BusinessEntity
{
    public class AdviceContact : BaseEntity
    {
        public string Name { get; set; }
        public string Sdt { get; set; }
        public bool IsContact { get; set; }
    }
}
