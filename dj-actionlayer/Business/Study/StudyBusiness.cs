using dj_actionlayer.Business.Compilerrrrrr;
using dj_webdesigncore.Business.Study;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Lobby;
using dj_webdesigncore.DTOs.Study;
using dj_webdesigncore.Entities.BusinessEntity;
using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Entities.UserEntity;
using dj_webdesigncore.Enums.ApiEnums;
using dj_webdesigncore.Request.Course;
using dj_webdesigncore.Request.Lesson;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dj_webdesigncore.Enums.StudyEnums;
using dj_webdesigncore.DTOs.Admin;
using dj_actionlayer.DAO;
using dj_webdesigncore.Request.SomeThingElse;

namespace dj_actionlayer.Business.Study
{
    public class StudyBusiness : BaseBusiness, IStudyBusiness
    {
        public async Task<ResponData<CommentDTO>> CommentOfLesson(int? lessonId, int? userId)
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
                var listCommentOfLesson = _context.comment_lesson.Where(x => x.LessonId == lessonId && x.CommentLessonParentId == null).OrderByDescending(x => x.CreateDateTime).ToList();
                List<CommentDetailDTO> listCommentDetail = new List<CommentDetailDTO>();
                foreach (var comment in listCommentOfLesson)
                {
                    commentCout++;
                    CommentDetailDTO commentDetail = new CommentDetailDTO();
                    commentDetail.CommentId = comment.Id;
                    if (_context.user_like_comment_lesson.Any(x => x.CommentLessonId == comment.Id && x.UserId == userId))
                    {
                        commentDetail.IsLike = true;
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
                    var listSubComment = _context.comment_lesson.Where(x => x.CommentLessonParentId == comment.Id).OrderBy(x => x.CreateDateTime).ToList();
                    foreach (var subComment in listSubComment)
                    {
                        SubComment sub = new SubComment();
                        sub.CommentId = subComment.Id;
                        if (_context.user_like_comment_lesson.Any(x => x.CommentLessonId == subComment.Id && x.UserId == userId))
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

        public async Task<ChapterLessonStudy> LessonListOfUser(int? userId, int? courseId)
        {
            ChapterLessonStudy data = new ChapterLessonStudy();
            List<dj_webdesigncore.DTOs.Lobby.ChapterDetailDTO> chapterDetailResult = new List<dj_webdesigncore.DTOs.Lobby.ChapterDetailDTO>();
            List<CourseChapter> chapterOfCourse = _context.course_chapter.Where(x => x.CourseId == courseId).OrderBy(x => x.SortNumber).ToList();
            foreach (var item in chapterOfCourse)
            {
                dj_webdesigncore.DTOs.Lobby.ChapterDetailDTO chapterDetailDTO = new dj_webdesigncore.DTOs.Lobby.ChapterDetailDTO();
                chapterDetailDTO.ChapterTitle = item.ChapterName;
                chapterDetailDTO.ChapterId = item.Id;
                chapterDetailDTO.LessonCount = item.ChapterLessonCount;
                List<dj_webdesigncore.DTOs.Lobby.LessonDetailDTO> lessonDetailDTOResult = new List<dj_webdesigncore.DTOs.Lobby.LessonDetailDTO>();
                List<ChapterLesson> lessonOfChapter = _context.chapter_lesson.Where(x => x.CourseChapterId == item.Id).OrderBy(x => x.SortNumber).ToList();
                foreach (var item1 in lessonOfChapter)
                {
                    dj_webdesigncore.DTOs.Lobby.LessonDetailDTO lessonDetailDTO = new dj_webdesigncore.DTOs.Lobby.LessonDetailDTO();
                    User user = await _context.user.FindAsync(userId);
                    UserLessonCheckpoint checkPoint = await _context.user_lesson_checkpoint.Where(x => x.UserId == userId && x.LessonId == item1.LessonId).FirstOrDefaultAsync();
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
            Course course = await _context.course.FindAsync(courseId);
            data.ChapterLesson = chapterDetailResult;
            data.CourseName = course.CourseName;
            data.UpdateTime = "Chưa cập nhật";
            return data;
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
                Lesson lesson = await _context.lesson.FindAsync(lessonId);
                if (lesson == null)
                {
                    result.Messenger = "Lấy dữ liệu thất bại không tồn tại khóa học!";
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.NOTFOUND;
                    return result;
                }
                User user = await _context.user.FindAsync(userId);
                if (user == null)
                {
                    result.Messenger = "Lấy dữ liệu thất bại không tồn tại người dùng!";
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.NOTFOUND;
                    return result;
                }
                dj_webdesigncore.Entities.CourseEntity.PracticeLesson practiceLesson = await _context.practice_lesson.Where(x => x.LessonId == lessonId).FirstOrDefaultAsync();
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
                practiceLessonDTO.Problem = practiceLesson.Problem;
                practiceLessonDTO.ProblemDetail = practiceLesson.ProblemDetail;
                practiceLessonDTO.Explain = practiceLesson.Explain;
                practiceLessonDTO.BeginCodeMethod = practiceLesson.BeginCodeMethod;
                practiceLessonDTO.CallTestCode = practiceLesson.CallTestCode;
                practiceLessonDTO.ExpectOutput = practiceLesson.ExpectOutput;
                practiceLessonDTO.PracticeLessonId = practiceLesson.Id;
                practiceLessonDTO.isSupportMultiLangue = (bool)practiceLesson.IsSupportMultiLangue;
                if ((bool)practiceLesson.IsSupportMultiLangue)
                {
                    List<Langue> listLangueSupport = new List<Langue>();
                    List<dj_webdesigncore.DTOs.Study.MultiLangueDTO> listMultiDTO = new List<dj_webdesigncore.DTOs.Study.MultiLangueDTO>();
                    var listMulti = _context.multi_langue_code.Where(x => x.PracticeId == practiceLesson.Id).ToList();
                    foreach (var item in listMulti)
                    {
                        dj_webdesigncore.DTOs.Study.MultiLangueDTO multiLangueDTO = new dj_webdesigncore.DTOs.Study.MultiLangueDTO();
                        listLangueSupport.Add(await _context.langue.FindAsync(item.LangueId));
                        multiLangueDTO.id = item.Id;
                        multiLangueDTO.LangueId = item.LangueId;
                        multiLangueDTO.PracticeId = item.PracticeId;
                        multiLangueDTO.BeginCodeMethod = item.BeginCodeMethod;
                        multiLangueDTO.CallTestCode = item.CallTestCode;
                        listMultiDTO.Add(multiLangueDTO);
                    }
                    practiceLessonDTO.multiLangueDTOs = listMultiDTO;
                    practiceLessonDTO.listLangue = listLangueSupport;
                }
                practiceLessonDTO.defaultLangue = await _context.langue.FindAsync(practiceLesson.LangueDefaultId);
                var practiceDoneData = await _context.practice_done_data.Where(x => x.UserId == userId && x.PracticeLessonId == practiceLesson.Id).FirstOrDefaultAsync();
                if (practiceDoneData != null)
                {
                    CodeOkDTO ok = new CodeOkDTO();
                    ok.langue = await _context.langue.FindAsync(practiceDoneData.LangueId);
                    ok.CodeOk = practiceDoneData.DoneData;
                    practiceLessonDTO.CodeOk = ok;
                }
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
                    tryTestCaseDTO.ExpectOutput = item.ExpectOutput;
                    tryTestCaseDTO.LockTestCase = item.LockTestCase;
                    tryTestCaseDTO.Result = dj_webdesigncore.Enums.CourseEnums.TestCaseEnum.WAIT;
                    tryTest.Add(tryTestCaseDTO);
                }
                practiceLessonDTO.TestCase = tryTest;
                studyData.StudyDetail = practiceLessonDTO;
                studyData.LessonType = dj_webdesigncore.Enums.CourseEnums.LessonType.PRACTICE;
                Course course = await _context.course.FindAsync(courseId);
                studyData.CourseName = course.CourseName;
                studyData.ChapterDetail = LessonListOfUser(userId, courseId).Result.ChapterLesson;
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
            ResponData<StudyDTO<QuestionLessonDTO>> result = new ResponData<StudyDTO<QuestionLessonDTO>>();

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
                StudyDTO<QuestionLessonDTO> data = new StudyDTO<QuestionLessonDTO>();
                Lesson lesson = await _context.lesson.FindAsync(lessonId);
                if (lesson == null)
                {
                    result.Messenger = "Lấy dữ liệu thất bại không tồn tại khóa học!";
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.NOTFOUND;
                    return result;
                }
                User user = await _context.user.FindAsync(userId);
                if (user == null)
                {
                    result.Messenger = "Lấy dữ liệu thất bại không tồn tại người dùng!";
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.NOTFOUND;
                    return result;
                }
                QuestionLesson questionLesson = await _context.question_lesson.Where(x => x.LessonId == lessonId).FirstOrDefaultAsync();
                if (questionLesson == null)
                {
                    result.Messenger = "Lấy dữ liệu thất bại không tồn tại PracticeLesson!";
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.NOTFOUND;
                    return result;
                }
                QuestionLessonDTO questionLessonDTO = new QuestionLessonDTO();
                questionLessonDTO.AnswerA = questionLesson.AnswerA;
                questionLessonDTO.AnswerB = questionLesson.AnswerB;
                questionLessonDTO.AnswerC = questionLesson.AnswerC;
                questionLessonDTO.AnswerD = questionLesson.AnswerD;
                questionLessonDTO.Question = questionLesson.Question;
                questionLessonDTO.LessonId = lesson.Id;
                data.StudyDetail = questionLessonDTO;
                data.LessonType = dj_webdesigncore.Enums.CourseEnums.LessonType.QUESTION;
                Course course = await _context.course.FindAsync(courseId);
                data.CourseName = course.CourseName;
                data.ChapterDetail = LessonListOfUser(userId, courseId).Result.ChapterLesson;
                result.Data = data;
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

        public async Task<ResponData<TryTestCaseResultDTO>> TryTestCase(CodeRequest codeRequest)
        {
            ResponData<TryTestCaseResultDTO> result = new ResponData<TryTestCaseResultDTO>();
            TryTestCaseResultDTO tryTestCaseResultDTO = new TryTestCaseResultDTO();
                List<TryTestCaseDTO> listTest = new List<TryTestCaseDTO>();
            string codeContent = codeRequest.Code;
            
            if (codeRequest.Code == null)
            {
                result.Messenger = "Lấy dữ liệu thất bại không nhận được code!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.PARAMNULL;
                return result;
            }
            if (codeRequest.PracticeLessonId == null)
            {
                result.Messenger = "Lấy dữ liệu thất bại không nhận được PracticeLessonId!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.PARAMNULL;
                return result;
            }
            try
            {
                var listTestCase = _context.test_case.Where(x => x.PracticeLessonId == codeRequest.PracticeLessonId).OrderBy(x => x.SortNumber).ToList();
                dj_webdesigncore.Entities.CourseEntity.PracticeLesson practiceLesson = await _context.practice_lesson.FindAsync(codeRequest.PracticeLessonId);
                if (practiceLesson.Input == null)
                {
                    foreach (var item in listTestCase)
                    {
                        TryTestCaseDTO testDTO = new TryTestCaseDTO();
                        testDTO.LockTestCase = item.LockTestCase;
                        if (codeContent.Contains("Directory") || codeContent.Contains("File") || codeContent.Contains("FileInfo"))
                        {
                            testDTO.Result = dj_webdesigncore.Enums.CourseEnums.TestCaseEnum.EXCEPTION;
                            testDTO.Output = "Security Protect!";
                            testDTO.RunTimeTotal = "Lỗi! không tính được";
                            listTest.Add(testDTO);
                            continue;
                        }
                        var runCodeResult = await CompileUserCode.RunCSharpCode(codeRequest.Code);
                        testDTO.Input = "Không có";
                        testDTO.ExpectOutput = item.ExpectOutput;
                        if (!runCodeResult.success)
                        {
                            testDTO.Result = dj_webdesigncore.Enums.CourseEnums.TestCaseEnum.EXCEPTION;
                            testDTO.Output = runCodeResult.exeption;
                            testDTO.RunTimeTotal = "Lỗi! không tính được";
                            listTest.Add(testDTO);
                            continue;
                        }

                        if (runCodeResult.success)
                        {
                            if (!runCodeResult.result.Equals(item.ExpectOutput))
                            {
                                testDTO.Result = dj_webdesigncore.Enums.CourseEnums.TestCaseEnum.WRONG;
                                testDTO.Output = runCodeResult.result;
                                testDTO.RunTimeTotal = runCodeResult.time;
                                listTest.Add(testDTO);
                                continue;
                            }
                            testDTO.Result = dj_webdesigncore.Enums.CourseEnums.TestCaseEnum.SECCESSFULLY;
                            testDTO.Output = runCodeResult.result;
                            testDTO.RunTimeTotal = runCodeResult.time;
                            listTest.Add(testDTO);
                            continue;
                        }
                    }
                }
                else
                {
                    string callTestCode = practiceLesson.CallTestCode;
                    foreach (var item in listTestCase)
                    {
                        TryTestCaseDTO testDTO = new TryTestCaseDTO();
                        testDTO.LockTestCase = item.LockTestCase;
                        callTestCode = callTestCode.Replace("variable", item.Input);
                        if (codeContent.Contains("Directory") || codeContent.Contains("File") || codeContent.Contains("FileInfo"))
                        {
                            testDTO.Result = dj_webdesigncore.Enums.CourseEnums.TestCaseEnum.EXCEPTION;
                            testDTO.Output = "Security Protect!";
                            testDTO.RunTimeTotal = "Lỗi! không tính được";
                            listTest.Add(testDTO);
                            continue;
                        }
                        var runCodeResult = await CompileUserCode.RunCSharpCode(codeRequest.Code + callTestCode);
                        callTestCode = practiceLesson.CallTestCode;
                        testDTO.Input = item.Input;
                        testDTO.ExpectOutput = item.ExpectOutput;
                        if (!runCodeResult.success)
                        {
                            testDTO.Result = dj_webdesigncore.Enums.CourseEnums.TestCaseEnum.EXCEPTION;
                            testDTO.Output = runCodeResult.exeption;
                            testDTO.RunTimeTotal = "Lỗi! không tính được";
                            listTest.Add(testDTO);
                            continue;
                        }
                        if (runCodeResult.success)
                        {
                            if (!runCodeResult.result.Equals(item.ExpectOutput))
                            {
                                testDTO.Result = dj_webdesigncore.Enums.CourseEnums.TestCaseEnum.WRONG;
                                testDTO.Output = runCodeResult.result;
                                testDTO.RunTimeTotal = runCodeResult.time;
                                listTest.Add(testDTO);
                                continue;
                            }
                            testDTO.Result = dj_webdesigncore.Enums.CourseEnums.TestCaseEnum.SECCESSFULLY;
                            testDTO.Output = runCodeResult.result;
                            testDTO.RunTimeTotal = runCodeResult.time;
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

            Lesson lesson = await _context.lesson.FindAsync(lessonId);
            if (lesson == null)
            {
                result.Messenger = "Lấy dữ liệu thất bại không tồn tại khóa học!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.NOTFOUND;
                return result;
            }
            User user = await _context.user.FindAsync(userId);
            if (user == null)
            {
                result.Messenger = "Lấy dữ liệu thất bại không tồn tại người dùng!";
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.NOTFOUND;
                return result;
            }
            StudyDTO<VideoLessonDTO> studyData = new StudyDTO<VideoLessonDTO>();
            studyData.LessonType = dj_webdesigncore.Enums.CourseEnums.LessonType.THEORY;
            VideoLessonDTO videoLesson = new VideoLessonDTO();
            VideoLesson videoLessonData = await _context.video_lesson.Where(x => x.LessonId == lessonId).FirstOrDefaultAsync();
            videoLesson.VideoUrl = videoLessonData.LessonLinkUrl;
            studyData.StudyDetail = videoLesson;
            Course course = await _context.course.FindAsync(courseId);
            studyData.CourseName = course.CourseName;
            studyData.CourseProcess = await ProcessCourse((int)courseId, (int)userId);
            studyData.ChapterDetail = LessonListOfUser(userId, courseId).Result.ChapterLesson;
            result.Data = studyData;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<RegisterCourseDTO>> RegisterCourse(RegisterCourse registerCourse)
        {
            ResponData<RegisterCourseDTO> result = new ResponData<RegisterCourseDTO>();
            try
            {
                RegisterCourseDTO data = new RegisterCourseDTO();
                User user = await _context.user.FindAsync(registerCourse.UserId);
                if (user == null)
                {
                    data.Status = dj_webdesigncore.Enums.CourseEnums.RegisterEnum.NOTFOUND;
                    data.Mes = "Không tồn tại User!";
                    result.Data = data;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
                Course course = await _context.course.FindAsync(registerCourse.CourseId);
                if (course == null)
                {
                    data.Status = dj_webdesigncore.Enums.CourseEnums.RegisterEnum.NOTFOUND;
                    data.Mes = "Không tồn tại Khóa học!";
                    result.Data = data;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
                UserCourse userCourse = await _context.user_course.Where(x => x.CourseId == registerCourse.CourseId && x.UserId == registerCourse.UserId).FirstOrDefaultAsync();
                if (userCourse != null)
                {
                    data.Status = dj_webdesigncore.Enums.CourseEnums.RegisterEnum.REGISTERBEFORE;
                    data.Mes = "Khóa học đã được đăng ký trước đó!";
                    result.Data = data;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
                course.RegisterCount++;
                UserCourse newUserCourse = new UserCourse();
                newUserCourse.CourseId = registerCourse.CourseId;
                newUserCourse.UserId = registerCourse.UserId;
                newUserCourse.ResisterDateTime = DateTime.Now;
                newUserCourse.isDone = false;
                newUserCourse.LastTimeStudyDateTime = DateTime.Now;
                newUserCourse.DonePercent = 0;
                _context.Add(newUserCourse);
                Notification notification = new Notification();
                notification.SystemNotification = true;
                notification.Content = "Đăng ký thành công khóa học " + course.CourseName;
                notification.UserId = user.Id;
                notification.Create = DateTime.Now;
                notification.IsSeen = false;
                notification.Link = null;
                await _context.AddAsync(notification);
                //Notification notification1 = new Notification();
                //notification1.SystemNotification = true;
                //notification1.Content = "Gửi cậu bộ tài liệu học của khóa " + course.CourseName + " nha! Mãi yêu <3";
                //notification1.UserId = user.Id;
                //notification1.Create = DateTime.Now;
                //notification1.IsSeen = false;
                //notification1.Link = null;
                //await _context.AddAsync(notification1);
                CourseChapter courseChapter = await _context.course_chapter.Where(x => x.CourseId == registerCourse.CourseId && x.SortNumber == 1).FirstOrDefaultAsync();
                if (courseChapter == null)
                {
                    data.Status = dj_webdesigncore.Enums.CourseEnums.RegisterEnum.NOCHAPTER;
                    data.Mes = "Khóa học hiện chưa các học phần!";
                    result.Data = data;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
                ChapterLesson chapterLesson = await _context.chapter_lesson.Where(x => x.SortNumber == 1 && x.CourseChapterId == courseChapter.Id).FirstOrDefaultAsync();
                if (chapterLesson == null)
                {
                    data.Status = dj_webdesigncore.Enums.CourseEnums.RegisterEnum.NOLESSON;
                    data.Mes = "Chưa có bài học nào!";
                    result.Data = data;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
                UserLessonCheckpoint userLessonCheckpoint = new UserLessonCheckpoint();
                userLessonCheckpoint.LessonId = chapterLesson.LessonId;
                userLessonCheckpoint.UserId = registerCourse.UserId;
                userLessonCheckpoint.OpenLessonDateTime = DateTime.Now;
                userLessonCheckpoint.IsDone = false;
                _context.Add(userLessonCheckpoint);
                await _context.SaveChangesAsync();
                data.CourseId = registerCourse.CourseId;
                data.LessonId = chapterLesson.LessonId;
                data.ChapterId = courseChapter.Id;
                data.Status = dj_webdesigncore.Enums.CourseEnums.RegisterEnum.SECCESSFULLY;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;

            }
            catch (Exception ex)
            {
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<ActionStatus>> CommentLesson(dj_webdesigncore.Request.Lesson.CommentLessonRequest commentLessonRequest)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            foreach (var item in commentLessonRequest.GetType().GetProperties())
            {
                if (item.GetValue(commentLessonRequest, null) == null)
                {
                    result.Data = ActionStatus.PARAMNULL;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
            }
            User user = _context.user.Find(commentLessonRequest.UserId);
            if (user == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            Lesson lesson = _context.lesson.Find(commentLessonRequest.LessonId);
            if (lesson == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            if (commentLessonRequest.CommentContent.Trim().Length == 0)
            {
                result.Data = ActionStatus.SECCESSFULLY;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            CommentLesson commentLesson = new CommentLesson();
            commentLesson.LessonId = commentLessonRequest.LessonId;
            commentLesson.CreateDateTime = DateTime.Now;
            commentLesson.LikeCount = 0;
            commentLesson.Comment = commentLessonRequest.CommentContent;
            commentLesson.UserId = commentLessonRequest.UserId;
            await _context.AddAsync(commentLesson);
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<ActionStatus>> SubCommentLesson(dj_webdesigncore.Request.Lesson.SubCommentLessonRequest subCommentLessonRequest)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            foreach (var item in subCommentLessonRequest.GetType().GetProperties())
            {
                if (item.GetValue(subCommentLessonRequest, null) == null)
                {
                    result.Data = ActionStatus.PARAMNULL;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
            }
            User user = _context.user.Find(subCommentLessonRequest.UserId);
            if (user == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            Lesson lesson = _context.lesson.Find(subCommentLessonRequest.LessonId);
            if (lesson == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            if (subCommentLessonRequest.CommentContent.Trim().Length == 0)
            {
                result.Data = ActionStatus.SECCESSFULLY;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            CommentLesson commentLesson = new CommentLesson();
            commentLesson.LessonId = subCommentLessonRequest.LessonId;
            commentLesson.CreateDateTime = DateTime.Now;
            commentLesson.LikeCount = 0;
            commentLesson.Comment = subCommentLessonRequest.CommentContent;
            commentLesson.UserId = subCommentLessonRequest.UserId;
            commentLesson.CommentLessonParentId = subCommentLessonRequest.CommentParentId;
            await _context.AddAsync(commentLesson);
            CommentLesson commentLesson2 = await _context.comment_lesson.FindAsync(subCommentLessonRequest.CommentParentId);
            if (commentLesson.UserId != commentLesson2.UserId)
            {
                User user2 = await _context.user.FindAsync(commentLesson2.UserId);
                Notification notification = new Notification();
                notification.SystemNotification = false;
                notification.Content = user.UserFisrtName + " " + user.UserLastName + " @KYC@đã trả lời bình luận của bạn!";
                notification.UserId = user2.Id;
                notification.Create = DateTime.Now;
                notification.IsSeen = false;
                notification.UserSendId = user.Id;
                notification.Link = null;
                await _context.AddAsync(notification);
            }
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<ActionStatus>> LikeComment(LikeComment likeComment)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            foreach (var item in likeComment.GetType().GetProperties())
            {
                if (item.GetValue(likeComment, null) == null)
                {
                    result.Data = ActionStatus.PARAMNULL;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
            }
            User user = _context.user.Find(likeComment.UserId);
            if (user == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            CommentLesson comment = _context.comment_lesson.Find(likeComment.CommentId);
            if (comment == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }

            UserLikeCommentLesson userLikeCommentLesson = _context.user_like_comment_lesson.Where(x => x.UserId == likeComment.UserId && x.CommentLessonId == likeComment.CommentId).FirstOrDefault();
            if (userLikeCommentLesson != null)
            {
                _context.Remove(userLikeCommentLesson);
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
                UserLikeCommentLesson newLike = new UserLikeCommentLesson();
                newLike.CommentLessonId = comment.Id;
                newLike.UserId = likeComment.UserId;
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

        public async Task<ResponData<ActionStatus>> SendPracticeOk(SendPracticeRequest sendPracticeRequest)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            foreach (var item in sendPracticeRequest.GetType().GetProperties())
            {
                if (item.GetValue(sendPracticeRequest, null) == null)
                {
                    result.Data = ActionStatus.PARAMNULL;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
            }
            dj_webdesigncore.Entities.CourseEntity.PracticeLesson practiceLesson = await _context.practice_lesson.Where(x => x.LessonId == sendPracticeRequest.LessonId).FirstOrDefaultAsync();
            PracticeDoneData isExist = await _context.practice_done_data.Where(x => x.PracticeLessonId == practiceLesson.Id && x.UserId == sendPracticeRequest.UserId).FirstOrDefaultAsync();
            if (isExist != null)
            {

                //
                ChapterLesson chapterLesson1 = await _context.chapter_lesson.Where(x => x.LessonId == sendPracticeRequest.LessonId && x.CourseChapterId == sendPracticeRequest.ChapterId).FirstOrDefaultAsync();
                ChapterLesson chapterLessonNext1 = await _context.chapter_lesson.Where(x => x.CourseChapterId == sendPracticeRequest.ChapterId && x.SortNumber == chapterLesson1.SortNumber + 1).FirstOrDefaultAsync();
                if (chapterLessonNext1 != null)
                {
                    CourseChapter cc = await _context.course_chapter.FindAsync(sendPracticeRequest.ChapterId);
                    Course c = await _context.course.FindAsync(cc.CourseId);
                    UserCourse uc = await _context.user_course.Where(x => x.UserId == sendPracticeRequest.UserId && x.CourseId == c.Id).FirstOrDefaultAsync();
                    uc.LessonProcessId = sendPracticeRequest.LessonId;
                    UserLessonCheckpoint newUserLessonCheckPoint = new UserLessonCheckpoint();
                    newUserLessonCheckPoint.LessonId = chapterLessonNext1.LessonId;
                    newUserLessonCheckPoint.UserId = sendPracticeRequest.UserId;
                    newUserLessonCheckPoint.IsDone = false;
                    newUserLessonCheckPoint.OpenLessonDateTime = DateTime.Now;
                    await _context.AddAsync(newUserLessonCheckPoint);
                }
                else
                {
                    CourseChapter courseChapter = await _context.course_chapter.FindAsync(sendPracticeRequest.ChapterId);
                    CourseChapter courseChapterNext = await _context.course_chapter.Where(x => x.CourseId == courseChapter.CourseId && x.SortNumber == courseChapter.SortNumber + 1).FirstOrDefaultAsync();
                    if (courseChapterNext != null)
                    {
                        CourseChapter cc = await _context.course_chapter.FindAsync(sendPracticeRequest.ChapterId);
                        Course c = await _context.course.FindAsync(cc.CourseId);
                        UserCourse uc = await _context.user_course.Where(x => x.UserId == sendPracticeRequest.UserId && x.CourseId == c.Id).FirstOrDefaultAsync();
                        uc.LessonProcessId = sendPracticeRequest.LessonId;
                        ChapterLesson newChapterLesson = await _context.chapter_lesson.Where(x => x.CourseChapterId == courseChapterNext.Id && x.SortNumber == 1).FirstOrDefaultAsync();
                        UserLessonCheckpoint newUserLessonCheckPoint = new UserLessonCheckpoint();
                        newUserLessonCheckPoint.LessonId = newChapterLesson.LessonId;
                        newUserLessonCheckPoint.UserId = sendPracticeRequest.UserId;
                        newUserLessonCheckPoint.IsDone = false;
                        newUserLessonCheckPoint.OpenLessonDateTime = DateTime.Now;
                        await _context.AddAsync(newUserLessonCheckPoint);
                    }
                    else
                    {
                        UserCourse us = await _context.user_course.Where(x => x.CourseId == courseChapter.CourseId && x.UserId == sendPracticeRequest.UserId).FirstOrDefaultAsync();
                        us.isDone = true;
                        if (us.DoneTime == null)
                        {
                            us.DoneTime = DateTime.Now;
                        }
                        await _context.SaveChangesAsync();
                        result.Data = ActionStatus.PASSCOURSE;
                        result.Messenger = "Lấy dữ liệu thành công!";
                        result.Status = ActionStatus.SECCESSFULLY;
                        await _context.SaveChangesAsync();
                        return result;
                    }
                }
                //

                isExist.DoneData = sendPracticeRequest.Code;
                await _context.SaveChangesAsync();
                result.Data = ActionStatus.EXIST;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            PracticeDoneData practiceDoneData = new PracticeDoneData();
            practiceDoneData.UserId = sendPracticeRequest.UserId;
            practiceDoneData.PracticeLessonId = practiceLesson.Id;
            practiceDoneData.DoneData = sendPracticeRequest.Code;
            practiceDoneData.DoneTime = DateTime.Now;
            practiceDoneData.LangueId = sendPracticeRequest.langueId;
            ChapterLesson chapterLesson = await _context.chapter_lesson.Where(x => x.LessonId == sendPracticeRequest.LessonId && x.CourseChapterId == sendPracticeRequest.ChapterId).FirstOrDefaultAsync();
            ChapterLesson chapterLessonNext = await _context.chapter_lesson.Where(x => x.CourseChapterId == sendPracticeRequest.ChapterId && x.SortNumber == chapterLesson.SortNumber + 1).FirstOrDefaultAsync();
            if (chapterLessonNext != null)
            {
                CourseChapter cc = await _context.course_chapter.FindAsync(sendPracticeRequest.ChapterId);
                Course c = await _context.course.FindAsync(cc.CourseId);
                UserCourse uc = await _context.user_course.Where(x => x.UserId == sendPracticeRequest.UserId && x.CourseId == c.Id).FirstOrDefaultAsync();
                uc.LessonProcessId = sendPracticeRequest.LessonId;
                UserLessonCheckpoint newUserLessonCheckPoint = new UserLessonCheckpoint();
                newUserLessonCheckPoint.LessonId = chapterLessonNext.LessonId;
                newUserLessonCheckPoint.UserId = sendPracticeRequest.UserId;
                newUserLessonCheckPoint.IsDone = false;
                newUserLessonCheckPoint.OpenLessonDateTime = DateTime.Now;
                await _context.AddAsync(newUserLessonCheckPoint);
            }
            else
            {
                CourseChapter courseChapter = await _context.course_chapter.FindAsync(sendPracticeRequest.ChapterId);
                CourseChapter courseChapterNext = await _context.course_chapter.Where(x => x.CourseId == courseChapter.CourseId && x.SortNumber == courseChapter.SortNumber + 1).FirstOrDefaultAsync();
                if (courseChapterNext != null)
                {
                    CourseChapter cc = await _context.course_chapter.FindAsync(sendPracticeRequest.ChapterId);
                    Course c = await _context.course.FindAsync(cc.CourseId);
                    UserCourse uc = await _context.user_course.Where(x => x.UserId == sendPracticeRequest.UserId && x.CourseId == c.Id).FirstOrDefaultAsync();
                    uc.LessonProcessId = sendPracticeRequest.LessonId;
                    ChapterLesson newChapterLesson = await _context.chapter_lesson.Where(x => x.CourseChapterId == courseChapterNext.Id && x.SortNumber == 1).FirstOrDefaultAsync();
                    UserLessonCheckpoint newUserLessonCheckPoint = new UserLessonCheckpoint();
                    newUserLessonCheckPoint.LessonId = newChapterLesson.LessonId;
                    newUserLessonCheckPoint.UserId = sendPracticeRequest.UserId;
                    newUserLessonCheckPoint.IsDone = false;
                    newUserLessonCheckPoint.OpenLessonDateTime = DateTime.Now;
                    await _context.AddAsync(newUserLessonCheckPoint);
                }
                else
                {
                    UserCourse us = await _context.user_course.Where(x => x.CourseId == courseChapter.CourseId && x.UserId == sendPracticeRequest.UserId).FirstOrDefaultAsync();
                    us.isDone = true;
                    if (us.DoneTime == null)
                    {
                        us.DoneTime = DateTime.Now;
                    }
                    await _context.SaveChangesAsync();
                    result.Data = ActionStatus.PASSCOURSE;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    result.Status = ActionStatus.SECCESSFULLY;
                    await _context.SaveChangesAsync();
                    return result;
                }
            }
            await _context.AddAsync(practiceDoneData);
            UserLessonCheckpoint userLessonCheckpoint = await _context.user_lesson_checkpoint.Where(x => x.LessonId == sendPracticeRequest.LessonId && x.UserId == sendPracticeRequest.UserId).FirstOrDefaultAsync();
            userLessonCheckpoint.IsDone = true;
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<ActionStatus>> SendQuestionAnswer(SendQuestionRequest sendQuestionRequest)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            Lesson lesson = await _context.lesson.FindAsync(sendQuestionRequest.LessonId);
            if (lesson == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = ActionStatus.SECCESSFULLY;
                return result;
            }
            QuestionLesson questionLesson = await _context.question_lesson.Where(x => x.LessonId == lesson.Id).FirstOrDefaultAsync();
            if (questionLesson.Answer != sendQuestionRequest.Answer)
            {
                result.Data = ActionStatus.WRONG;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = ActionStatus.SECCESSFULLY;
                return result;
            }
            if (_context.question_done_data.Any(x => x.QuestionLessonId == questionLesson.Id && x.UserId == sendQuestionRequest.UserId))
            {

                //
                ChapterLesson chapterLesson = await _context.chapter_lesson.Where(x => x.LessonId == sendQuestionRequest.LessonId && x.CourseChapterId == sendQuestionRequest.ChapterId).FirstOrDefaultAsync();
                ChapterLesson chapterLessonNext = await _context.chapter_lesson.Where(x => x.CourseChapterId == sendQuestionRequest.ChapterId && x.SortNumber == chapterLesson.SortNumber + 1).FirstOrDefaultAsync();
                if (chapterLessonNext != null)
                {
                    CourseChapter cc = await _context.course_chapter.FindAsync(sendQuestionRequest.ChapterId);
                    Course c = await _context.course.FindAsync(cc.CourseId);
                    UserCourse uc = await _context.user_course.Where(x => x.UserId == sendQuestionRequest.UserId && x.CourseId == c.Id).FirstOrDefaultAsync();
                    uc.LessonProcessId = sendQuestionRequest.LessonId;
                    UserLessonCheckpoint newUserLessonCheckPoint = new UserLessonCheckpoint();
                    newUserLessonCheckPoint.LessonId = chapterLessonNext.LessonId;
                    newUserLessonCheckPoint.UserId = sendQuestionRequest.UserId;
                    newUserLessonCheckPoint.IsDone = false;
                    newUserLessonCheckPoint.OpenLessonDateTime = DateTime.Now;
                    await _context.AddAsync(newUserLessonCheckPoint);
                }
                else
                {
                    CourseChapter courseChapter = await _context.course_chapter.FindAsync(sendQuestionRequest.ChapterId);
                    CourseChapter courseChapterNext = await _context.course_chapter.Where(x => x.CourseId == courseChapter.CourseId && x.SortNumber == courseChapter.SortNumber + 1).FirstOrDefaultAsync();
                    if (courseChapterNext != null)
                    {
                        CourseChapter cc = await _context.course_chapter.FindAsync(sendQuestionRequest.ChapterId);
                        Course c = await _context.course.FindAsync(cc.CourseId);
                        UserCourse uc = await _context.user_course.Where(x => x.UserId == sendQuestionRequest.UserId && x.CourseId == c.Id).FirstOrDefaultAsync();
                        uc.LessonProcessId = sendQuestionRequest.LessonId;
                        ChapterLesson newChapterLesson = await _context.chapter_lesson.Where(x => x.CourseChapterId == courseChapterNext.Id && x.SortNumber == 1).FirstOrDefaultAsync();
                        UserLessonCheckpoint newUserLessonCheckPoint = new UserLessonCheckpoint();
                        newUserLessonCheckPoint.LessonId = newChapterLesson.LessonId;
                        newUserLessonCheckPoint.UserId = sendQuestionRequest.UserId;
                        newUserLessonCheckPoint.IsDone = false;
                        newUserLessonCheckPoint.OpenLessonDateTime = DateTime.Now;
                        await _context.AddAsync(newUserLessonCheckPoint);
                    }
                    else
                    {
                        UserCourse us = await _context.user_course.Where(x => x.CourseId == courseChapter.CourseId && x.UserId == sendQuestionRequest.UserId).FirstOrDefaultAsync();
                        us.isDone = true; if (us.DoneTime == null)
                        {
                            us.DoneTime = DateTime.Now;
                        }
                        await _context.SaveChangesAsync();
                        result.Data = ActionStatus.PASSCOURSE;
                        result.Messenger = "Lấy dữ liệu thành công!";
                        result.Status = ActionStatus.SECCESSFULLY;
                        await _context.SaveChangesAsync();
                        return result;
                    }
                }
                //

                await _context.SaveChangesAsync();
                result.Data = ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = ActionStatus.SECCESSFULLY;
                return result;
            }
            else
            {
                QuestionDoneData questionDoneData = new QuestionDoneData();
                questionDoneData.Answer = sendQuestionRequest.Answer;
                questionDoneData.QuestionLessonId = questionLesson.Id;
                questionDoneData.UserId = sendQuestionRequest.UserId;
                questionDoneData.DoneTime = DateTime.Now;
                await _context.AddAsync(questionDoneData);
                ChapterLesson chapterLesson = await _context.chapter_lesson.Where(x => x.LessonId == sendQuestionRequest.LessonId && x.CourseChapterId == sendQuestionRequest.ChapterId).FirstOrDefaultAsync();
                ChapterLesson chapterLessonNext = await _context.chapter_lesson.Where(x => x.CourseChapterId == sendQuestionRequest.ChapterId && x.SortNumber == chapterLesson.SortNumber + 1).FirstOrDefaultAsync();
                if (chapterLessonNext != null)
                {
                    CourseChapter cc = await _context.course_chapter.FindAsync(sendQuestionRequest.ChapterId);
                    Course c = await _context.course.FindAsync(cc.CourseId);
                    UserCourse uc = await _context.user_course.Where(x => x.UserId == sendQuestionRequest.UserId && x.CourseId == c.Id).FirstOrDefaultAsync();
                    uc.LessonProcessId = sendQuestionRequest.LessonId;
                    UserLessonCheckpoint newUserLessonCheckPoint = new UserLessonCheckpoint();
                    newUserLessonCheckPoint.LessonId = chapterLessonNext.LessonId;
                    newUserLessonCheckPoint.UserId = sendQuestionRequest.UserId;
                    newUserLessonCheckPoint.IsDone = false;
                    newUserLessonCheckPoint.OpenLessonDateTime = DateTime.Now;
                    await _context.AddAsync(newUserLessonCheckPoint);
                }
                else
                {
                    CourseChapter courseChapter = await _context.course_chapter.FindAsync(sendQuestionRequest.ChapterId);
                    CourseChapter courseChapterNext = await _context.course_chapter.Where(x => x.CourseId == courseChapter.CourseId && x.SortNumber == courseChapter.SortNumber + 1).FirstOrDefaultAsync();
                    if (courseChapterNext != null)
                    {
                        CourseChapter cc = await _context.course_chapter.FindAsync(sendQuestionRequest.ChapterId);
                        Course c = await _context.course.FindAsync(cc.CourseId);
                        UserCourse uc = await _context.user_course.Where(x => x.UserId == sendQuestionRequest.UserId && x.CourseId == c.Id).FirstOrDefaultAsync();
                        uc.LessonProcessId = sendQuestionRequest.LessonId;
                        ChapterLesson newChapterLesson = await _context.chapter_lesson.Where(x => x.CourseChapterId == courseChapterNext.Id && x.SortNumber == 1).FirstOrDefaultAsync();
                        UserLessonCheckpoint newUserLessonCheckPoint = new UserLessonCheckpoint();
                        newUserLessonCheckPoint.LessonId = newChapterLesson.LessonId;
                        newUserLessonCheckPoint.UserId = sendQuestionRequest.UserId;
                        newUserLessonCheckPoint.IsDone = false;
                        newUserLessonCheckPoint.OpenLessonDateTime = DateTime.Now;
                        await _context.AddAsync(newUserLessonCheckPoint);
                    }
                    else
                    {
                        UserCourse us = await _context.user_course.Where(x => x.CourseId == courseChapter.CourseId && x.UserId == sendQuestionRequest.UserId).FirstOrDefaultAsync();
                        us.isDone = true; if (us.DoneTime == null)
                        {
                            us.DoneTime = DateTime.Now;
                        }
                        await _context.SaveChangesAsync();
                        result.Data = ActionStatus.PASSCOURSE;
                        result.Messenger = "Lấy dữ liệu thành công!";
                        result.Status = ActionStatus.SECCESSFULLY;
                        await _context.SaveChangesAsync();
                        return result;
                    }
                }
                UserLessonCheckpoint userLessonCheckpoint = await _context.user_lesson_checkpoint.Where(x => x.LessonId == sendQuestionRequest.LessonId && x.UserId == sendQuestionRequest.UserId).FirstOrDefaultAsync();
                userLessonCheckpoint.IsDone = true;
                result.Data = ActionStatus.RIGHT;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = ActionStatus.SECCESSFULLY;
                await _context.SaveChangesAsync();
                return result;
            }
        }

        public async Task<ResponData<ActionStatus>> SendVideoDoneRequest(SendVideoDoneRequest sendVideoDoneRequest)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            Lesson lesson = await _context.lesson.FindAsync(sendVideoDoneRequest.LessonId);
            if (lesson == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = ActionStatus.SECCESSFULLY;
                return result;
            }
            VideoLesson videoLesson = await _context.video_lesson.Where(x => x.LessonId == lesson.Id).FirstOrDefaultAsync();
            if (_context.video_done_data.Any(x => x.VideoLessonId == videoLesson.Id && x.UserId == sendVideoDoneRequest.UserId))
            {

                //
                ChapterLesson chapterLesson = await _context.chapter_lesson.Where(x => x.LessonId == sendVideoDoneRequest.LessonId && x.CourseChapterId == sendVideoDoneRequest.ChapterId).FirstOrDefaultAsync();
                ChapterLesson chapterLessonNext = await _context.chapter_lesson.Where(x => x.CourseChapterId == sendVideoDoneRequest.ChapterId && x.SortNumber == chapterLesson.SortNumber + 1).FirstOrDefaultAsync();
                if (chapterLessonNext != null)
                {
                    CourseChapter cc = await _context.course_chapter.FindAsync(sendVideoDoneRequest.ChapterId);
                    Course c = await _context.course.FindAsync(cc.CourseId);
                    UserCourse uc = await _context.user_course.Where(x => x.UserId == sendVideoDoneRequest.UserId && x.CourseId == c.Id).FirstOrDefaultAsync();
                    uc.LessonProcessId = sendVideoDoneRequest.LessonId;
                    UserLessonCheckpoint newUserLessonCheckPoint = new UserLessonCheckpoint();
                    newUserLessonCheckPoint.LessonId = chapterLessonNext.LessonId;
                    newUserLessonCheckPoint.UserId = sendVideoDoneRequest.UserId;
                    newUserLessonCheckPoint.IsDone = false;
                    newUserLessonCheckPoint.OpenLessonDateTime = DateTime.Now;
                    await _context.AddAsync(newUserLessonCheckPoint);
                }
                else
                {
                    CourseChapter courseChapter = await _context.course_chapter.FindAsync(sendVideoDoneRequest.ChapterId);
                    CourseChapter courseChapterNext = await _context.course_chapter.Where(x => x.CourseId == courseChapter.CourseId && x.SortNumber == courseChapter.SortNumber + 1).FirstOrDefaultAsync();
                    if (courseChapterNext != null)
                    {
                        CourseChapter cc = await _context.course_chapter.FindAsync(sendVideoDoneRequest.ChapterId);
                        Course c = await _context.course.FindAsync(cc.CourseId);
                        UserCourse uc = await _context.user_course.Where(x => x.UserId == sendVideoDoneRequest.UserId && x.CourseId == c.Id).FirstOrDefaultAsync();
                        uc.LessonProcessId = sendVideoDoneRequest.LessonId;
                        ChapterLesson newChapterLesson = await _context.chapter_lesson.Where(x => x.CourseChapterId == courseChapterNext.Id && x.SortNumber == 1).FirstOrDefaultAsync();
                        UserLessonCheckpoint newUserLessonCheckPoint = new UserLessonCheckpoint();
                        newUserLessonCheckPoint.LessonId = newChapterLesson.LessonId;
                        newUserLessonCheckPoint.UserId = sendVideoDoneRequest.UserId;
                        newUserLessonCheckPoint.IsDone = false;
                        newUserLessonCheckPoint.OpenLessonDateTime = DateTime.Now;
                        await _context.AddAsync(newUserLessonCheckPoint);
                    }
                    else
                    {
                        UserCourse us = await _context.user_course.Where(x => x.CourseId == courseChapter.CourseId && x.UserId == sendVideoDoneRequest.UserId).FirstOrDefaultAsync();
                        us.isDone = true; if (us.DoneTime == null)
                        {
                            us.DoneTime = DateTime.Now;
                        }
                        await _context.SaveChangesAsync();
                        result.Data = ActionStatus.PASSCOURSE;
                        result.Messenger = "Lấy dữ liệu thành công!";
                        result.Status = ActionStatus.SECCESSFULLY;
                        await _context.SaveChangesAsync();
                        return result;
                    }
                }
                //

                await _context.SaveChangesAsync();
                result.Data = ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = ActionStatus.SECCESSFULLY;
                return result;
            }
            else
            {
                VideoDoneData videoDoneData = new VideoDoneData();
                videoDoneData.VideoLessonId = videoLesson.Id;
                videoDoneData.UserId = sendVideoDoneRequest.UserId;
                videoDoneData.DoneTime = DateTime.Now;
                await _context.AddAsync(videoDoneData);
                ChapterLesson chapterLesson = await _context.chapter_lesson.Where(x => x.LessonId == sendVideoDoneRequest.LessonId && x.CourseChapterId == sendVideoDoneRequest.ChapterId).FirstOrDefaultAsync();
                ChapterLesson chapterLessonNext = await _context.chapter_lesson.Where(x => x.CourseChapterId == sendVideoDoneRequest.ChapterId && x.SortNumber == chapterLesson.SortNumber + 1).FirstOrDefaultAsync();
                if (chapterLessonNext != null)
                {
                    CourseChapter cc = await _context.course_chapter.FindAsync(sendVideoDoneRequest.ChapterId);
                    Course c = await _context.course.FindAsync(cc.CourseId);
                    UserCourse uc = await _context.user_course.Where(x => x.UserId == sendVideoDoneRequest.UserId && x.CourseId == c.Id).FirstOrDefaultAsync();
                    uc.LessonProcessId = sendVideoDoneRequest.LessonId;
                    UserLessonCheckpoint newUserLessonCheckPoint = new UserLessonCheckpoint();
                    newUserLessonCheckPoint.LessonId = chapterLessonNext.LessonId;
                    newUserLessonCheckPoint.UserId = sendVideoDoneRequest.UserId;
                    newUserLessonCheckPoint.IsDone = false;
                    newUserLessonCheckPoint.OpenLessonDateTime = DateTime.Now;
                    await _context.AddAsync(newUserLessonCheckPoint);
                }
                else
                {
                    CourseChapter courseChapter = await _context.course_chapter.FindAsync(sendVideoDoneRequest.ChapterId);
                    CourseChapter courseChapterNext = await _context.course_chapter.Where(x => x.CourseId == courseChapter.CourseId && x.SortNumber == courseChapter.SortNumber + 1).FirstOrDefaultAsync();
                    if (courseChapterNext != null)
                    {
                        CourseChapter cc = await _context.course_chapter.FindAsync(sendVideoDoneRequest.ChapterId);
                        Course c = await _context.course.FindAsync(cc.CourseId);
                        UserCourse uc = await _context.user_course.Where(x => x.UserId == sendVideoDoneRequest.UserId && x.CourseId == c.Id).FirstOrDefaultAsync();
                        uc.LessonProcessId = sendVideoDoneRequest.LessonId;
                        ChapterLesson newChapterLesson = await _context.chapter_lesson.Where(x => x.CourseChapterId == courseChapterNext.Id && x.SortNumber == 1).FirstOrDefaultAsync();
                        UserLessonCheckpoint newUserLessonCheckPoint = new UserLessonCheckpoint();
                        newUserLessonCheckPoint.LessonId = newChapterLesson.LessonId;
                        newUserLessonCheckPoint.UserId = sendVideoDoneRequest.UserId;
                        newUserLessonCheckPoint.IsDone = false;
                        newUserLessonCheckPoint.OpenLessonDateTime = DateTime.Now;
                        await _context.AddAsync(newUserLessonCheckPoint);
                    }
                    else
                    {
                        UserCourse us = await _context.user_course.Where(x => x.CourseId == courseChapter.CourseId && x.UserId == sendVideoDoneRequest.UserId).FirstOrDefaultAsync();
                        us.isDone = true; if (us.DoneTime == null)
                        {
                            us.DoneTime = DateTime.Now;
                        }
                        await _context.SaveChangesAsync();
                        result.Data = ActionStatus.PASSCOURSE;
                        result.Messenger = "Lấy dữ liệu thành công!";
                        result.Status = ActionStatus.SECCESSFULLY;
                        await _context.SaveChangesAsync();
                        return result;
                    }
                }
                UserLessonCheckpoint userLessonCheckpoint = await _context.user_lesson_checkpoint.Where(x => x.LessonId == sendVideoDoneRequest.LessonId && x.UserId == sendVideoDoneRequest.UserId).FirstOrDefaultAsync();
                userLessonCheckpoint.IsDone = true;
                result.Data = ActionStatus.RIGHT;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = ActionStatus.SECCESSFULLY;
                await _context.SaveChangesAsync();
                return result;
            }
        }

        public async Task<ResponData<List<Langue>>> getAllLangue()
        {
            ResponData<List<Langue>> result = new ResponData<List<Langue>>();
            result.Data = _context.langue.ToList();
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<List<dj_webdesigncore.DTOs.Admin.TestCaseDTO>>> getTestCaseOfPractice(int practiceLessonId)
        {
            ResponData<List<TestCaseDTO>> result = new ResponData<List<TestCaseDTO>>();
            try
            {
                List<TestCaseDTO> data = new List<TestCaseDTO>();
                var testList = _context.test_case.Where(x => x.PracticeLessonId == practiceLessonId).OrderBy(x => x.SortNumber).ToList();
                foreach (var item in testList)
                {
                    TestCaseDTO testCaseDTO = new TestCaseDTO();
                    testCaseDTO.TestCaseId = item.Id;
                    testCaseDTO.Input = item.Input;
                    testCaseDTO.Output = item.ExpectOutput;
                    testCaseDTO.SortNumber = item.SortNumber;
                    testCaseDTO.ExpectOutput = item.ExpectOutput;
                    testCaseDTO.TestCaseDetail = item.InputDetail;
                    testCaseDTO.IsLock = item.LockTestCase;
                    data.Add(testCaseDTO);
                }
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<IQueryable<DenounceType>> getDenounce()
        {
            var listData = _context.denounce_type;
            return listData;
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

            CommentLesson cmt = await _context.comment_lesson.FindAsync(denounceRequest.CmtId);
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
            denounce.TypeCmt = dj_webdesigncore.Enums.Else.TypeCmt.LESSON;
            denounce.ProveLink = denounceRequest.URL;
            await _context.AddAsync(denounce);
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<string> ProcessCourse(int courseId, int userId)
        {
            var courseChapter = _context.course_chapter.Where(x => x.CourseId == courseId).AsNoTracking().ToList();
            Course course = await _context.course.FindAsync(courseId);
            List<int> lessonListId = new List<int>();
            foreach (var item in courseChapter)
            {
                var chapterLesson = _context.chapter_lesson.Where(x => x.CourseChapterId == item.Id).AsNoTracking().ToList();
                foreach (var item1 in chapterLesson)
                {
                    lessonListId.Add(item1.LessonId);
                }
            }
            int count = 0;
            foreach (var item in lessonListId)
            {
                if (await _context.user_lesson_checkpoint.AnyAsync(x => x.LessonId == item && x.IsDone == true && x.UserId == userId))
                {
                    count++;
                }
            }
            return "Đã hoàn thành: " + count + "/" + course.LessonCount;
        }
    }
}
