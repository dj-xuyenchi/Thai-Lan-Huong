using dj_webdesigncore.DTOs.UserDTO;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.Entities.UserEntity;
using dj_webdesigncore.Request.Account;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dj_webdesigncore.Enums.ApiEnums;

namespace dj_webdesigncore.Business.Admin
{
    public interface IRootBusiness
    {
        Task<IQueryable<User>> GetUserPage(int page);
        Task<IQueryable<User>> GetUserDenounce(int page);
        Task<IQueryable<User>> FindUserByNameEmail(string key, int page);
        Task<ResponData<ActionStatus>> createUser(IFormFile avatar, UpdateUserRequest updateUserRequest);
        Task<ResponData<ActionStatus>> updateUser(IFormFile avatar, UpdateUserRequest updateUserRequest);
    }
}
