using dj_webdesigncore.DTOs.Study;
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
using dj_webdesigncore.Enums.PostEnums;
using dj_webdesigncore.Request.Course;
using dj_webdesigncore.Request.SomeThingElse;
using dj_webdesigncore.Request.Post;

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
        Task<ResponData<ActionStatus>> deleteExperience(int experienceId);
        Task<ResponData<OptionAddLearning>> getOptionAddLearning();
        Task<ResponData<ActionStatus>> createLearningExperience(AddLearningExperience addLearningExperience);
        Task<ResponData<ActionStatus>> deleteLearningExperience(int learningId);
        Task<ResponData<ActionStatus>> changePass(RePass request);
        Task<ResponData<List<NotificationDTO>>> notificationUser(int userId);
        Task<ResponData<ActionStatus>> seenNotifi(int notificationId);
        Task<ResponData<ActionStatus>> seenAllNotifi(int userId);
        Task<ResponData<UserProfileDTO>> getProfile(int userId);
        Task<ResponData<ActionStatus>> createPost(PostCreateRequest request);
        Task<ResponData<string>> getWaitPost(int userId);
        Task<ResponData<IsHaveWaitPost>> isHaveWaitPost(int userId);
        Task<ResponData<ActionStatus>> deleteWaitPost(int userId);
        Task<ResponData<ActionStatus>> confirmPost(IFormFile img, UserConfirmPost data, int userId);
        Task<ResponData<ActionStatus>> CreateDenounce(DenounceRequest denounceRequest);
        Task<ResponData<MyCertificateDTO>> GetAllCerti(int userId);
    }
}
