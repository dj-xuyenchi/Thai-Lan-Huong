using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Post;
using dj_webdesigncore.DTOs.Study;
using dj_webdesigncore.Enums.ApiEnums;
using dj_webdesigncore.Request.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Business.Post
{
    public interface IPostBusiness
    {
        Task<ResponData<PostDetailDTO>> getPostDetail(int postId, int userId);
        Task<ResponData<ActionStatus>> userLikePost(int userId,int postId);
        Task<ResponData<ActionStatus>> userLikeCmtPost(int userId, int cmtId);
        Task<ResponData<ActionStatus>> userCmtPost(int userId, int postId,string content);
        Task<ResponData<ActionStatus>> userSubCmtPost(int userId, string content, int cmtId);
        Task<ResponData<CommentDTO>> CommentOfPost(int postId, int userId);
        Task<ResponData<MyPostDTO>> myPost(int userId);
        Task<ResponData<PostMain>> getPostMain();
    }
}
