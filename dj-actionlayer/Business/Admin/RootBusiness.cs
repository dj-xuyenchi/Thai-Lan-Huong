using dj_webdesigncore.Business.Admin;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.Entities.UserEntity;
using dj_webdesigncore.Enums.ApiEnums;
using dj_webdesigncore.Request.Account;
using Microsoft.AspNetCore.Http;
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
        public async Task<IQueryable<User>> FindUserByNameEmail(string key, int page)
        {
            var listPage = _context.user.Include(x => x.Role).Where(x => x.UserLastName.Contains(key) || x.UserFisrtName.Contains(key) || x.UserEmail.Contains(key)).OrderByDescending(x => x.CreateAccount).Skip((page - 1) * 15).Take(15);
            return listPage;
        }

        public async Task<IQueryable<User>> GetUserDenounce(int page)
        {
            var listPage = _context.user.Include(x => x.Role).Where(x => x.UserStatusId == 4).OrderByDescending(x => x.CreateAccount).Skip((page - 1) * 15).Take(15);
            return listPage;
        }

        public async Task<IQueryable<User>> GetUserPage(int page)
        {
            var listPage = _context.user.Include(x => x.Role).OrderByDescending(x => x.CreateAccount).Skip((page - 1) * 15).Take(15);
            return listPage;
        }

        public Task<ResponData<ActionStatus>> updateUser(IFormFile avatar, UpdateUserRequest updateUserRequest)
        {
            throw new NotImplementedException();
        }
    }
}
