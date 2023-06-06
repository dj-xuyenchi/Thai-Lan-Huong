using dj_webdesigncore.Business.Admin;
using dj_webdesigncore.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_actionlayer.Business.Admin
{
    public class RootBusiness : BaseBusiness, IRootBusiness
    {
        public async Task<IQueryable<User>> GetUserDenounce(int page)
        {
            var listPage = _context.user.Include(x => x.Role).Where(x=>x.UserStatusId==4).Skip((page - 1) * 15).Take(15);
            return listPage;
        }

        public async Task<IQueryable<User>> GetUserPage(int page)
        {
            var listPage = _context.user.Include(x => x.Role).Skip((page - 1) * 15).Take(15);
            return listPage;
        }
    }
}
