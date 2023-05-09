using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.BusinessEntity
{
    public class UserCatalog : BaseEntity
    {
        public string CatalogCode { get; set; }
        public string CatalogName { get; set; }
    }
}
