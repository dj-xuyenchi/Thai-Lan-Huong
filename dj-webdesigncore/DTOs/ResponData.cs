using dj_webdesigncore.Enums.ApiEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs
{
    public class ResponData<T>
    {
        public ActionStatus Status { get; set; } 
        public T Data { get; set; }
        public string Messenger { get; set; }
    }
}
