﻿using dj_webdesigncore.DTOs.Study;
using dj_webdesigncore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dj_webdesigncore.DTOs.UserDTO;
using dj_webdesigncore.Enums.ApiEnums;
using dj_webdesigncore.Entities.UserEntity;
using dj_webdesigncore.Request.Account;
using Microsoft.AspNetCore.Http;

namespace dj_webdesigncore.Business.UserIBusiness
{
    public interface IUserBusiness
    {
        Task<ResponData<UserInforDTO>> getInformation(int userId);
        Task<ResponData<OptionUpdateInfor>> optionUpdateInfor();
        Task<ResponData<List<District>>> getDistrict(string provinceCode);
        Task<ResponData<List<Ward>>> getWard(string districtCode);
        Task<ResponData<UpdateDTO>> updateUser(IFormFile? avatar, UpdateUserRequest updateUserRequest);
        Task<ResponData<ActionStatus>> createExperience(CreateExperience createExperience);
    }
}
