﻿using dj_actionlayer.Business.Compilerrrrrr;
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
                    User user = _context.user.Find(comment.UserId);
                    commentDetail.UserName = user.UserFisrtName + " " + user.UserLastName;
                    commentDetail.LikeCount = (int)comment.LikeCount;
                    commentDetail.UserId = (int)comment.UserId;
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
                        User subUser = _context.user.Find(comment.UserId);
                        sub.UserName = subUser.UserFisrtName + " " + subUser.UserLastName;
                        sub.LikeCount = (int)subComment.LikeCount;
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
                dj_webdesigncore.Entities.CourseEntity.PracticeLesson practiceLesson = _context.practice_lesson.Where(x => x.LessonId == lessonId).FirstOrDefault();
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
                PracticeDoneData practiceDoneData = await _context.practice_done_data.Where(x => x.UserId == userId && x.PracticeLessonId == practiceLesson.Id).FirstOrDefaultAsync();
                if (practiceDoneData != null)
                {
                    practiceLessonDTO.CodeOk = practiceDoneData.DoneData;
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
                QuestionLesson questionLesson = _context.question_lesson.Where(x => x.LessonId == lessonId).FirstOrDefault();
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
                questionLessonDTO.LessonId = questionLesson.Id;
                data.StudyDetail = questionLessonDTO;
                data.LessonType = dj_webdesigncore.Enums.CourseEnums.LessonType.QUESTION;
                Course course = await _context.course.FindAsync(courseId);
                data.CourseName = course.CourseName;
                data.ChapterDetail = await LessonListOfUser(userId, courseId);
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
                TryTestCaseResultDTO tryTestCaseResultDTO = new TryTestCaseResultDTO();
                List<TryTestCaseDTO> listTest = new List<TryTestCaseDTO>();
                dj_webdesigncore.Entities.CourseEntity.PracticeLesson practiceLesson = _context.practice_lesson.Find(codeRequest.PracticeLessonId);
                if (practiceLesson.Input == null)
                {
                    foreach (var item in listTestCase)
                    {
                        TryTestCaseDTO testDTO = new TryTestCaseDTO();
                        testDTO.LockTestCase = item.LockTestCase;
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
                            if (!runCodeResult.result.Contains(item.ExpectOutput))
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
                        callTestCode = callTestCode.Replace("variable",item.Input);
                        var runCodeResult = await CompileUserCode.RunCSharpCode(codeRequest.Code+callTestCode);
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
                            if (!runCodeResult.result.Contains(item.ExpectOutput))
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
                UserCourse userCourse = _context.user_course.Where(x => x.CourseId == registerCourse.CourseId && x.UserId == registerCourse.UserId).SingleOrDefault();
                if (userCourse != null)
                {
                    data.Status = dj_webdesigncore.Enums.CourseEnums.RegisterEnum.REGISTERBEFORE;
                    data.Mes = "Khóa học đã được đăng ký trước đó!";
                    result.Data = data;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
                UserCourse newUserCourse = new UserCourse();
                newUserCourse.CourseId = registerCourse.CourseId;
                newUserCourse.UserId = registerCourse.UserId;
                newUserCourse.ResisterDateTime = DateTime.Now;
                newUserCourse.isDone = false;
                newUserCourse.LastTimeStudyDateTime = DateTime.Now;
                newUserCourse.DonePercent = 0;
                _context.Add(newUserCourse);
                await _context.SaveChangesAsync();
                CourseChapter courseChapter = _context.course_chapter.Where(x => x.CourseId == registerCourse.CourseId && x.SortNumber == 1).SingleOrDefault();
                if (courseChapter == null)
                {
                    data.Status = dj_webdesigncore.Enums.CourseEnums.RegisterEnum.NOCHAPTER;
                    data.Mes = "Khóa học hiện chưa các học phần!";
                    result.Data = data;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
                ChapterLesson chapterLesson = _context.chapter_lesson.Where(x => x.SortNumber == 1 && x.CourseChapterId == courseChapter.Id).SingleOrDefault();
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
            CommentLesson commentLesson = new CommentLesson();
            commentLesson.LessonId = subCommentLessonRequest.LessonId;
            commentLesson.CreateDateTime = DateTime.Now;
            commentLesson.LikeCount = 0;
            commentLesson.Comment = subCommentLessonRequest.CommentContent;
            commentLesson.UserId = subCommentLessonRequest.UserId;
            commentLesson.CommentLessonParentId = subCommentLessonRequest.CommentParentId;
            await _context.AddAsync(commentLesson);
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
            ChapterLesson chapterLesson = await _context.chapter_lesson.Where(x => x.LessonId == sendPracticeRequest.LessonId && x.CourseChapterId == sendPracticeRequest.ChapterId).FirstOrDefaultAsync();
            ChapterLesson chapterLessonNext = await _context.chapter_lesson.Where(x => x.CourseChapterId == sendPracticeRequest.ChapterId && x.SortNumber == chapterLesson.SortNumber + 1).FirstOrDefaultAsync();
            if (chapterLessonNext != null)
            {
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
                    // Không còn học phần tốt nghiệp khóa
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

        public async Task<ResponData<ActionStatus>> SendQuestionAnswer(int questionId, int userAnswer, int userId)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            return result;
        }
    }
}
