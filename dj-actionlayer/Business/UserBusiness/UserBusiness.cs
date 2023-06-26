using dj_actionlayer.DAO;
using DJ_UploadFile.Services;
using dj_webdesigncore.Business.UserIBusiness;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Study;
using dj_webdesigncore.DTOs.UserDTO;
using dj_webdesigncore.Entities.BusinessEntity;
using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Entities.PostEntity;
using dj_webdesigncore.Entities.UserEntity;
using dj_webdesigncore.Enums.ApiEnums;
using dj_webdesigncore.Enums.PostEnums;
using dj_webdesigncore.Request.Account;
using dj_webdesigncore.Request.Post;
using dj_webdesigncore.Request.SomeThingElse;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_actionlayer.Business.UserBusiness
{
    public class UserBusiness : BaseBusiness, IUserBusiness
    {
        public async Task<ResponData<ActionStatus>> changePass(RePass request)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            User user = await _context.user.FindAsync(request.Id);
            if (user == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            if (!user.UserPass.Equals(request.OldPass))
            {
                result.Data = ActionStatus.WRONG;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            if (request.NewPass.Trim().Length < 8)
            {
                result.Data = ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            Notification notification = new Notification();
            notification.SystemNotification = true;
            notification.Content = "Xác nhận đổi mật khẩu thành công lúc " + DateTime.Now + " <3";
            notification.UserId = user.Id;
            notification.Create = DateTime.Now;
            notification.IsSeen = false;
            notification.Link = null;
            await _context.AddAsync(notification);
            user.UserPass = request.NewPass;
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<ActionStatus>> confirmPost(IFormFile img, UserConfirmPost data, int userId)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            User user = await _context.user.FindAsync(userId);
            if (user == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            Post check = await _context.post.Where(x => x.UserCreateId == userId && x.PostStatusId == 4).FirstOrDefaultAsync();
            if (check == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            check.PostStatusId = 5;
            check.PostTitle = data.title;
            string linkImg = await CloudinaryUpload.UploadFile(img);
            check.PostImgLinkMeta = linkImg;
            check.PostDescription = data.des;
            check.PostAvatar = linkImg;
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<ActionStatus>> createExperience(CreateExperience createExperience)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            if (!_context.user.Any(x => x.Id == createExperience.userId))
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            Experience experience = new Experience();
            if (!createExperience.isWorking)
            {
                experience.Close = createExperience.end;
            }
            experience.Detail = createExperience.detail;
            experience.Open = createExperience.start;
            experience.UserId = createExperience.userId;
            experience.Position = createExperience.position;
            Notification notification = new Notification();
            notification.SystemNotification = true;
            notification.Content = "Đã thêm mới thông tin về kinh nghiệm làm việc! <3";
            notification.UserId = createExperience.userId;
            notification.Create = DateTime.Now;
            notification.IsSeen = false;
            notification.Link = null;
            await _context.AddAsync(notification);
            await _context.AddAsync(experience);
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<ActionStatus>> createLearningExperience(AddLearningExperience addLearningExperience)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            if (!_context.user.Any(x => x.Id == addLearningExperience.userId))
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            LearningExperience learningExperience = new LearningExperience();
            learningExperience.SchoolId = addLearningExperience.school;
            learningExperience.UserId = addLearningExperience.userId;
            learningExperience.MajorsId = addLearningExperience.majors;
            learningExperience.Close = addLearningExperience.end;
            learningExperience.Open = addLearningExperience.start;
            Notification notification = new Notification();
            notification.SystemNotification = true;
            notification.Content = "Đã thêm mới thông tin về học vấn! <3";
            notification.UserId = addLearningExperience.userId;
            notification.Create = DateTime.Now;
            notification.IsSeen = false;
            notification.Link = null;
            await _context.AddAsync(notification);
            await _context.AddAsync(learningExperience);
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<ActionStatus>> createPost(PostCreateRequest request)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            if (!await _context.user.AnyAsync(x => x.Id == request.UserId))
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            Post check = await _context.post.Where(x => x.UserCreateId == request.UserId && x.PostStatusId == 4).FirstOrDefaultAsync();
            if (check == null)
            {
                Post post = new Post();
                post.PostData = request.Data;
                post.CreatePost = DateTime.Now;
                post.PostStatusId = 4;
                post.LikeCount = 0;
                post.UserCreateId = request.UserId;
                post.CommentCount = 0;
                await _context.AddAsync(post);
                await _context.SaveChangesAsync();
                result.Data = ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            else
            {
                check.PostData = request.Data;
                await _context.SaveChangesAsync();
                result.Data = ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
        }

        public async Task<ResponData<ActionStatus>> deleteExperience(int experienceId)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            Experience experience = await _context.experience.FindAsync(experienceId);
            if (experience == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            Notification notification = new Notification();
            notification.SystemNotification = true;
            notification.Content = "Xóa thành công thông tin quá trình làm việc!";
            notification.UserId = experience.UserId;
            notification.Create = DateTime.Now;
            notification.IsSeen = false;
            notification.Link = null;
            await _context.AddAsync(notification);
            _context.Remove(experience);
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<ActionStatus>> deleteLearningExperience(int learningId)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            LearningExperience learningExperience = await _context.learning_experience.FindAsync(learningId);
            if (learningExperience == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            Notification notification = new Notification();
            notification.SystemNotification = true;
            notification.Content = "Xóa thành công thông tin học vấn!";
            notification.UserId = learningExperience.UserId;
            notification.Create = DateTime.Now;
            notification.IsSeen = false;
            notification.Link = null;
            await _context.AddAsync(notification);
            _context.Remove(learningExperience);
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<ActionStatus>> deleteWaitPost(int userId)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            User user = await _context.user.FindAsync(userId);
            if (user == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            Post check = await _context.post.Where(x => x.UserCreateId == userId && x.PostStatusId == 4).FirstOrDefaultAsync();
            if (check == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            _context.Remove(check);
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

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
            var listExperiance = _context.experience.Where(x => x.UserId == user.Id).OrderBy(x => x.Open).ToList();
            List<ExperienceDTO> experienceDTOs = new List<ExperienceDTO>();
            foreach (var experience in listExperiance)
            {
                ExperienceDTO experienceDTO = new ExperienceDTO();
                experienceDTO.Position = experience.Position;
                experienceDTO.id = experience.Id;
                experienceDTO.Detail = experience.Detail;
                if (experience.Close == null)
                {
                    experienceDTO.TimeLine = "Từ " + experience.Open.Day + "-" + experience.Open.Month + "-" + experience.Open.Year + " đến nay";
                }
                else
                {
                    experienceDTO.TimeLine = "Từ " + experience.Open.Day + "-" + experience.Open.Month + "-" + experience.Open.Year + " đến " + experience.Close.Value.Day + "-" + experience.Close.Value.Month + "-" + experience.Close.Value.Year;
                }
                experienceDTOs.Add(experienceDTO);
            }
            dto.experienceDTOs = experienceDTOs;
            var listLearning = _context.learning_experience.Where(x => x.UserId == user.Id).OrderBy(x => x.Open).ToList();
            List<LearningDTO> learningDTOs = new List<LearningDTO>();
            foreach (var experience in listLearning)
            {
                LearningDTO learning = new LearningDTO();
                learning.id = experience.Id;
                learning.Majors = _context.majors.Find(experience.MajorsId).MajorsName;
                learning.SchoolName = _context.school.Find(experience.SchoolId).SchoolName;
                learning.TimeLine = "Từ " + experience.Open.Day + "-" + experience.Open.Month + "-" + experience.Open.Year + " đến " + experience.Close.Day + "-" + experience.Close.Month + "-" + experience.Close.Year;
                learningDTOs.Add(learning);
            }
            dto.learningDTOs = learningDTOs;
            dto.genders = _context.gender.ToList();
            dto.catalogs = _context.user_catalog.ToList();
            result.Data = dto;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<OptionAddLearning>> getOptionAddLearning()
        {
            ResponData<OptionAddLearning> result = new ResponData<OptionAddLearning>();
            OptionAddLearning optionAddLearning = new OptionAddLearning();
            var listSchool = _context.school.ToList();
            List<SchoolDTO> sch = new List<SchoolDTO>();
            foreach (var school in listSchool)
            {
                sch.Add(new SchoolDTO()
                {
                    Id = school.Id,
                    SchoolName = school.SchoolName
                });
            }
            List<MajorsDTO> majors1 = new List<MajorsDTO>();
            var listMajors = _context.majors.ToList();
            foreach (var majors in listMajors)
            {
                majors1.Add(new MajorsDTO()
                {
                    Id = majors.Id,
                    MajorsName = majors.MajorsName
                });
            }
            optionAddLearning.majorsDTOs = majors1;
            optionAddLearning.schoolDTOs = sch;
            result.Data = optionAddLearning;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<UserProfileDTO>> getProfile(int userId)
        {
            ResponData<UserProfileDTO> result = new ResponData<UserProfileDTO>();
            User user = await _context.user.FindAsync(userId);
            if (user == null)
            {
                result.Data = null;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            UserProfileDTO data = new UserProfileDTO();
            data.FullName = user.UserFisrtName + " " + user.UserLastName;
            data.IsKYC = (bool)user.IsKYC;
            data.Avatar = user.UserAvatarData40x40;
            data.JoinTime = user.CreateAccount.Value.Day + " - " + user.CreateAccount.Value.Month + " - " + user.CreateAccount.Value.Year;
            data.WallImg = null;
            List<ResigtedUserCourseDTO> registerCourseDTOs = new List<ResigtedUserCourseDTO>();
            var listCourse = _context.user_course.Where(x => x.UserId == userId).OrderBy(x => x.ResisterDateTime).ToList();
            foreach (var item in listCourse)
            {
                ResigtedUserCourseDTO registerCourse = new ResigtedUserCourseDTO();
                Course course = await _context.course.FindAsync(item.CourseId);
                registerCourse.CourseName = course.CourseName;
                registerCourse.CourseAvatar = course.CourseImageData;
                registerCourse.CourseDescription = course.CourseSubTitle;
                registerCourse.CourseLink = course.Id.ToString();
                registerCourseDTOs.Add(registerCourse);
            }
            data.ResigtedCourse = registerCourseDTOs;
            result.Data = data;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<string>> getWaitPost(int userId)
        {
            ResponData<string> result = new ResponData<string>();
            Post post = await _context.post.Where(x => x.UserCreateId == userId && x.PostStatusId == 4).FirstOrDefaultAsync();
            if (post == null)
            {
                result.Data = null;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            result.Data = post.PostData;
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

        public async Task<ResponData<IsHaveWaitPost>> isHaveWaitPost(int userId)
        {
            ResponData<IsHaveWaitPost> result = new ResponData<IsHaveWaitPost>();
            User user = await _context.user.FindAsync(userId);
            if (user == null)
            {
                result.Data = IsHaveWaitPost.NOTFOUND;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            Post post = await _context.post.Where(x => x.UserCreateId == userId && x.PostStatusId == 4).FirstOrDefaultAsync();
            if (post == null)
            {
                result.Data = IsHaveWaitPost.NO;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            else
            {
                result.Data = IsHaveWaitPost.YES;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
        }

        public async Task<ResponData<List<NotificationDTO>>> notificationUser(int userId)
        {
            ResponData<List<NotificationDTO>> result = new ResponData<List<NotificationDTO>>();
            User user = await _context.user.FindAsync(userId);
            if (user == null)
            {
                result.Data = null;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            List<NotificationDTO> notificationDTOs = new List<NotificationDTO>();
            var noti = _context.notification.Where(x => x.UserId == userId).OrderByDescending(x => x.Create).Take(20).ToList();
            foreach (var item in noti)
            {
                NotificationDTO notification = new NotificationDTO();
                notification.Content = item.Content;
                notification.IsSeen = item.IsSeen;
                notification.NotificationId = item.Id;
                notification.Link = item.Link;
                string send = "";
                int dateDiff = (DateTime.Now - item.Create).Days;
                if (dateDiff == 0)
                {
                    int hourDiff = (DateTime.Now - item.Create).Hours;
                    if (hourDiff == 0)
                    {
                        send = (DateTime.Now - item.Create).Minutes.ToString() + " phút trước";
                    }
                    else
                    {
                        send = hourDiff.ToString() + " giờ trước";
                    }
                }
                else
                {
                    send = dateDiff.ToString() + " ngày trước";
                }
                notification.SendTime = send;
                if (item.SystemNotification)
                {
                    notification.Avatar = Settings.adminQA();
                }
                else
                {
                    User user1 = await _context.user.FindAsync(item.UserSendId);
                    notification.Avatar = user1.UserAvatarData40x40;
                    notification.IsKYC = (bool)user1.IsKYC;
                }
                notificationDTOs.Add(notification);
            }
            result.Data = notificationDTOs;
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
            data.statuses = _context.user_status.ToList();
            data.catalogs = _context.user_catalog.ToList();
            data.roles = _context.user_role.Where(x => x.Id != 1).ToList();
            result.Data = data;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<ActionStatus>> seenAllNotifi(int userId)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            User user = await _context.user.FindAsync(userId);
            if (user == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            var listNoti = _context.notification.Where(x => x.UserId == userId && x.IsSeen == false).ToList();
            foreach (var item in listNoti)
            {
                item.IsSeen = true;
            }
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<ActionStatus>> seenNotifi(int notificationId)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();

            Notification notification = await _context.notification.FindAsync(notificationId);
            if (notification == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            notification.IsSeen = true;
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<UpdateDTO>> updateUser(IFormFile? avatar, UpdateUserRequest updateUserRequest)
        {
            ResponData<UpdateDTO> result = new ResponData<UpdateDTO>();
            UpdateDTO data = new UpdateDTO();
            User user = await _context.user.FindAsync(updateUserRequest.userId);
            if (user == null)
            {
                data.status = ActionStatus.NOTFOUND;
                result.Data = data;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            if (avatar != null)
            {
                user.UserAvatarData40x40 = await CloudinaryUpload.UploadFile(avatar);
            }
            if (updateUserRequest.catalog != null)
            {
                user.CatalogId = updateUserRequest.catalog;
            }
            if (updateUserRequest.district != null)
            {
                user.DistrictCode = updateUserRequest.district;
            }
            if (updateUserRequest.province != null)
            {
                user.ProvinceCode = updateUserRequest.province;
            }
            if (updateUserRequest.ward != null)
            {
                user.WardCode = updateUserRequest.ward;
            }
            if (updateUserRequest.birthday.Year != 1000)
            {
                user.Birthday = updateUserRequest.birthday;
            }
            user.AddressNow = updateUserRequest.addressNow;
            user.NumberPhone = updateUserRequest.sdt;
            user.UserFacebook = updateUserRequest.facebook;
            user.UserFisrtName = updateUserRequest.firstName;
            user.UserLastName = updateUserRequest.lastName;
            user.GenderId = updateUserRequest.gender;
            user.UserDetail = updateUserRequest.detail;
            user.UserLinkedIn = updateUserRequest.linkedIn;
            user.Update = DateTime.Now;
            Notification notification = new Notification();
            notification.SystemNotification = true;
            notification.Content = "Cập nhật thông tin cá nhân thành công! <3";
            notification.UserId = user.Id;
            notification.Create = DateTime.Now;
            notification.IsSeen = false;
            notification.Link = null;
            await _context.AddAsync(notification);
            await _context.SaveChangesAsync();
            data.status = ActionStatus.SECCESSFULLY;
            data.avatar = user.UserAvatarData40x40;
            data.name = user.UserFisrtName + " " + user.UserLastName;
            data.nickName = "Chiến Thần Front End";
            result.Data = data;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<ActionStatus>> CreateDenounce(DenounceRequest denounceRequest)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            User sender = await _context.user.FindAsync(denounceRequest.UserSendId);
            if (sender == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }

            CommentPost cmt = await _context.comment_post.FindAsync(denounceRequest.CmtId);
            if (cmt == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            if (sender.Id == cmt.UserId)
            {
                result.Data = ActionStatus.WRONG;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            Denounce denounce = new Denounce();
            denounce.CmtId = denounceRequest.CmtId;
            denounce.IsCheck = false;
            denounce.Note = denounceRequest.Note;
            denounce.IsViolation = false;
            denounce.DenounceTypeId = denounceRequest.TypeId;
            denounce.SendTime = DateTime.Now;
            denounce.UserSendId = denounceRequest.UserSendId;
            denounce.UserViolationId = (int)cmt.UserId;
            denounce.TypeCmt = dj_webdesigncore.Enums.Else.TypeCmt.POST;
            denounce.ProveLink = denounceRequest.URL;
            await _context.AddAsync(denounce);
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<MyCertificateDTO>> GetAllCerti(int userId)
        {
            ResponData<MyCertificateDTO> result = new ResponData<MyCertificateDTO>();
            MyCertificateDTO data = new MyCertificateDTO();
            List<Course> map = new List<Course>();
            var list = _context.user_course.Where(x => x.UserId == userId && x.isDone == true).ToList();
            foreach (var item in list)
            {
                map.Add(await _context.course.FindAsync(item.CourseId));
            }
            data.ListCerti = map;
            result.Data = data;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }
    }
}
