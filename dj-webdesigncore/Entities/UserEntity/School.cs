using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.UserEntity
{
    public class School : BaseEntity
    {
        public string SchoolName { get; set; }
        public int? SchoolTypeId { get; set; }
        public SchoolType? SchoolType { get; set; }
    }
}

