using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Enums.AuthEnums
{
    public enum AuthStatusEnum
    {
        SUCCESS = 0,
        FAILED = 1,
        UNACTIVEUSER = 2,
        EXPIRED = 3,
        LOCKFOREVER = 4,
        LOCKED = 5
    }
}
