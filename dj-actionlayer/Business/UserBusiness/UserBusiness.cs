using dj_webdesigncore.Business.UserIBusiness;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Study;
using dj_webdesigncore.DTOs.UserDTO;
using dj_webdesigncore.Entities.UserEntity;
using dj_webdesigncore.Enums.ApiEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_actionlayer.Business.UserBusiness
{
    public class UserBusiness : BaseBusiness, IUserBusiness
    {
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
            dto.Birthday = user.Birthday == null ? "Chưa cập nhật" : user.Birthday.Value.Day + " - " + user.Birthday.Value.Month + " - " + user.Birthday.Value.Year;
            dto.Ward = "Chưa cập nhật!";
            dto.UserFacebook = user.UserFacebook;
            dto.UserEmail = user.UserEmail;
            dto.UserLinkedIn = user.UserLinkedIn;
            dto.UserLastName = user.UserLastName;
            dto.District = "Chưa cập nhật!";
            dto.UserAvatarData40x40 = user.UserAvatarData40x40;
            dto.UserDetail = user.UserDetail;
            dto.GenderName = _context.gender.Find(user.GenderId).GenderName;
            dto.NumberPhone = user.NumberPhone;
            dto.UserFisrtName = user.UserFisrtName;
            dto.Province = "Chưa cập nhật!";
            dto.GenderId = (int)user.GenderId;
            dto.UserId = user.Id;
            result.Data = dto;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<OptionUpdateInfor>> optionUpdateInfor()
        {
            ResponData<OptionUpdateInfor> result = new ResponData<OptionUpdateInfor>();
            OptionUpdateInfor data = new OptionUpdateInfor();
            data.districts = _context.districts.ToList();
            data.provinces = _context.provinces.ToList();
            data.wards = _context.wards.ToList();
            data.genders = _context.gender.ToList();
            result.Data = data;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public Task<ResponData<ActionStatus>> updateInfor(UserInforDTO userInforDTO)
        {
            throw new NotImplementedException();
        }
    }
}
