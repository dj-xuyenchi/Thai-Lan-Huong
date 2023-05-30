using dj_webdesigncore.Business.Post;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Post;
using dj_webdesigncore.Entities.BusinessEntity;
using dj_webdesigncore.Entities.PostEntity;
using dj_webdesigncore.Entities.UserEntity;
using dj_webdesigncore.Enums.ApiEnums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_actionlayer.Business.PostBusiness
{
    public class PostBusiness : BaseBusiness, IPostBusiness
    {
        public async Task<ResponData<PostDetailDTO>> getPostDetail(int postId, int userId)
        {
            ResponData<PostDetailDTO> result = new ResponData<PostDetailDTO>();
            PostDetailDTO data = new PostDetailDTO();
            Post post = await _context.post.FindAsync(postId);
            if (post == null)
            {
                result.Data = null;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            if (userId != -1)
            {
                User user = await _context.user.FindAsync(userId);
                if (user == null)
                {
                    result.Data = null;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
                else
                {
                    UserLikePost userLikePost = await _context.user_like_post.Where(x => x.UserId == userId && x.PostId == postId).FirstOrDefaultAsync();
                    if (userLikePost != null)
                    {
                        data.IsLiked = true;
                    }
                    else
                    {
                        data.IsLiked = false;
                    }
                }
            }
            data.Title = post.PostTitle;
            data.Content = post.PostData;
            User creater = await _context.user.FindAsync(post.UserCreateId);
            data.CreaterImg = creater.UserAvatarData40x40;
            data.LikeCount = post.LikeCount;
            data.IsCreaterKYC = (bool)creater.IsKYC;
            string createTime = "";
            switch (post.CreatePost.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    createTime += "Thứ hai, ";
                    break;
                case DayOfWeek.Tuesday:
                    createTime += "Thứ ba, ";
                    break;
                case DayOfWeek.Wednesday:
                    createTime += "Thứ tư, ";
                    break;
                case DayOfWeek.Thursday:
                    createTime += "Thứ năm, ";
                    break;
                case DayOfWeek.Friday:
                    createTime += "Thứ sáu, ";
                    break;
                case DayOfWeek.Saturday:
                    createTime += "Thứ bảy, ";
                    break;
                case DayOfWeek.Sunday:
                    createTime += "Chủ nhật, ";
                    break;
            }
            createTime += post.CreatePost.Day + "/" + post.CreatePost.Month + "/" + post.CreatePost.Year + ", " + post.CreatePost.Hour + ":" + post.CreatePost.Minute + " (GMT+7)";
            data.CreatePostTime = createTime;
            data.CreaterFullName = creater.UserFisrtName + " " + creater.UserLastName;

            var listSuggest = _context.post.Where(x => x.Id != postId && x.PostStatusId == 1).OrderBy(x => x.CreatePost).Take(5).ToList();
            List<SuggestPostDTO> suggestPostDTOs = new List<SuggestPostDTO>();
            foreach (var item in listSuggest)
            {
                SuggestPostDTO suggestPostDTO = new SuggestPostDTO();
                suggestPostDTO.Id = item.Id;
                suggestPostDTO.PostImg = item.PostAvatar;
                suggestPostDTO.CmtCount = item.CommentCount;
                suggestPostDTO.Title = item.PostTitle;
                suggestPostDTOs.Add(suggestPostDTO);
            }
            data.SuggestPost = suggestPostDTOs;
            result.Data = data;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }
    }
}
