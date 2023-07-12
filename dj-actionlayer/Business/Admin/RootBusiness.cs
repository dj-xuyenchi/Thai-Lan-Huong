using dj_actionlayer.DAO;
using DJ_UploadFile.Services;
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
        public async Task<ResponData<ActionStatus>> createUser(IFormFile avatar, UpdateUserRequest updateUserRequest)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            if (await _context.user.AnyAsync(x => x.UserEmail.Equals(updateUserRequest.email)))
            {
                result.Data = ActionStatus.EMAILEXIST;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            if (await _context.user.AnyAsync(x => x.NumberPhone.Equals(updateUserRequest.sdt)))
            {
                result.Data = ActionStatus.SDTEXIST;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            if (await _context.user.AnyAsync(x => x.UserName.Equals(updateUserRequest.userName)))
            {
                result.Data = ActionStatus.USEREXIST;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            User user = new User();
            user.UserName = updateUserRequest.userName;
            user.UserStatusId = 1;
            user.UserPass = updateUserRequest.userPass;
            user.UserRoleId = updateUserRequest.roleId;
            user.UserLastName = updateUserRequest.lastName;
            user.UserFisrtName = updateUserRequest.firstName;
            user.UserEmail = updateUserRequest.email;
            user.NumberPhone = updateUserRequest.sdt;
            user.GenderId = updateUserRequest.gender;
            user.IsKYC = updateUserRequest.isKYC;
            user.CreateAccount = DateTime.Now;
            if (avatar != null)
            {
                user.UserAvatarData40x40 = await CloudinaryUpload.UploadFile(avatar);
            }
            else
            {
                user.UserAvatarData40x40 = "https://res.cloudinary.com/dushydq6r/image/upload/v1686398105/xyz-abc_1286085158_6/10/vhwjtmzsygp0f2t1o8wc.jpg";
            }
            if (updateUserRequest.birthday.Year != 1000)
            {
                user.Birthday = updateUserRequest.birthday;
            }
            if (updateUserRequest.facebook != null)
            {
                user.UserFacebook = updateUserRequest.facebook;
            }
            if (updateUserRequest.linkedIn != null)
            {
                user.UserLinkedIn = updateUserRequest.linkedIn;
            }
            if (updateUserRequest.addressNow != null)
            {
                user.AddressNow = updateUserRequest.addressNow;
            }
            if (updateUserRequest.province != null)
            {
                user.ProvinceCode = updateUserRequest.province;
                user.WardCode = updateUserRequest.ward;
                user.DistrictCode = updateUserRequest.district;
            }
            user.CatalogId = updateUserRequest.catalog;
            if (updateUserRequest.detail != null)
            {
                user.UserDetail = updateUserRequest.detail;
            }
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<IQueryable<User>> FindUserByNameEmail(string key, int page)
        {
            var listPage = _context.user.Include(x => x.Role).Include(x => x.Gender).Include(x => x.Catalog).Include(x => x.UserStatus).Include(x => x.Province).Include(x => x.District).Include(x => x.Ward).Where(x => x.UserLastName.Contains(key) || x.UserFisrtName.Contains(key) || x.UserEmail.Contains(key)).OrderByDescending(x => x.CreateAccount).Skip((page - 1) * 15).Take(15);
            return listPage;
        }

        public async Task<IQueryable<User>> GetUserDenounce(int page)
        {
            var listPage = _context.user.Include(x => x.Role).Where(x => x.UserStatusId == 4).OrderByDescending(x => x.CreateAccount).Skip((page - 1) * 15).Take(15);
            return listPage;
        }

        public async Task<IQueryable<User>> GetUserPage(int page)
        {
            var listPage = _context.user.Include(x => x.Role).Include(x => x.Gender).Include(x => x.Catalog).Include(x => x.UserStatus).Include(x => x.Province).Include(x => x.District).Include(x => x.Ward).OrderByDescending(x => x.CreateAccount).Skip((page - 1) * 15).Take(15);
            return listPage;
        }

        public async Task<ResponData<ActionStatus>> updateUser(IFormFile avatar, UpdateUserRequest updateUserRequest)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            if (await _context.user.AnyAsync(x => x.UserEmail.Equals(updateUserRequest.email) && x.Id != updateUserRequest.userId))
            {
                result.Data = ActionStatus.EMAILEXIST;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            if (await _context.user.AnyAsync(x => x.NumberPhone.Equals(updateUserRequest.sdt) && x.Id != updateUserRequest.userId))
            {
                result.Data = ActionStatus.SDTEXIST;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            if (await _context.user.AnyAsync(x => x.UserName.Equals(updateUserRequest.userName) && x.Id != updateUserRequest.userId))
            {
                result.Data = ActionStatus.USEREXIST;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            User user = await _context.user.FindAsync(updateUserRequest.userId);
            user.UserName = updateUserRequest.userName;
            user.UserStatusId = 1;
            if (updateUserRequest.isChangePass)
            {
            user.UserPass = updateUserRequest.userPass;
            }
            user.UserRoleId = updateUserRequest.roleId;
            user.UserLastName = updateUserRequest.lastName;
            user.UserFisrtName = updateUserRequest.firstName;
            user.UserEmail = updateUserRequest.email;
            user.NumberPhone = updateUserRequest.sdt;
            user.UserStatusId = updateUserRequest.statusId;
            if (updateUserRequest.statusId == 1)
            {
                user.IsLock = false;
            }
            if (updateUserRequest.statusId == 4)
            {
                user.IsLock = true;
                user.OpenLockTime = DateTime.Now;
                user.VioCount++;
                switch (updateUserRequest.lockOpt)
                {
                    case 1:
                        user.UserStatusId = 4;
                        user.UnlockTime = DateTime.Now.AddDays(3);
                        break;
                    case 2:
                        user.UserStatusId = 4;
                        user.UnlockTime = DateTime.Now.AddDays(5);
                        break;
                    case 3:
                        user.UserStatusId = 4;
                        user.UnlockTime = DateTime.Now.AddDays(7);
                        break;
                    case 4:
                        user.UserStatusId = 2;
                        break;
                }
            }
            user.GenderId = updateUserRequest.gender;
            user.IsKYC = updateUserRequest.isKYC;
            user.Update = DateTime.Now;
            if (avatar != null)
            {
                user.UserAvatarData40x40 = await CloudinaryUpload.UploadFile(avatar);
            }
            if (updateUserRequest.birthday.Year != 1000)
            {
                user.Birthday = updateUserRequest.birthday;
            }
            if (updateUserRequest.facebook != null)
            {
                user.UserFacebook = updateUserRequest.facebook;
            }
            if (updateUserRequest.linkedIn != null)
            {
                user.UserLinkedIn = updateUserRequest.linkedIn;
            }
            if (updateUserRequest.addressNow != null)
            {
                user.AddressNow = updateUserRequest.addressNow;
            }
            if (updateUserRequest.province != null)
            {
                user.ProvinceCode = updateUserRequest.province;
                user.WardCode = updateUserRequest.ward;
                user.DistrictCode = updateUserRequest.district;
            }
            user.CatalogId = updateUserRequest.catalog;
            if (updateUserRequest.detail != null)
            {
                user.UserDetail = updateUserRequest.detail;
            }
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }
    }
}
