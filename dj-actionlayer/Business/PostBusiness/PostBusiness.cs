using dj_actionlayer.DAO;
using dj_webdesigncore.Business.Post;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Post;
using dj_webdesigncore.DTOs.Study;
using dj_webdesigncore.Entities.BusinessEntity;
using dj_webdesigncore.Entities.PostEntity;
using dj_webdesigncore.Entities.UserEntity;
using dj_webdesigncore.Enums.ApiEnums;
using dj_webdesigncore.Request.Lesson;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            data.Id = post.Id;
            data.Title = post.PostTitle;
            data.Des = post.PostDescription;
            data.ImgLink = post.PostImgLinkMeta;
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

            var listSuggest = _context.post.Where(x => x.Id != postId && x.PostStatusId == 1).OrderByDescending(x => x.CreatePost).Take(5).ToList();
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

        public async Task<ResponData<ActionStatus>> userCmtPost(int userId, int postId, string content)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            if (!await _context.user.AnyAsync(x => x.Id == userId))
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            Post post = await _context.post.FindAsync(postId);
            if (post == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            post.CommentCount++;
            CommentPost comment = new CommentPost();
            comment.PostId = postId;
            comment.UserId = userId;
            comment.Comment = content;
            comment.CreateDateTime = DateTime.Now;
            comment.LikeCount = 0;
            comment.IsDeleted = false;
            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }
        public async Task<ResponData<ActionStatus>> userSubCmtPost(int userId, string content, int cmtId)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            User user = await _context.user.FindAsync(userId);
            if (user == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            CommentPost cmt = await _context.comment_post.FindAsync(cmtId);
            if (cmt == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            CommentPost comment = new CommentPost();
            comment.PostId = cmt.PostId;
            comment.UserId = userId;
            comment.Comment = content;
            comment.CreateDateTime = DateTime.Now;
            comment.LikeCount = 0;
            comment.CommentPostParentId = cmt.Id;
            comment.IsDeleted = false;
            if (cmt.UserId == userId)
            {
                await _context.AddAsync(comment);
                await _context.SaveChangesAsync();
                result.Data = ActionStatus.SECCESSFULLY;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            Notification notification = new Notification();
            notification.SystemNotification = false;
            notification.Content = user.UserFisrtName + " " + user.UserLastName + " @KYC@ đã trả lời bình luận của bạn!";
            notification.UserId = (int)cmt.UserId;
            notification.Create = DateTime.Now;
            notification.IsSeen = false;
            notification.UserSendId = user.Id;
            notification.Link = null;
            await _context.AddAsync(notification);
            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<ActionStatus>> userLikePost(int userId, int postId)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            if (!await _context.user.AnyAsync(x => x.Id == userId))
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            Post post = await _context.post.FindAsync(postId);
            if (post == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            UserLikePost userLikePost;
            if (await _context.user_like_post.AnyAsync(x => x.UserId == userId && x.PostId == postId))
            {
                userLikePost = await _context.user_like_post.Where(x => x.UserId == userId && x.PostId == postId).FirstOrDefaultAsync();
                post.LikeCount--;
                _context.Remove(userLikePost);
                await _context.SaveChangesAsync();
                result.Data = ActionStatus.SECCESSFULLY;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            else
            {
                userLikePost = new UserLikePost();
                post.LikeCount++;
                userLikePost.UserId = userId;
                userLikePost.PostId = postId;
                userLikePost.IsDeleted = false;
                userLikePost.LikeDateTime = DateTime.Now;
                await _context.AddAsync(userLikePost);
                await _context.SaveChangesAsync();
                result.Data = ActionStatus.SECCESSFULLY;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
        }

        public async Task<ResponData<CommentDTO>> CommentOfPost(int postId, int userId)
        {
            ResponData<CommentDTO> result = new ResponData<CommentDTO>();
            if (postId == null)
            {
                result.Messenger = "Lấy dữ liệu thất bại không nhận được lessonId!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.PARAMNULL;
                return result;
            }
            try
            {
                CommentDTO commentDTO = new CommentDTO();
                int commentCout = 0;
                var listCommentOfPost = _context.comment_post.Where(x => x.PostId == postId && x.CommentPostParentId == null).OrderByDescending(x => x.CreateDateTime).ToList();
                List<CommentDetailDTO> listCommentDetail = new List<CommentDetailDTO>();
                foreach (var comment in listCommentOfPost)
                {
                    commentCout++;
                    CommentDetailDTO commentDetail = new CommentDetailDTO();
                    commentDetail.CommentId = comment.Id;
                    if (userId != -1)
                    {
                    if (await _context.user_like_comment_post.AnyAsync(x => x.CommentPostId == comment.Id && x.UserId == userId))
                    {
                        commentDetail.IsLike = true;
                    }
                    else
                    {
                        commentDetail.IsLike = false;
                    }
                    }
                    else
                    {
                        commentDetail.IsLike = false;
                    }
                    int dateDiff = (DateTime.Now - comment.CreateDateTime).Days;
                    if (dateDiff == 0)
                    {
                        int hourDiff = (DateTime.Now - comment.CreateDateTime).Hours;
                        if (hourDiff == 0)
                        {
                            commentDetail.CommentDate = (DateTime.Now - comment.CreateDateTime).Minutes.ToString() + " phút trước";
                        }
                        else
                        {
                            commentDetail.CommentDate = hourDiff.ToString() + " giờ trước";
                        }
                    }
                    else
                    {
                        commentDetail.CommentDate = dateDiff.ToString() + " ngày trước";
                    }
                    commentDetail.Comment = comment.Comment;
                    User user = await _context.user.FindAsync(comment.UserId);
                    commentDetail.UserName = user.UserFisrtName + " " + user.UserLastName;
                    commentDetail.LikeCount = (int)comment.LikeCount;
                    commentDetail.UserId = (int)comment.UserId;
                    commentDetail.IsKYC = (bool)user.IsKYC;
                    commentDetail.UserAvatar = _context.user.Find(comment.UserId).UserAvatarData40x40;
                    List<SubComment> subComments = new List<SubComment>();
                    var listSubComment = _context.comment_post.Where(x => x.CommentPostParentId == comment.Id).OrderBy(x => x.CreateDateTime).ToList();
                    foreach (var subComment in listSubComment)
                    {
                        SubComment sub = new SubComment();
                        sub.CommentId = subComment.Id;
                        if (_context.user_like_comment_post.Any(x => x.CommentPostId == subComment.Id && x.UserId == userId))
                        {
                            sub.IsLike = true;
                        }
                        else
                        {
                            sub.IsLike = false;
                        }
                        int dateDiffSub = (DateTime.Now - subComment.CreateDateTime).Days;
                        if (dateDiffSub == 0)
                        {
                            int hourDiffSub = (DateTime.Now - subComment.CreateDateTime).Hours;
                            if (hourDiffSub == 0)
                            {
                                sub.CommentDate = (DateTime.Now - subComment.CreateDateTime).Minutes.ToString() + " phút trước";
                            }
                            else
                            {
                                sub.CommentDate = hourDiffSub.ToString() + " giờ trước";
                            }
                        }
                        else
                        {
                            sub.CommentDate = dateDiffSub.ToString() + " ngày trước";
                        }
                        sub.Comment = subComment.Comment;
                        User subUser = await _context.user.FindAsync(subComment.UserId);
                        sub.UserName = subUser.UserFisrtName + " " + subUser.UserLastName;
                        sub.LikeCount = (int)subComment.LikeCount;
                        sub.UserId = (int)subComment.UserId;
                        sub.IsKYC = (bool)subUser.IsKYC;
                        sub.UserAvatar = _context.user.Find(subComment.UserId).UserAvatarData40x40;
                        subComments.Add(sub);
                    }
                    commentDetail.SubComment = subComments;
                    listCommentDetail.Add(commentDetail);
                }
                commentDTO.CommentCount = commentCout;
                commentDTO.ListComment = listCommentDetail;
                result.Data = commentDTO;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            catch (Exception ex)
            {
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                return result;
            }
        }

        public async Task<ResponData<MyPostDTO>> myPost(int userId)
        {
            ResponData<MyPostDTO> result = new ResponData<MyPostDTO>();
            if (!await _context.user.AnyAsync(x => x.Id == userId))
            {
                result.Data = null;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            MyPostDTO data = new MyPostDTO();
            var listPost = _context.post.Where(x => x.UserCreateId == userId).ToList();
            List<SuggestPostDTO> waitPost = new List<SuggestPostDTO>();
            List<SuggestPostDTO> activePost = new List<SuggestPostDTO>();
            List<SuggestPostDTO> unActivePost = new List<SuggestPostDTO>();
            foreach (var item in listPost)
            {
                SuggestPostDTO post = new SuggestPostDTO();
                post.Id = item.Id;
                post.PostImg = item.PostAvatar;
                post.Title = item.PostTitle;
                post.CmtCount = item.CommentCount;
                post.LikeCount = item.LikeCount;
                post.Status = (int)item.PostStatusId;
                switch (item.PostStatusId)
                {
                    case 1:
                        activePost.Add(post);
                        break;
                    case 2:
                        unActivePost.Add(post);
                        break;
                    case 6:
                    case 5:
                        waitPost.Add(post);
                        break;
                }
            }
            data.ActivePost = activePost;
            data.UnactivePost = unActivePost;
            data.WaitPost = waitPost;
            result.Data = data;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<ActionStatus>> userLikeCmtPost(int userId, int cmtId)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();

            User user = await _context.user.FindAsync(userId);
            if (user == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            CommentPost comment = await _context.comment_post.FindAsync(cmtId);
            if (comment == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }

            UserLikeCommentPost userLikeCommentPost = await _context.user_like_comment_post.Where(x => x.UserId == userId && x.CommentPostId == cmtId).FirstOrDefaultAsync();
            if (userLikeCommentPost != null)
            {
                _context.Remove(userLikeCommentPost);
                comment.LikeCount -= 1;
                await _context.SaveChangesAsync();
            }
            else
            {
                if (comment.UserId != user.Id)
                {
                    User user2 = await _context.user.FindAsync(comment.UserId);
                    Notification notification = new Notification();
                    notification.SystemNotification = false;
                    notification.Content = user.UserFisrtName + " " + user.UserLastName + " đã thích bình luận của bạn!";
                    notification.UserId = user2.Id;
                    notification.Create = DateTime.Now;
                    notification.IsSeen = false;
                    notification.Link = null;
                    notification.UserSendId = user.Id;
                    await _context.AddAsync(notification);
                }
                UserLikeCommentPost newLike = new UserLikeCommentPost();
                newLike.CommentPostId = comment.Id;
                newLike.UserId = userId;
                newLike.CreateDateTime = DateTime.Now;
                comment.LikeCount++;
                await _context.AddAsync(newLike);
                await _context.SaveChangesAsync();
            }
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<PostMain>> getPostMain()
        {
            ResponData<PostMain> result = new ResponData<PostMain>();
            PostMain data = new PostMain();
            Post hot = await _context.post.OrderByDescending(x => x.LikeCount).FirstOrDefaultAsync();
            if (hot == null)
            {
                result.Data = null;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            PostItem hotItem = new PostItem();
            hotItem.Id = hot.Id;
            User createrHot = await _context.user.FindAsync(hot.UserCreateId);
            hotItem.CreaterImg = createrHot.UserAvatarData40x40;
            hotItem.CreaterFullName = createrHot.UserFisrtName + " " + createrHot.UserLastName;
            hotItem.Title = hot.PostTitle;
            hotItem.Img = hot.PostAvatar;
            data.HotPost = hotItem;
            var listPost = _context.post.Where(x => x.Id != hot.Id && x.PostStatusId == 1).OrderByDescending(x => x.CreatePost).ToList();
            List<PostItem> list = new List<PostItem>();
            foreach (var item in listPost)
            {
                PostItem itemCreate = new PostItem();
                itemCreate.Id = item.Id;
                User user = await _context.user.FindAsync(hot.UserCreateId);
                itemCreate.CreaterImg = user.UserAvatarData40x40;
                itemCreate.CreaterFullName = user.UserFisrtName + " " + user.UserLastName;
                itemCreate.Title = item.PostTitle;
                itemCreate.Img = item.PostAvatar;
                list.Add(itemCreate);
            }
            data.PostCreateOrderBy = list;
            result.Data = data;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }
    }
}