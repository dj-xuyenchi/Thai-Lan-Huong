using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Business.Admin
{
    public interface IRootBusiness
    {
        public Task<IQueryable<User>> GetUserPage(int page);
        public Task<IQueryable<User>> GetUserDenounce(int page);
    }
}
