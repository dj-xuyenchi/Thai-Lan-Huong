using dj_webdesigncore.Business.UserIBusiness;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Study;
using dj_webdesigncore.DTOs.UserDTO;
using dj_webdesigncore.Entities.BusinessEntity;
using dj_webdesigncore.Entities.UserEntity;
using dj_webdesigncore.Enums.ApiEnums;
using dj_webdesigncore.Request.Account;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_actionlayer.Business.UserBusiness
{
    public class UserBusiness : BaseBusiness, IUserBusiness
    {
        public async Task<ResponData<List<District>>> getDistrict(string provinceCode)
        {
            ResponData<List<District>> result = new ResponData<List<District>>();
            result.Data = _context.districts.Where(x => x.province_code == provinceCode).ToList();
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<UserInforDTO>> getInformation(int userId)
        {
            ResponData<UserInforDTO> result = new ResponData<UserInforDTO>();
            User user = await _context.user.FindAsync(userId);
            if (user == null)
            {
                result.Data = null;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.NOTFOUND;
                return result;
            }
            UserInforDTO dto = new UserInforDTO();
            dto.Birthday = user.Birthday == null ? null : user.Birthday.Value.Day + " - " + user.Birthday.Value.Month + " - " + user.Birthday.Value.Year;
            Ward ward = await _context.wards.FindAsync(user.WardCode);
            dto.Ward = ward == null ? null : ward.full_name;
            dto.WardCode = user.WardCode;
            dto.UserFacebook = user.UserFacebook;
            dto.UserEmail = user.UserEmail;
            dto.UserLinkedIn = user.UserLinkedIn;
            dto.UserLastName = user.UserLastName;
            District district = await _context.districts.FindAsync(user.DistrictCode);
            dto.DistrictCode = user.DistrictCode;
            dto.District = district == null ? null : district.full_name;
            dto.UserAvatarData40x40 = user.UserAvatarData40x40;
            dto.UserDetail = user.UserDetail;
            dto.GenderName = _context.gender.Find(user.GenderId).GenderName;
            dto.NumberPhone = user.NumberPhone;
            dto.UserFisrtName = user.UserFisrtName;
            Province province = await _context.provinces.FindAsync(user.ProvinceCode);
            dto.ProvinceCode = user.ProvinceCode;
            dto.Province = province == null ? null : province.full_name;
            dto.GenderId = (int)user.GenderId;
            dto.AddressNow = user.AddressNow == null ? null : user.AddressNow;
            UserCatalog userCatalog = await _context.user_catalog.FindAsync(user.CatalogId);
            dto.Catalog = userCatalog == null ? null : userCatalog.CatalogName;
            dto.CatalogId = user.CatalogId == null ? null : user.CatalogId;
            dto.UserId = user.Id;
            if (user.ProvinceCode != null)
            {
                dto.provinces = _context.provinces.ToList();
                dto.districts = _context.districts.Where(x => x.province_code == user.ProvinceCode).ToList();
                dto.wards = _context.wards.Where(x => x.district_code == user.DistrictCode).ToList();
            }
            else
            {
                dto.provinces = _context.provinces.ToList();
            }
            dto.genders = _context.gender.ToList();
            dto.catalogs = _context.user_catalog.ToList();
            result.Data = dto;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<List<Ward>>> getWard(string districtCode)
        {
            ResponData<List<Ward>> result = new ResponData<List<Ward>>();
            result.Data = _context.wards.Where(x => x.district_code == districtCode).ToList();
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<OptionUpdateInfor>> optionUpdateInfor()
        {
            ResponData<OptionUpdateInfor> result = new ResponData<OptionUpdateInfor>();
            OptionUpdateInfor data = new OptionUpdateInfor();
            //data.districts = _context.districts.ToList();
            data.provinces = _context.provinces.ToList();
            //data.wards = _context.wards.ToList();
            data.genders = _context.gender.ToList();
            result.Data = data;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }


        public async Task<ResponData<ActionStatus>> updateUser(UpdateUserRequest updateUserRequest)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            var stream = new MemoryStream();
            //file.CopyTo(stream);
            byte[] avatar = stream.ToArray();

            return result;
        }
    }
}
