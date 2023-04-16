using dj_actionlayer.Business.Compilerrrrrr;
using dj_webdesigncore.Business.Study;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Lobby;
using dj_webdesigncore.DTOs.Study;
using dj_webdesigncore.Entities.BusinessEntity;
using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_actionlayer.Business.Study
{
    public class StudyBusiness : BaseBusiness, IStudyBusiness
    {
        public async Task<ResponData<CommentDTO>> CommentOfLesson(int? lessonId)
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

        public async Task<List<ChapterDetailDTO>> LessonListOfUser(int? userId, int? courseId)
        {
            List<ChapterDetailDTO> chapterDetailResult = new List<ChapterDetailDTO>();
            List<CourseChapter> chapterOfCourse = _context.course_chapter.Where(x => x.CourseId == courseId).OrderBy(x => x.SortNumber).ToList();
            foreach (var item in chapterOfCourse)
            {
                ChapterDetailDTO chapterDetailDTO = new ChapterDetailDTO();
                chapterDetailDTO.ChapterTitle = item.ChapterName;
                chapterDetailDTO.LessonCount = item.ChapterLessonCount;
                List<LessonDetailDTO> lessonDetailDTOResult = new List<LessonDetailDTO>();
                List<ChapterLesson> lessonOfChapter = _context.chapter_lesson.Where(x => x.CourseChapterId == item.Id).OrderBy(x => x.SortNumber).ToList();
                foreach (var item1 in lessonOfChapter)
                {
                    LessonDetailDTO lessonDetailDTO = new LessonDetailDTO();
                    User user = await _context.user.FindAsync(userId);
                    UserLessonCheckpoint checkPoint = _context.user_lesson_checkpoint.Where(x => x.UserId == userId && x.LessonId == item1.LessonId).SingleOrDefault();
                    if (checkPoint != null)
                    {
                        lessonDetailDTO.IsDone = true;
                    }
                    else
                    {
                        lessonDetailDTO.IsDone = false;
                    }
                    Lesson lesson = await _context.lesson.FindAsync(item1.LessonId);
                    lessonDetailDTO.LessonName = lesson.LessonName;
                    lessonDetailDTO.LessonId = lesson.Id;
                    lessonDetailDTO.LessonTime = lesson.VideoTime;
                    switch (lesson.LessonTypeId)
                    {
                        case 1:
                            lessonDetailDTO.LessonType = dj_webdesigncore.Enums.CourseEnums.LessonType.THEORY;
                            break;
                        case 2:
                            lessonDetailDTO.LessonType = dj_webdesigncore.Enums.CourseEnums.LessonType.PRACTICE;
                            break;
                        case 3:
                            lessonDetailDTO.LessonType = dj_webdesigncore.Enums.CourseEnums.LessonType.QUESTION;
                            break;
                        default:
                            break;
                    }
                    lessonDetailDTOResult.Add(lessonDetailDTO);
                }
                chapterDetailDTO.LessonDetail = lessonDetailDTOResult;
                chapterDetailResult.Add(chapterDetailDTO);
            }
            return chapterDetailResult;
        }

        public async Task<ResponData<StudyDTO<PracticeLessonDTO>>> PracticeLessonContent(int? lessonId, int? userId, int? courseId)
        {
            ResponData<StudyDTO<PracticeLessonDTO>> result = new ResponData<StudyDTO<PracticeLessonDTO>>();

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
            if (courseId == null)
            {
                result.Messenger = "Lấy dữ liệu thất bại không nhận được courseId!";
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
                PracticeLesson practiceLesson = _context.practice_lesson.Where(x => x.LessonId == lessonId).FirstOrDefault();
                if (practiceLesson == null)
                {
                    result.Messenger = "Lấy dữ liệu thất bại không tồn tại PracticeLesson!";
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.NOTFOUND;
                    return result;
                }
                StudyDTO<PracticeLessonDTO> studyData = new StudyDTO<PracticeLessonDTO>();
                PracticeLessonDTO practiceLessonDTO = new PracticeLessonDTO();
                practiceLessonDTO.Input = practiceLesson.Input;
                practiceLessonDTO.Suggest = practiceLesson.Suggest;
                practiceLessonDTO.BeginCodeMethod = practiceLesson.BeginCodeMethod;
                practiceLessonDTO.Problem = practiceLesson.Problem;
                practiceLessonDTO.ProblemDetail = practiceLesson.ProblemDetail;
                practiceLessonDTO.Explain = practiceLesson.Explain;
                practiceLessonDTO.CallTestCode = practiceLesson.CallTestCode;
                practiceLessonDTO.ExpectOutput = practiceLesson.ExpectOutput;
                practiceLessonDTO.PracticeLessonId = practiceLesson.Id;
                var listTestCase = _context.test_case.Where(x => x.PracticeLessonId == practiceLesson.Id).OrderBy(x => x.SortNumber).ToList();
                List<TryTestCaseDTO> tryTest = new List<TryTestCaseDTO>();
                foreach (var item in listTestCase)
                {
                    TryTestCaseDTO tryTestCaseDTO = new TryTestCaseDTO();
                    if (item.Input == null)
                    {
                        tryTestCaseDTO.Input = "Không có!";
                    }
                    else
                    {
                        tryTestCaseDTO.Input = item.Input;
                    }
                    tryTestCaseDTO.ExpectOutput = item.ExpecOutput;
                    tryTestCaseDTO.Result = dj_webdesigncore.Enums.CourseEnums.TestCaseEnum.WAIT;
                    tryTest.Add(tryTestCaseDTO);
                }
                practiceLessonDTO.TestCase = tryTest;
                studyData.StudyDetail = practiceLessonDTO;
                studyData.LessonType = dj_webdesigncore.Enums.CourseEnums.LessonType.PRACTICE;
                Course course = await _context.course.FindAsync(courseId);
                studyData.CourseName = course.CourseName;
                studyData.ChapterDetail = await LessonListOfUser(userId, courseId);
                result.Data = studyData;
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

        public async Task<ResponData<StudyDTO<QuestionLessonDTO>>> QuestionLessonContent(int? lessonId, int? userId, int? courseId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponData<TryTestCaseResultDTO>> TryTestCase(string? code, int? practiceLessonId)
        {
            ResponData<TryTestCaseResultDTO> result = new ResponData<TryTestCaseResultDTO>();
            if (code == null)
            {
                result.Messenger = "Lấy dữ liệu thất bại không nhận được code!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.PARAMNULL;
                return result;
            }
            if (practiceLessonId == null)
            {
                result.Messenger = "Lấy dữ liệu thất bại không nhận được PracticeLessonId!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.PARAMNULL;
                return result;
            }
            try
            {
                var listTestCase = _context.test_case.Where(x => x.PracticeLessonId == practiceLessonId).OrderBy(x => x.SortNumber).ToList();
                TryTestCaseResultDTO tryTestCaseResultDTO = new TryTestCaseResultDTO();
                List<TryTestCaseDTO> listTest = new List<TryTestCaseDTO>();
                foreach (var item in listTestCase)
                {
                    TryTestCaseDTO testDTO = new TryTestCaseDTO();
                    if (item.Input == null)
                    {
                        var runCodeResult = await CompileUserCode.RunCSharpCode(code);
                        testDTO.Output = runCodeResult;
                        testDTO.Input = null;
                        testDTO.ExpectOutput = item.ExpecOutput;
                        if (runCodeResult.Contains("ERORR+-COMPILE@@@???"))
                        {
                            testDTO.Result = dj_webdesigncore.Enums.CourseEnums.TestCaseEnum.EXCEPTION;
                            listTest.Add(testDTO);
                            continue;
                        }
                        if (!runCodeResult.Equals(item.ExpecOutput))
                        {
                            testDTO.Result = dj_webdesigncore.Enums.CourseEnums.TestCaseEnum.WRONG;
                            listTest.Add(testDTO);
                            continue;
                        }
                        if (runCodeResult.Equals(item.ExpecOutput))
                        {
                            testDTO.Result = dj_webdesigncore.Enums.CourseEnums.TestCaseEnum.SECCESSFULLY;
                            listTest.Add(testDTO);
                            continue;
                        }
                    }
                }
                tryTestCaseResultDTO.TestCase = listTest;
                result.Data = tryTestCaseResultDTO;
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

        public async Task<ResponData<StudyDTO<VideoLessonDTO>>> VideoLessonContent(int? lessonId, int? userId, int? courseId)
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
            if (courseId == null)
            {
                result.Messenger = "Lấy dữ liệu thất bại không nhận được courseId!";
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
                studyData.LessonType = dj_webdesigncore.Enums.CourseEnums.LessonType.THEORY;
                VideoLessonDTO videoLesson = new VideoLessonDTO();
                videoLesson.VideoUrl = _context.video_lesson.Where(x => x.LessonId == lessonId).SingleOrDefault().LessonLinkUrl;
                studyData.StudyDetail = videoLesson;
                Course course = await _context.course.FindAsync(courseId);
                studyData.CourseName = course.CourseName;
                studyData.ChapterDetail = await LessonListOfUser(userId, courseId);
                result.Data = studyData;
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
