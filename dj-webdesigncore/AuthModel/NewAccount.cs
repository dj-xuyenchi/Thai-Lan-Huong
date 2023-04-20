using dj_webdesigncore.Enums.AuthEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.AuthModel
{
    public class NewAccount
    {
        public SignInEnum Status { get; set; }
        public string Email { get; set; }
        public string Detail { get; set; }
    }
}
