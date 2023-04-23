using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.BusinessEntity
{
    public class HomeContent : BaseEntity
    {
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public byte[]? Slide1 { get; set; }
        public byte[]? Slide2 { get; set; }
        public byte[]? Slide3 { get; set; }
        public byte[]? Slide4 { get; set; }
        public byte[]? Slide5 { get; set; }
    }
}
