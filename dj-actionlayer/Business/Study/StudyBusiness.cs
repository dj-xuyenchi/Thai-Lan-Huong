using dj_webdesigncore.Business.Study;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Study;
using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_actionlayer.Business.Study
{
    public class StudyBusiness : BaseBusiness, IStudyBusiness
    {
        public ResponData<CommentDTO> CommentOfLesson(int? lessonId)
        {
            ResponData<CommentDTO> result = new ResponData<CommentDTO>();
            if (lessonId == null)
            {
                result.Messenger = "Lấy dữ liệu thất bại không nhận được lessonId!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.PARAMNULL;
                return result;
            }
            try
            {
                CommentDTO commentDTO = new CommentDTO();
                int commentCout = 0;
                var listCommentOfLesson = _context.comment_lesson.Where(x => x.LessonId == lessonId && x.CommentLessonParentId == null).OrderBy(x => x.CreateDateTime).ToList();
                List<CommentDetailDTO> listCommentDetail = new List<CommentDetailDTO>();
                foreach (var comment in listCommentOfLesson)
                {
                    commentCout++;
                    CommentDetailDTO commentDetail = new CommentDetailDTO();
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
                    commentDetail.UserName = _context.user.Find(comment.UserId).UserFisrtName;
                    commentDetail.LikeCount = comment.LikeCount;
                    commentDetail.UserId = (int)comment.UserId;
                    commentDetail.UserAvatar = _context.user.Find(comment.UserId).UserAvatarData40x40;
                    List<SubComment> subComments = new List<SubComment>();
                    var listSubComment = _context.comment_lesson.Where(x => x.CommentLessonParentId == comment.Id).OrderBy(x => x.CreateDateTime).ToList();
                    foreach (var subComment in listSubComment)
                    {
                        SubComment sub = new SubComment();
                        int dateDiffSub = (DateTime.Now - subComment.CreateDateTime).Days;
                        if (dateDiffSub == 0)
                        {
                            int hourDiffSub = (DateTime.Now - subComment.CreateDateTime).Hours;
                            if (hourDiffSub == 0)
                            {
                                sub.CommentDate = (DateTime.Now - subComment.CreateDateTime).Minutes.ToString()+" phút trước";
                            }
                            else
                            {
                                sub.CommentDate = hourDiffSub.ToString() + " giờ trước";

                            }
                        }
                        else
                        {
                            sub.CommentDate = dateDiffSub.ToString()+" ngày trước";
                        }
                        sub.Comment = subComment.Comment;
                        sub.UserName = _context.user.Find(subComment.UserId).UserFisrtName;
                        sub.LikeCount = subComment.LikeCount;
                        sub.UserId = (int)subComment.UserId;
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

        public ResponData<StudyDTO<PracticeLessonDTO>> PracticeLessonContent(int? lessonId, int? userId)
        {
            throw new NotImplementedException();
        }

        public ResponData<StudyDTO<TheoryLessonDTO>> TheoryLessonContent(int? lessonId, int? userId)
        {
            throw new NotImplementedException();
        }

        public ResponData<StudyDTO<VideoLessonDTO>> VideoLessonContent(int? lessonId, int? userId)
        {
            ResponData<StudyDTO<VideoLessonDTO>> result = new ResponData<StudyDTO<VideoLessonDTO>>();
            if (lessonId == null)
            {
                result.Messenger = "Lấy dữ liệu thất bại không nhận được lessonId!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.PARAMNULL;
                return result;
            }
            if (userId == null)
            {
                result.Messenger = "Lấy dữ liệu thất bại không nhận được userId!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.PARAMNULL;
                return result;
            }
            try
            {
                Lesson lesson = _context.lesson.Find(lessonId);
                if (lesson == null)
                {
                    result.Messenger = "Lấy dữ liệu thất bại không tồn tại khóa học!";
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.NOTFOUND;
                    return result;
                }
                User user = _context.user.Find(userId);
                if (user == null)
                {
                    result.Messenger = "Lấy dữ liệu thất bại không tồn tại người dùng!";
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.NOTFOUND;
                    return result;
                }
                StudyDTO<VideoLessonDTO> studyData = new StudyDTO<VideoLessonDTO>();
                VideoLessonDTO videoLesson = new VideoLessonDTO();
                //       videoLesson
                //      studyData.StudyDetail = 
                //      result.Data = studyData;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                return result;
            }
            catch (Exception ex)
            {
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                return result;
            }
        }
    }
}
