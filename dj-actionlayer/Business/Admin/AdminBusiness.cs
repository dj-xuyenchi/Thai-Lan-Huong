using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DJ_UploadFile.Services;
using dj_webdesigncore.Business.Admin;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Admin;
using dj_webdesigncore.DTOs.Lobby;
using dj_webdesigncore.DTOs.Post;
using dj_webdesigncore.Entities.BlogEntity;
using dj_webdesigncore.Entities.BusinessEntity;
using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Entities.PostEntity;
using dj_webdesigncore.Entities.UserEntity;
using dj_webdesigncore.Enums.ApiEnums;
using dj_webdesigncore.Request.Blog;
using dj_webdesigncore.Request.Chapter;
using dj_webdesigncore.Request.Course;
using dj_webdesigncore.Request.Lesson;
using dj_webdesigncore.Request.Post;
using dj_webdesigncore.Request.SomeThingElse;
using Google.Apis.AnalyticsReporting.v4.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ChapterDetailDTO = dj_webdesigncore.DTOs.Admin.ChapterDetailDTO;
using CourseDetailDTO = dj_webdesigncore.DTOs.Admin.CourseDetailDTO;
using LessonDetailDTO = dj_webdesigncore.DTOs.Admin.LessonDetailDTO;
using User = dj_webdesigncore.Entities.UserEntity.User;

namespace dj_actionlayer.Business.Admin
{
    public class AdminBusiness : BaseBusiness, IAdminBusiness
    {
        public async Task<ResponData<ActionStatus>> addBlog(IFormFile img, AddBlogRequest addBlogRequest)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            Blog blog = new Blog();
            blog.BlogLink = addBlogRequest.Link;
            blog.BlogTitle = addBlogRequest.Title;
            blog.CreateTime = DateTime.Now;
            blog.BlogTypeId = 1;
            blog.StatusId = 2;
            blog.CmtCount = 0;
            blog.ViewCount = 0;
            blog.BlogImg = await CloudinaryUpload.UploadFile(img);
            await _context.AddAsync(blog);
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<AddChapterDTO>> addChapter(AddChapterRequest addChapterRequest)
        {
            ResponData<AddChapterDTO> result = new ResponData<AddChapterDTO>();
            AddChapterDTO data = new AddChapterDTO();
            try
            {
                CourseChapter courseChapter = new CourseChapter();
                courseChapter.ChapterCreateDateTime = DateTime.Now;
                courseChapter.ChapterTotalTime = addChapterRequest.ChapterTotalTime;
                courseChapter.ChapterName = addChapterRequest.ChapterName;
                courseChapter.CourseId = addChapterRequest.CourseId;
                Course course = await _context.course.FindAsync(addChapterRequest.CourseId);
                course.ChapterCount++;
                var lastChapter = _context.course_chapter.Where(x => x.CourseId == addChapterRequest.CourseId).OrderByDescending(x => x.SortNumber).FirstOrDefault();
                if (lastChapter == null)
                {
                    courseChapter.SortNumber = 1;
                }
                else
                {
                    courseChapter.SortNumber = lastChapter.SortNumber + 1;
                }
                await _context.AddAsync(courseChapter);
                await _context.SaveChangesAsync();
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

        public async Task<ResponData<ActionStatus>> addCourse(IFormFile img, AddCourseRequest addCourseRequest)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            Course course = new Course();
            course.ChapterCount = 0;
            course.CourseCode = addCourseRequest.courseCode;
            course.CourseLevelId = addCourseRequest.levelId;
            course.CourseName = addCourseRequest.courseName;
            course.CourseStatusId = 2;
            course.CourseSubTitle = addCourseRequest.courseSubTitle;
            course.IntroVideoLink = addCourseRequest.introVideoLink;
            course.TimeLessonTotal = addCourseRequest.totalTime;
            course.CourseTypeId = addCourseRequest.typeId;
            course.RegisterCount = 0;
            course.DoneCount = 0;
            course.CourseImageData = await CloudinaryUpload.UploadFile(img);
            await _context.AddAsync(course);
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<AddLesson2ChapterDTO>> addLesson2Chapter(UpdateSortNumberLessonRequest updateSortNumberLessonRequest)
        {
            ResponData<AddLesson2ChapterDTO> result = new ResponData<AddLesson2ChapterDTO>();
            AddLesson2ChapterDTO data = new AddLesson2ChapterDTO();
            try
            {
                ChapterLesson chapterLesson = new ChapterLesson();
                ChapterLesson lastLesson = await _context.chapter_lesson.Where(x => x.CourseChapterId == updateSortNumberLessonRequest.CourseChapterId).OrderByDescending(x => x.SortNumber).FirstOrDefaultAsync();
                if (lastLesson == null)
                {
                    chapterLesson.SortNumber = 1;
                }
                else
                {
                    chapterLesson.SortNumber = lastLesson.SortNumber + 1;
                }
                chapterLesson.CourseChapterId = updateSortNumberLessonRequest.CourseChapterId;
                chapterLesson.LessonId = updateSortNumberLessonRequest.LessonId;
                chapterLesson.AddLessonToChapterDateTime = DateTime.Now;
                await _context.AddAsync(chapterLesson);
                CourseChapter courseChapter = await _context.course_chapter.FindAsync(updateSortNumberLessonRequest.CourseChapterId);
                courseChapter.ChapterLessonCount++;
                Course course = await _context.course.FindAsync(courseChapter.CourseId);
                course.LessonCount++;
                var listUserResi = _context.user_course.Where(x => x.CourseId == courseChapter.CourseId).ToList();
                Lesson lesson = await _context.lesson.FindAsync(updateSortNumberLessonRequest.LessonId);
                foreach (var item in listUserResi)
                {
                    if (!await _context.user_lesson_checkpoint.AnyAsync(x => x.LessonId == lesson.Id && x.UserId == item.UserId))
                    {
                        UserLessonCheckpoint userLessonCheckpoint = new UserLessonCheckpoint();
                        userLessonCheckpoint.UserId = (int)item.UserId;
                        userLessonCheckpoint.LessonId = lesson.Id;
                        userLessonCheckpoint.OpenLessonDateTime = DateTime.Now;
                        userLessonCheckpoint.IsDone = true;
                        await _context.AddAsync(userLessonCheckpoint);
                    }
                    switch (lesson.LessonTypeId)
                    {
                        case 1:
                            VideoLesson videoLesson = await _context.video_lesson.Where(x => x.LessonId == lesson.Id).FirstOrDefaultAsync();
                            VideoDoneData isExistVideo = await _context.video_done_data.Where(x => x.VideoLessonId == videoLesson.Id && x.UserId == item.Id).FirstOrDefaultAsync();
                            if (isExistVideo != null)
                            {
                                break;
                            }
                            VideoDoneData videoDoneData = new VideoDoneData();
                            videoDoneData.VideoLessonId = videoLesson.Id;
                            videoDoneData.UserId = (int)item.UserId;
                            videoDoneData.DoneTime = DateTime.Now;
                            await _context.AddAsync(videoDoneData);
                            break;
                        case 2:
                            dj_webdesigncore.Entities.CourseEntity.PracticeLesson practiceLesson = await _context.practice_lesson.Where(x => x.LessonId == lesson.Id).FirstOrDefaultAsync();
                            PracticeDoneData isExistPractice = await _context.practice_done_data.Where(x => x.PracticeLessonId == practiceLesson.Id && x.UserId == item.Id).FirstOrDefaultAsync();
                            if (isExistPractice != null)
                            {
                                break;
                            }
                            PracticeDoneData practiceDoneData = new PracticeDoneData();
                            practiceDoneData.PracticeLessonId = practiceLesson.Id;
                            practiceDoneData.UserId = (int)item.UserId;
                            practiceDoneData.DoneData = practiceLesson.BeginCodeMethod;
                            practiceDoneData.DoneTime = DateTime.Now;
                            practiceDoneData.LangueId = practiceLesson.LangueDefaultId;
                            await _context.AddAsync(practiceDoneData);
                            break;
                        case 3:
                            QuestionLesson questionLesson = await _context.question_lesson.Where(x => x.LessonId == lesson.Id).FirstOrDefaultAsync();
                            QuestionDoneData isExistQuestion = await _context.question_done_data.Where(x => x.QuestionLessonId == questionLesson.Id && x.UserId == item.Id).FirstOrDefaultAsync();
                            if (isExistQuestion != null)
                            {
                                break;
                            }
                            QuestionDoneData questionDoneData = new QuestionDoneData();
                            questionDoneData.QuestionLessonId = questionLesson.Id;
                            questionDoneData.DoneTime = DateTime.Now;
                            questionDoneData.UserId = (int)item.UserId;
                            questionDoneData.Answer = questionLesson.Answer;
                            await _context.AddAsync(questionDoneData);
                            break;
                    }

                }
                await _context.SaveChangesAsync();
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.SECCESSFULLY;
                data.Mes = "Thành công!";
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                data.Mes = "Lỗi";
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.FAILED;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<ActionStatus>> addMultiLangue(AddMultiLangue addMultiLangue)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            MultiLangueCode multiLangueCode = new MultiLangueCode();
            multiLangueCode.PracticeId = addMultiLangue.practiceLessonId;
            multiLangueCode.BeginCodeMethod = addMultiLangue.beginCode;
            multiLangueCode.CallTestCode = addMultiLangue.callTestCode;
            multiLangueCode.LangueId = addMultiLangue.langueId;
            await _context.AddAsync(multiLangueCode);
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<AddLessonDTO>> addPracticeLesson(dj_webdesigncore.Request.Lesson.PracticeLesson practiceLesson)
        {
            ResponData<AddLessonDTO> result = new ResponData<AddLessonDTO>();
            AddLessonDTO data = new AddLessonDTO();
            try
            {
                Lesson lesson = new Lesson();
                lesson.LessonStatusId = 1;
                lesson.LessonName = practiceLesson.lessonName;
                lesson.LessonDescription = practiceLesson.lessonDescription;
                lesson.VideoTime = practiceLesson.lessonTime;
                lesson.CreateDateTime = DateTime.Now;
                lesson.LessonTypeId = 2;
                await _context.AddAsync(lesson);
                await _context.SaveChangesAsync();
                dj_webdesigncore.Entities.CourseEntity.PracticeLesson practiceNew = new dj_webdesigncore.Entities.CourseEntity.PracticeLesson();
                practiceNew.LessonId = lesson.Id;
                practiceNew.BeginCodeMethod = practiceLesson.beginCode;
                practiceNew.Problem = practiceLesson.problem;
                practiceNew.ProblemDetail = practiceLesson.problemDetail;
                practiceNew.CallTestCode = practiceLesson.callTestCode;
                practiceNew.LangueDefaultId = practiceLesson.langueId;
                practiceNew.ExpectOutput = practiceLesson.outputExemple;
                practiceNew.IsSupportMultiLangue = practiceLesson.isSupportMutilLangue;
                practiceNew.Input = practiceLesson.inputExemple;
                practiceNew.Suggest = practiceLesson.suggest;
                practiceNew.Explain = practiceLesson.explainCode;
                await _context.AddAsync(practiceNew);
                await _context.SaveChangesAsync();
                TestCase defaultTestCase = new TestCase();
                defaultTestCase.ExpectOutput = practiceNew.ExpectOutput;
                defaultTestCase.Input = practiceNew.Input;
                defaultTestCase.PracticeLessonId = practiceNew.Id;
                defaultTestCase.LockTestCase = false;
                defaultTestCase.InputDetail = practiceLesson.caseDefaultDetail;
                defaultTestCase.SortNumber = 1;
                await _context.AddAsync(defaultTestCase);
                await _context.SaveChangesAsync();
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.SECCESSFULLY;
                data.Mes = "Thêm bài học thành công!";
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

        public async Task<ResponData<AddLessonDTO>> addQuestionLesson(QuestionLessonRequest questionLessonRequest)
        {
            ResponData<AddLessonDTO> result = new ResponData<AddLessonDTO>();
            AddLessonDTO data = new AddLessonDTO();
            try
            {
                Lesson lesson = new Lesson();
                lesson.LessonStatusId = 1;
                lesson.LessonName = questionLessonRequest.lessonName;
                lesson.LessonDescription = questionLessonRequest.lessonDescription;
                lesson.VideoTime = questionLessonRequest.lessonTime;
                lesson.CreateDateTime = DateTime.Now;
                lesson.LessonTypeId = 3;
                await _context.AddAsync(lesson);
                await _context.SaveChangesAsync();
                QuestionLesson questionLesson = new QuestionLesson();
                questionLesson.LessonId = lesson.Id;
                questionLesson.AnswerA = questionLessonRequest.answerA;
                questionLesson.AnswerB = questionLessonRequest.answerB;
                questionLesson.AnswerC = questionLessonRequest.answerC;
                questionLesson.AnswerD = questionLessonRequest.answerD;
                questionLesson.Answer = questionLessonRequest.answer;
                questionLesson.Question = questionLessonRequest.question;
                await _context.AddAsync(questionLesson);
                await _context.SaveChangesAsync();
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.SECCESSFULLY;
                data.Mes = "Thêm bài học thành công!";
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

        public async Task<ResponData<AddTestCaseDTO>> addTestCase(TestCaseRequest testCaseRequest)
        {
            ResponData<AddTestCaseDTO> result = new ResponData<AddTestCaseDTO>();
            AddTestCaseDTO data = new AddTestCaseDTO();
            try
            {
                var lastCase = _context.test_case.Where(x => x.PracticeLessonId == testCaseRequest.PracticeId).OrderByDescending(x => x.SortNumber).FirstOrDefault();
                TestCase testCase = new TestCase();
                testCase.ExpectOutput = testCaseRequest.Output;
                testCase.Input = testCaseRequest.Input;
                testCase.InputDetail = testCaseRequest.InputDetail;
                testCase.LockTestCase = testCaseRequest.IsLock;
                testCase.PracticeLessonId = testCaseRequest.PracticeId;
                testCase.SortNumber = lastCase.SortNumber + 1;
                await _context.AddAsync(testCase);
                await _context.SaveChangesAsync();
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.SECCESSFULLY;
                data.Mes = "Thêm bài học thành công!";
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

        public async Task<ResponData<AddLessonDTO>> addTheoryLesson(TheoryLessonRequest theoryLessonRequest)
        {
            ResponData<AddLessonDTO> result = new ResponData<AddLessonDTO>();
            AddLessonDTO data = new AddLessonDTO();
            try
            {
                Lesson lesson = new Lesson();
                lesson.LessonStatusId = 1;
                lesson.LessonName = theoryLessonRequest.lessonName;
                lesson.LessonDescription = theoryLessonRequest.lessonDescription;
                lesson.VideoTime = theoryLessonRequest.lessonTime;
                lesson.CreateDateTime = DateTime.Now;
                lesson.LessonTypeId = 1;
                await _context.AddAsync(lesson);
                await _context.SaveChangesAsync();
                VideoLesson videoLesson = new VideoLesson();
                videoLesson.LessonId = lesson.Id;
                videoLesson.LessonLinkUrl = theoryLessonRequest.videoLink;
                await _context.AddAsync(videoLesson);
                await _context.SaveChangesAsync();
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.SECCESSFULLY;
                data.Mes = "Thêm bài học thành công!";
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

        public async Task<ResponData<ActionStatus>> changeSlide(IFormFile? slide1, IFormFile? slide2, IFormFile? slide3, IFormFile? slide4, IFormFile? slide5)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            HomeContent homeContent = await _context.home_content.FindAsync(2);
            if (slide1 != null)
            {
                homeContent.Slide1 = await CloudinaryUpload.UploadFile(slide1);
            }
            if (slide2 != null)
            {
                homeContent.Slide2 = await CloudinaryUpload.UploadFile(slide2);
            }
            if (slide3 != null)
            {
                homeContent.Slide3 = await CloudinaryUpload.UploadFile(slide3);
            }
            if (slide4 != null)
            {
                homeContent.Slide4 = await CloudinaryUpload.UploadFile(slide4);
            }
            if (slide5 != null)
            {
                homeContent.Slide5 = await CloudinaryUpload.UploadFile(slide5);
            }
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<ActionStatus>> checkDenounce(ConfirmDenounceRequest confirmDenounce)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            User checker = await _context.user.FindAsync(confirmDenounce.UserCheckId);
            if (checker == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            User vio = await _context.user.FindAsync(confirmDenounce.VioId);
            if (vio == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            Denounce denounce = await _context.denounce.FindAsync(confirmDenounce.DenounceId);
            if (denounce == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            if (confirmDenounce.IsVio)
            {
                denounce.IsCheck = true;
                denounce.IsViolation = true;
                denounce.CheckTime = DateTime.Now;
                denounce.UserCheckId = checker.Id;
                vio.OpenLockTime = DateTime.Now;
                switch (confirmDenounce.LockOpt)
                {
                    case 1:
                        vio.IsLock = true;
                        vio.UserStatusId = 4;
                        vio.UnlockTime = DateTime.Now.AddDays(3);
                        break;
                    case 2:
                        vio.IsLock = true;
                        vio.UserStatusId = 4;
                        vio.UnlockTime = DateTime.Now.AddDays(5);
                        break;
                    case 3:
                        vio.IsLock = true;
                        vio.UserStatusId = 4;
                        vio.UnlockTime = DateTime.Now.AddDays(7);
                        break;
                    case 4:
                        vio.IsLock = true;
                        vio.UserStatusId = 2;
                        break;
                }
                vio.VioCount++;
                await _context.SaveChangesAsync();
                result.Data = ActionStatus.SECCESSFULLY;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            else
            {
                denounce.IsCheck = true;
                denounce.IsViolation = false;
                denounce.CheckTime = DateTime.Now;
                denounce.UserCheckId = checker.Id;
                await _context.SaveChangesAsync();
                result.Data = ActionStatus.SECCESSFULLY;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
        }

        public async Task<ResponData<ActionStatus>> deleteCourseChapter(int courseChapterId)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            CourseChapter courseChapter = await _context.course_chapter.FindAsync(courseChapterId);
            if (courseChapter == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            Course course = await _context.course.FindAsync(courseChapter.CourseId);
            course.ChapterCount--;
            _context.Remove(courseChapter);
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<AddLesson2ChapterDTO>> deleteLessonOfChapter(int lessonChapterId)
        {
            ResponData<AddLesson2ChapterDTO> result = new ResponData<AddLesson2ChapterDTO>();
            AddLesson2ChapterDTO data = new AddLesson2ChapterDTO();
            try
            {
                ChapterLesson chapterLesson = await _context.chapter_lesson.FindAsync(lessonChapterId);
                if (chapterLesson == null)
                {
                    data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.NOTFOUND;
                    data.Mes = "Không tòn tại bản ghi!";
                    result.Data = data;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
                CourseChapter courseChapter = await _context.course_chapter.FindAsync(chapterLesson.CourseChapterId);
                courseChapter.ChapterLessonCount--;
                Course course = await _context.course.FindAsync(courseChapter.CourseId);
                course.LessonCount--;
                _context.Remove(chapterLesson);
                await _context.SaveChangesAsync();
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.SECCESSFULLY;
                data.Mes = "Xóa thành công!";
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

        public async Task<ResponData<AddTestCaseDTO>> deleteTestCase(int testCaseId)
        {
            ResponData<AddTestCaseDTO> result = new ResponData<AddTestCaseDTO>();
            AddTestCaseDTO data = new AddTestCaseDTO();
            try
            {
                TestCase testCase = await _context.test_case.FindAsync(testCaseId);
                if (testCase == null)
                {
                    data.Mes = "Không tồn tại test case có Id là " + testCaseId;
                    data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.NOTFOUND;
                    result.Data = data;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
                _context.Remove(testCase);
                await _context.SaveChangesAsync();
                data.Mes = "Xóa thành công!";
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.SECCESSFULLY;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                data.Mes = "Lỗi";
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.FAILED;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }

        }

        public async Task<ResponData<List<BlogDTO>>> findBlog(string key)
        {
            ResponData<List<BlogDTO>> result = new ResponData<List<BlogDTO>>();
            int stt = 1;
            List<BlogDTO> blogList = new List<BlogDTO>();
            var listData = _context.blog.Where(x => x.BlogTitle.Contains(key)).OrderByDescending(x => x.CreateTime).ToList();
            foreach (var item in listData)
            {
                BlogDTO blog = new BlogDTO();
                blog.Stt = stt;
                stt++;
                blog.CreateTime = item.CreateTime.Day + " - " + item.CreateTime.Month + " - " + item.CreateTime.Year;
                if (item.UpdateTime == null)
                {
                    blog.UpdateTime = "Chưa cập nhật";
                }
                else
                {
                    blog.UpdateTime = item.UpdateTime.Value.Day + " - " + item.UpdateTime.Value.Month + " - " + item.UpdateTime.Value.Year; ;
                }
                blog.Title = item.BlogTitle;
                blog.CmtCount = item.CmtCount;
                blog.ViewCount = item.ViewCount;
                blog.IsActive = item.StatusId;
                blog.Id = item.Id;
                blog.BlogImg = item.BlogImg;
                blog.BlogLink = item.BlogLink;
                blogList.Add(blog);
            }
            result.Data = blogList;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<GetLessonDTO>> findLesson(string key)
        {
            ResponData<GetLessonDTO> result = new ResponData<GetLessonDTO>();
            GetLessonDTO data = new GetLessonDTO();
            try
            {
                int stt = 1;
                List<LessonDetailDTO> lessonDetailDTO = new List<LessonDetailDTO>();
                var listLesson = _context.lesson.Where(x => x.LessonName.Contains(key)).OrderByDescending(x => x.CreateDateTime).ToList();
                foreach (var item in listLesson)
                {
                    LessonDetailDTO lessonDetail = new LessonDetailDTO();
                    lessonDetail.stt = stt;
                    stt++;
                    lessonDetail.LessonId = item.Id;
                    lessonDetail.LessonDescription = item.LessonDescription;
                    lessonDetail.LessonName = item.LessonName;
                    lessonDetail.CreateDateTime = item.CreateDateTime.Day + " - " + item.CreateDateTime.Month + " - " + item.CreateDateTime.Year;
                    lessonDetail.VideoTime = item.VideoTime;
                    lessonDetail.LessonType = _context.lesson_type.Find(item.LessonTypeId).LessonTypeName;
                    lessonDetail.LessonTypeId = (int)item.LessonTypeId;
                    if (item.UpdateDateTime != null)
                    {
                        lessonDetail.UpdateDateTime = item.UpdateDateTime.Value.Day + " - " + item.UpdateDateTime.Value.Month + " - " + item.UpdateDateTime.Value.Year;
                    }
                    else
                    {
                        lessonDetail.UpdateDateTime = "";
                    }
                    if (item.LessonTypeId == 3)
                    {
                        QuestionLesson questionLesson = await _context.question_lesson.Where(x => x.LessonId == item.Id).FirstOrDefaultAsync();
                        if (questionLesson == null)
                        {
                            continue;
                        }
                        lessonDetail.question = questionLesson.Question;
                        lessonDetail.answerA = questionLesson.AnswerA;
                        lessonDetail.answerB = questionLesson.AnswerB;
                        lessonDetail.answerC = questionLesson.AnswerC;
                        lessonDetail.answerD = questionLesson.AnswerD;
                        switch (questionLesson.Answer)
                        {
                            case 1:
                                lessonDetail.answer = "A";
                                break;
                            case 2:
                                lessonDetail.answer = "B";
                                break;
                            case 3:
                                lessonDetail.answer = "C";
                                break;
                            case 4:
                                lessonDetail.answer = "D";
                                break;
                        }
                    }
                    if (item.LessonTypeId == 2)
                    {
                        dj_webdesigncore.Entities.CourseEntity.PracticeLesson practiceLesson = await _context.practice_lesson.Where(x => x.LessonId == item.Id).FirstOrDefaultAsync();
                        TestCase testCase = await _context.test_case.Where(x => x.PracticeLessonId == practiceLesson.Id && x.SortNumber == 1).FirstOrDefaultAsync();
                        if (testCase == null) { continue; }
                        lessonDetail.problem = practiceLesson.Problem;
                        lessonDetail.practiceId = practiceLesson.Id;
                        lessonDetail.problemDetail = practiceLesson.ProblemDetail;
                        lessonDetail.outputExemple = practiceLesson.ExpectOutput;
                        lessonDetail.suggest = practiceLesson.Suggest;
                        lessonDetail.inputExemple = practiceLesson.Input;
                        lessonDetail.isSupportMultiLangue = (bool)practiceLesson.IsSupportMultiLangue;
                        lessonDetail.langue = await _context.langue.FindAsync(practiceLesson.LangueDefaultId);
                        lessonDetail.beginCode = practiceLesson.BeginCodeMethod;
                        lessonDetail.callTestCode = practiceLesson.CallTestCode;
                        lessonDetail.caseDefaultDetail = testCase.InputDetail;
                        lessonDetail.explainCode = practiceLesson.Explain;
                    }
                    if (item.LessonTypeId == 1)
                    {
                        VideoLesson videoLesson = _context.video_lesson.Where(x => x.LessonId == item.Id).FirstOrDefault();

                        lessonDetail.linkVideo = videoLesson.LessonLinkUrl;
                    }
                    lessonDetailDTO.Add(lessonDetail);
                }
                data.list = lessonDetailDTO;
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

        public async Task<ResponData<List<TestCaseDTO>>> getAllTestCase(int practiceId)
        {
            ResponData<List<TestCaseDTO>> result = new ResponData<List<TestCaseDTO>>();
            try
            {
                List<TestCaseDTO> data = new List<TestCaseDTO>();
                var testList = _context.test_case.Where(x => x.PracticeLessonId == practiceId).OrderBy(x => x.SortNumber).ToList();
                foreach (var item in testList)
                {
                    TestCaseDTO testCaseDTO = new TestCaseDTO();
                    testCaseDTO.TestCaseId = item.Id;
                    testCaseDTO.Input = item.Input;
                    testCaseDTO.Output = item.ExpectOutput;
                    testCaseDTO.SortNumber = item.SortNumber;
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

        public async Task<ResponData<List<dj_webdesigncore.DTOs.Lobby.BlogDTO>>> getBlog(int page)
        {
            ResponData<List<dj_webdesigncore.DTOs.Lobby.BlogDTO>> result = new ResponData<List<dj_webdesigncore.DTOs.Lobby.BlogDTO>>();
            List<dj_webdesigncore.DTOs.Lobby.BlogDTO> data = new List<BlogDTO>();
            int stt = 1;
            var listLesson = _context.blog.OrderByDescending(x => x.CreateTime).Skip((page - 1) * 15).Take(15).ToList();
            foreach (var item in listLesson)
            {
                BlogDTO blog = new BlogDTO();
                blog.Stt = stt;
                stt++;
                blog.CreateTime = item.CreateTime.Day + " - " + item.CreateTime.Month + " - " + item.CreateTime.Year;
                if (item.UpdateTime == null)
                {
                    blog.UpdateTime = "Chưa cập nhật";
                }
                else
                {
                    blog.UpdateTime = item.UpdateTime.Value.Day + " - " + item.UpdateTime.Value.Month + " - " + item.UpdateTime.Value.Year; ;
                }
                blog.Title = item.BlogTitle;
                blog.CmtCount = item.CmtCount;
                blog.ViewCount = item.ViewCount;
                blog.IsActive = item.StatusId;
                blog.Id = item.Id;
                blog.BlogImg = item.BlogImg;
                blog.BlogLink = item.BlogLink;
                data.Add(blog);
            }
            result.Data = data;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<List<ChapterCourseInfo>>> getChapterOfCourse(int courseId)
        {
            ResponData<List<ChapterCourseInfo>> result = new ResponData<List<ChapterCourseInfo>>();
            var listChapter = _context.course_chapter.Where(x => x.CourseId == courseId).OrderBy(x => x.SortNumber).ToList();
            List<ChapterCourseInfo> data = new List<ChapterCourseInfo>();
            foreach (var item in listChapter)
            {
                ChapterCourseInfo chapterCourseInfo = new ChapterCourseInfo();
                chapterCourseInfo.id = item.Id;
                chapterCourseInfo.sortNumber = item.SortNumber;
                chapterCourseInfo.name = item.ChapterName;
                chapterCourseInfo.lessonCount = item.ChapterLessonCount;
                chapterCourseInfo.totalTime = item.ChapterTotalTime;
                data.Add(chapterCourseInfo);
            }
            result.Data = data;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<GetChapterDTO>> getChapterPage(int page)
        {
            ResponData<GetChapterDTO> result = new ResponData<GetChapterDTO>();
            GetChapterDTO data = new GetChapterDTO();
            try
            {
                List<ChapterDetailDTO> chapterDetail = new List<ChapterDetailDTO>();
                var listChapter = _context.course_chapter.OrderByDescending(x => x.ChapterCreateDateTime).Skip((page - 1) * 10).Take(10).ToList();
                foreach (var item in listChapter)
                {
                    ChapterDetailDTO chapterDetailDTO = new ChapterDetailDTO();
                    chapterDetailDTO.ChapterId = item.Id;
                    chapterDetailDTO.ChapterName = item.ChapterName;
                    chapterDetailDTO.CreateDateTime = item.ChapterCreateDateTime.Day + " - " + item.ChapterCreateDateTime.Month + " - " + item.ChapterCreateDateTime.Year;
                    chapterDetailDTO.TimeTotal = item.ChapterTotalTime;
                    chapterDetailDTO.LessonCount = item.ChapterLessonCount.ToString();
                    //chapterDetailDTO.LessonCount = _context.chapter_lesson.Where(x => x.CourseChapterId == item.Id).Count().ToString();
                    chapterDetail.Add(chapterDetailDTO);
                }
                data.list = chapterDetail;
                int size = _context.lesson.Count();
                data.maxPage = _context.lesson.Count() / 10;
                if (size % 10 != 0 && size > 10)
                {
                    data.maxPage++;
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

        public async Task<ResponData<GetCourseDTO>> getCoursePage(int page)
        {
            ResponData<GetCourseDTO> result = new ResponData<GetCourseDTO>();
            GetCourseDTO data = new GetCourseDTO();
            try
            {
                List<CourseDetailDTO> courseDetailDTOs = new List<CourseDetailDTO>();
                var listCourse = _context.course.Skip((page - 1) * 10).Take(10).ToList();
                foreach (var item in listCourse)
                {
                    CourseDetailDTO courseDetailDTO = new CourseDetailDTO();
                    courseDetailDTO.CourseId = item.Id;
                    courseDetailDTO.ChapterCount = item.ChapterCount.ToString();
                    courseDetailDTO.CourseCode = item.CourseCode;
                    courseDetailDTO.CourseName = item.CourseName;
                    courseDetailDTO.CourseLevelId = (int)item.CourseLevelId;
                    courseDetailDTO.CourseLevel = _context.course_level.Find(item.CourseLevelId).LevelName;
                    courseDetailDTO.CourseStatusId = (int)item.CourseStatusId;
                    courseDetailDTO.CourseStatus = _context.course_status.Find(item.CourseStatusId).CourseStatusName;
                    courseDetailDTO.CourseImageData = item.CourseImageData;
                    courseDetailDTO.CourseSubTitle = item.CourseSubTitle;
                    courseDetailDTO.CourseType = _context.course_type.Find(item.CourseTypeId).CourseTypeName;
                    courseDetailDTO.CourseTypeId = item.CourseTypeId;
                    courseDetailDTO.TimeLessonTotal = item.TimeLessonTotal;
                    courseDetailDTO.RegisterCount = item.RegisterCount;
                    courseDetailDTO.DoneCount = item.DoneCount;
                    courseDetailDTO.LinkVideoIntro = item.IntroVideoLink;
                    courseDetailDTO.LessonCount = item.LessonCount.ToString();
                    courseDetailDTOs.Add(courseDetailDTO);
                }
                data.list = courseDetailDTOs;
                int size = _context.lesson.Count();
                data.maxPage = _context.lesson.Count() / 10;
                if (size % 10 != 0 && size > 10)
                {
                    data.maxPage++;
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

        public async Task<ResponData<List<DenounceReportADMIN>>> getDenouncePage(int page)
        {
            ResponData<List<DenounceReportADMIN>> result = new ResponData<List<DenounceReportADMIN>>();
            var listDenounce = _context.denounce.Where(x => x.IsCheck == false).OrderByDescending(x => x.SendTime).Skip((page - 1) * 15).Take(15).ToList();
            List<DenounceReportADMIN> data = new List<DenounceReportADMIN>();
            foreach (var item in listDenounce)
            {
                DenounceReportADMIN denounceReportADMIN = new DenounceReportADMIN();
                denounceReportADMIN.linkCmt = item.ProveLink;
                denounceReportADMIN.denounceId = item.Id;
                denounceReportADMIN.vioId = item.UserViolationId;
                DenounceType dt = await _context.denounce_type.FindAsync(item.DenounceTypeId);
                denounceReportADMIN.typeDenounce = dt.DenounceName;
                if (item.TypeCmt == dj_webdesigncore.Enums.Else.TypeCmt.LESSON)
                {
                    CommentLesson cmtL = await _context.comment_lesson.FindAsync(item.CmtId);
                    denounceReportADMIN.cmtDenounceContent = cmtL.Comment;
                }
                if (item.TypeCmt == dj_webdesigncore.Enums.Else.TypeCmt.POST)
                {
                    CommentPost cmtP = await _context.comment_post.FindAsync(item.CmtId);
                    denounceReportADMIN.cmtDenounceContent = cmtP.Comment;
                }
                User sender = await _context.user.FindAsync(item.UserSendId);
                denounceReportADMIN.senderId = sender.Id;
                denounceReportADMIN.senderImg = sender.UserAvatarData40x40;
                denounceReportADMIN.senderName = sender.UserFisrtName + " " + sender.UserLastName;
                denounceReportADMIN.senderKYC = (bool)sender.IsKYC;
                User vio = await _context.user.FindAsync(item.UserViolationId);
                denounceReportADMIN.vioImg = vio.UserAvatarData40x40;
                denounceReportADMIN.vioId = vio.Id;
                denounceReportADMIN.vioKYC = (bool)vio.IsKYC;
                denounceReportADMIN.vioName = vio.UserFisrtName + " " + vio.UserLastName;
                denounceReportADMIN.sendTime = item.SendTime.Day + " - " + item.SendTime.Month + " - " + item.SendTime.Year;
                denounceReportADMIN.note = item.Note;
                denounceReportADMIN.VioCount = (int)vio.VioCount;
                data.Add(denounceReportADMIN);
            }
            result.Data = data;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<HomeContent>> getHomeContent()
        {
            ResponData<HomeContent> result = new ResponData<HomeContent>();
            HomeContent data = await _context.home_content.FindAsync(2);
            if (data == null)
            {
                data = await _context.home_content.FindAsync(1);
            }
            if (data == null)
            {
                result.Data = null;
                result.Messenger = "Lấy dữ liệu thành công!";
                result.Status = ActionStatus.SECCESSFULLY;
                return result;
            }
            result.Data = data;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<List<Langue>>> getLangueHaveNot(int practiceLessonId)
        {
            ResponData<List<Langue>> result = new ResponData<List<Langue>>();
            var listLangue = _context.langue.ToList();
            List<Langue> data = new List<Langue>();
            foreach (var item in listLangue)
            {
                if (_context.multi_langue_code.Any(x => x.LangueId == item.Id && x.PracticeId == practiceLessonId))
                {
                    continue;
                }
                data.Add(item);
            }
            result.Data = data;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<List<LessonDetailDTO>>> getLessonNotInChapter()
        {
            ResponData<List<LessonDetailDTO>> result = new ResponData<List<LessonDetailDTO>>();
            List<LessonDetailDTO> data = new List<LessonDetailDTO>();
            try
            {
                var list = _context.lesson.Where(x => _context.chapter_lesson.Any(y => y.LessonId == x.Id) == false).ToList();
                foreach (var item in list)
                {
                    LessonDetailDTO lessonDetailDTO = new LessonDetailDTO();
                    lessonDetailDTO.LessonName = item.LessonName;
                    lessonDetailDTO.LessonId = item.Id;
                    data.Add(lessonDetailDTO);
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

        public async Task<ResponData<List<LessonDetailDTO>>> getLessonOfChapter(int chapterId)
        {
            ResponData<List<LessonDetailDTO>> result = new ResponData<List<LessonDetailDTO>>();
            List<LessonDetailDTO> data = new List<LessonDetailDTO>();
            var listLessonId = _context.chapter_lesson.Where(x => x.CourseChapterId == chapterId).OrderBy(x => x.SortNumber).ToList();
            foreach (var item in listLessonId)
            {
                LessonDetailDTO lessonDetailDTO = new LessonDetailDTO();
                Lesson lesson = await _context.lesson.FindAsync(item.LessonId);
                lessonDetailDTO.LessonName = lesson.LessonName;
                lessonDetailDTO.SortNumber = item.SortNumber;
                lessonDetailDTO.ChapterLessonId = item.Id;
                lessonDetailDTO.LessonType = _context.lesson_type.Find(lesson.LessonTypeId).LessonTypeName;
                data.Add(lessonDetailDTO);
            }
            result.Data = data;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<GetLessonDTO>> getLessonPage(int page)
        {
            ResponData<GetLessonDTO> result = new ResponData<GetLessonDTO>();
            GetLessonDTO data = new GetLessonDTO();
            try
            {
                int stt = 1;
                List<LessonDetailDTO> lessonDetailDTO = new List<LessonDetailDTO>();
                var listLesson = _context.lesson.OrderByDescending(x => x.CreateDateTime).Skip((page - 1) * 15).Take(15).ToList();
                //        var listLesson = _context.lesson.OrderByDescending(x => x.CreateDateTime).ToList();
                foreach (var item in listLesson)
                {
                    LessonDetailDTO lessonDetail = new LessonDetailDTO();
                    lessonDetail.stt = stt;
                    stt++;
                    lessonDetail.LessonId = item.Id;
                    lessonDetail.LessonDescription = item.LessonDescription;
                    lessonDetail.LessonName = item.LessonName;
                    lessonDetail.CreateDateTime = item.CreateDateTime.Day + " - " + item.CreateDateTime.Month + " - " + item.CreateDateTime.Year;
                    lessonDetail.VideoTime = item.VideoTime;
                    lessonDetail.LessonType = _context.lesson_type.Find(item.LessonTypeId).LessonTypeName;
                    lessonDetail.LessonTypeId = (int)item.LessonTypeId;
                    if (item.UpdateDateTime != null)
                    {
                        lessonDetail.UpdateDateTime = item.UpdateDateTime.Value.Day + " - " + item.UpdateDateTime.Value.Month + " - " + item.UpdateDateTime.Value.Year;
                    }
                    else
                    {
                        lessonDetail.UpdateDateTime = "";
                    }
                    if (item.LessonTypeId == 3)
                    {
                        QuestionLesson questionLesson = await _context.question_lesson.Where(x => x.LessonId == item.Id).FirstOrDefaultAsync();
                        if (questionLesson == null)
                        {
                            continue;
                        }
                        lessonDetail.question = questionLesson.Question;
                        lessonDetail.answerA = questionLesson.AnswerA;
                        lessonDetail.answerB = questionLesson.AnswerB;
                        lessonDetail.answerC = questionLesson.AnswerC;
                        lessonDetail.answerD = questionLesson.AnswerD;
                        switch (questionLesson.Answer)
                        {
                            case 1:
                                lessonDetail.answer = "A";
                                break;
                            case 2:
                                lessonDetail.answer = "B";
                                break;
                            case 3:
                                lessonDetail.answer = "C";
                                break;
                            case 4:
                                lessonDetail.answer = "D";
                                break;
                        }
                    }
                    if (item.LessonTypeId == 2)
                    {
                        dj_webdesigncore.Entities.CourseEntity.PracticeLesson practiceLesson = await _context.practice_lesson.Where(x => x.LessonId == item.Id).FirstOrDefaultAsync();
                        TestCase testCase = await _context.test_case.Where(x => x.PracticeLessonId == practiceLesson.Id && x.SortNumber == 1).FirstOrDefaultAsync();
                        if (testCase == null) { continue; }
                        lessonDetail.problem = practiceLesson.Problem;
                        lessonDetail.practiceId = practiceLesson.Id;
                        lessonDetail.problemDetail = practiceLesson.ProblemDetail;
                        lessonDetail.outputExemple = practiceLesson.ExpectOutput;
                        lessonDetail.suggest = practiceLesson.Suggest;
                        lessonDetail.inputExemple = practiceLesson.Input;
                        lessonDetail.isSupportMultiLangue = (bool)practiceLesson.IsSupportMultiLangue;
                        lessonDetail.langue = await _context.langue.FindAsync(practiceLesson.LangueDefaultId);
                        lessonDetail.beginCode = practiceLesson.BeginCodeMethod;
                        lessonDetail.callTestCode = practiceLesson.CallTestCode;
                        lessonDetail.caseDefaultDetail = testCase.InputDetail;
                        lessonDetail.explainCode = practiceLesson.Explain;
                    }
                    if (item.LessonTypeId == 1)
                    {
                        VideoLesson videoLesson = _context.video_lesson.Where(x => x.LessonId == item.Id).FirstOrDefault();

                        lessonDetail.linkVideo = videoLesson.LessonLinkUrl;
                    }
                    lessonDetailDTO.Add(lessonDetail);
                }
                data.list = lessonDetailDTO;
                int size = _context.lesson.Count();
                data.maxPage = _context.lesson.Count() / 10;
                if (size % 10 != 0 && size > 10)
                {
                    data.maxPage++;
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

        public async Task<ResponData<List<MultiLangueDTO>>> getMultiLangueSuport(int practiceLessonId)
        {
            ResponData<List<MultiLangueDTO>> result = new ResponData<List<MultiLangueDTO>>();
            dj_webdesigncore.Entities.CourseEntity.PracticeLesson practiceLesson = await _context.practice_lesson.FindAsync(practiceLessonId);
            if (practiceLesson == null)
            {
                result.Data = null;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            List<MultiLangueDTO> data = new List<MultiLangueDTO>();
            var listSupport = _context.multi_langue_code.Where(x => x.PracticeId == practiceLessonId).ToList();
            foreach (var item in listSupport)
            {
                MultiLangueDTO multiLangueDTO = new MultiLangueDTO();
                multiLangueDTO.id = item.Id;
                multiLangueDTO.LangueCode = _context.langue.Find(item.LangueId).LangueName;
                multiLangueDTO.BeginCode = item.BeginCodeMethod;
                multiLangueDTO.CallTestCode = item.CallTestCode;
                multiLangueDTO.langue = await _context.langue.FindAsync(item.LangueId);
                data.Add(multiLangueDTO);

            }
            result.Data = data;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<OptionAddCourse>> getOptionAddCourse()
        {
            ResponData<OptionAddCourse> result = new ResponData<OptionAddCourse>();
            OptionAddCourse data = new OptionAddCourse();
            data.Level = _context.course_level.ToList();
            data.Type = _context.course_type.ToList();
            data.Status = _context.course_status.ToList();
            result.Data = data;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<ListPostAdmin>> getPostAdmin(int? statusOptId, int page)
        {
            ResponData<ListPostAdmin> result = new ResponData<ListPostAdmin>();
            ListPostAdmin data = new ListPostAdmin();
            var listPost = _context.post.Include(x => x.UserCreate).Include(x => x.PostStatus).OrderByDescending(x => x.LikeCount).AsNoTracking();
            if (statusOptId != -1)
            {
                listPost = listPost.Where(x => x.PostStatusId == statusOptId);
            }
            data.ListPost = listPost.Skip((page - 1) * 15).Take(15);
            data.ListOption = _context.post_status;
            result.Data = data;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }



        public async Task<ResponData<List<SelectCourseForChapter>>> selectCourseForChapter()
        {
            ResponData<List<SelectCourseForChapter>> result = new ResponData<List<SelectCourseForChapter>>();
            var listCourse = _context.course.ToList();
            List<SelectCourseForChapter> data = new List<SelectCourseForChapter>();
            foreach (var item in listCourse)
            {
                data.Add(new SelectCourseForChapter()
                {
                    CourseId = item.Id,
                    CourseName = item.CourseName
                });
            }
            result.Data = data;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<ActionStatus>> updateBlog(IFormFile? img, AddBlogRequest addBlogRequest)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            Blog blog = await _context.blog.FindAsync(addBlogRequest.Id);
            if (blog == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            blog.BlogLink = addBlogRequest.Link;
            blog.BlogTitle = addBlogRequest.Title;
            blog.UpdateTime = DateTime.Now;
            blog.StatusId = addBlogRequest.StatusId;
            if (img != null)
            {
                blog.BlogImg = await CloudinaryUpload.UploadFile(img);
            }
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<AddChapterDTO>> updateChapter(UpdateChapterRequest updateChapterRequest)
        {
            ResponData<AddChapterDTO> result = new ResponData<AddChapterDTO>();
            AddChapterDTO data = new AddChapterDTO();
            try
            {
                CourseChapter courseChapter = await _context.course_chapter.FindAsync(updateChapterRequest.ChapterId);
                if (courseChapter == null)
                {
                    data.Mes = "Không tồn tại học phần!";
                    data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.NOTFOUND;
                    result.Data = data;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
                courseChapter.ChapterLessonCount = updateChapterRequest.LessonCount;
                courseChapter.ChapterName = updateChapterRequest.ChapterName;
                courseChapter.ChapterTotalTime = updateChapterRequest.ChapterTotalTime;
                await _context.SaveChangesAsync();
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                data.Mes = "Lỗi";
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.FAILED;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<ActionStatus>> updateCourse(IFormFile? img, AddCourseRequest addCourseRequest)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            Course course = await _context.course.FindAsync(addCourseRequest.id);
            if (course == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            course.ChapterCount = addCourseRequest.chapterCount;
            course.CourseCode = addCourseRequest.courseCode;
            course.CourseLevelId = addCourseRequest.levelId;
            course.CourseName = addCourseRequest.courseName;
            course.CourseStatusId = addCourseRequest.statusId;
            course.CourseSubTitle = addCourseRequest.courseSubTitle;
            course.IntroVideoLink = addCourseRequest.introVideoLink;
            course.TimeLessonTotal = addCourseRequest.totalTime;
            course.CourseTypeId = addCourseRequest.typeId;
            course.RegisterCount = addCourseRequest.resigterCount;
            course.DoneCount = addCourseRequest.doneCount;
            if (img != null)
            {
                course.CourseImageData = await CloudinaryUpload.UploadFile(img);
            }
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }
        public async Task<ResponData<ActionStatus>> updateCourseChapterSortNumber(int courseChapterId, int newSortNumber)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            CourseChapter courseChapter = await _context.course_chapter.FindAsync(courseChapterId);
            if (courseChapter == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            courseChapter.SortNumber = newSortNumber;
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<ActionStatus>> updateMultiLangue(AddMultiLangue addMultiLangue)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            MultiLangueCode multiLangueCode = await _context.multi_langue_code.FindAsync(addMultiLangue.id);
            if (multiLangueCode == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            multiLangueCode.BeginCodeMethod = addMultiLangue.beginCode;
            multiLangueCode.CallTestCode = addMultiLangue.callTestCode;
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<ActionStatus>> updatePost(IFormFile? img, UpdatePostAdminRequest updatePostAdmin)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            Post post = await _context.post.FindAsync(updatePostAdmin.PostId);
            if (post == null)
            {
                result.Data = ActionStatus.NOTFOUND;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            if (img != null)
            {
                post.PostAvatar = await CloudinaryUpload.UploadFile(img);
            }
            post.UpdatePost = DateTime.Now;
            post.PostTitle = updatePostAdmin.PostTitle;
            post.PostData = updatePostAdmin.PostData;
            post.PostStatusId = updatePostAdmin.PostStatusId;
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<AddLessonDTO>> updatePracticeLesson(int lessonId, dj_webdesigncore.Request.Lesson.PracticeLesson practiceLesson)
        {
            ResponData<AddLessonDTO> result = new ResponData<AddLessonDTO>();
            AddLessonDTO data = new AddLessonDTO();
            Lesson lesson = await _context.lesson.FindAsync(lessonId);
            if (lesson == null)
            {
                data.Mes = "Không tồn tại bài học có Id là " + lessonId;
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.NOTFOUND;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            try
            {
                lesson.UpdateDateTime = DateTime.Now;
                lesson.LessonDescription = practiceLesson.lessonDescription;
                lesson.LessonName = practiceLesson.lessonName;
                lesson.VideoTime = practiceLesson.lessonTime;
                dj_webdesigncore.Entities.CourseEntity.PracticeLesson practice = _context.practice_lesson.Where(x => x.LessonId == lesson.Id).FirstOrDefault();
                practice.BeginCodeMethod = practiceLesson.beginCode;
                practice.CallTestCode = practiceLesson.callTestCode;
                practice.ExpectOutput = practiceLesson.outputExemple;
                practice.IsSupportMultiLangue = practiceLesson.isSupportMutilLangue;
                practice.LangueDefaultId = practiceLesson.langueId;
                practice.Explain = practiceLesson.explainCode;
                practice.Input = practiceLesson.inputExemple;
                practice.Problem = practiceLesson.problem;
                practice.ProblemDetail = practiceLesson.problemDetail;
                practice.Suggest = practiceLesson.suggest;
                TestCase testCase = _context.test_case.Where(x => x.PracticeLessonId == practice.Id && x.SortNumber == 1).FirstOrDefault();
                testCase.ExpectOutput = practiceLesson.outputExemple;
                testCase.Input = practiceLesson.inputExemple;
                testCase.InputDetail = practiceLesson.caseDefaultDetail;
                await _context.SaveChangesAsync();
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                data.Mes = "Lỗi";
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.FAILED;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public Task<ResponData<AddLessonDTO>> updatePracticeLesson(int lessonId, dj_webdesigncore.Entities.CourseEntity.PracticeLesson practiceLesson)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponData<AddLessonDTO>> updateQuestionLesson(int lessonId, QuestionLessonRequest questionLessonRequest)
        {
            ResponData<AddLessonDTO> result = new ResponData<AddLessonDTO>();
            AddLessonDTO data = new AddLessonDTO();
            Lesson lesson = await _context.lesson.FindAsync(lessonId);
            if (lesson == null)
            {
                data.Mes = "Không tồn tại bài học có Id là " + lessonId;
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.NOTFOUND;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            try
            {
                lesson.UpdateDateTime = DateTime.Now;
                lesson.LessonDescription = questionLessonRequest.lessonDescription;
                lesson.LessonName = questionLessonRequest.lessonName;
                lesson.VideoTime = questionLessonRequest.lessonTime;
                QuestionLesson questionLesson = _context.question_lesson.Where(x => x.LessonId == lesson.Id).FirstOrDefault();
                questionLesson.Answer = questionLessonRequest.answer;
                questionLesson.AnswerA = questionLessonRequest.answerA;
                questionLesson.AnswerB = questionLessonRequest.answerB;
                questionLesson.AnswerC = questionLessonRequest.answerC;
                questionLesson.AnswerD = questionLessonRequest.answerD;
                questionLesson.Question = questionLessonRequest.question;
                await _context.SaveChangesAsync();
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                data.Mes = "Lỗi";
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.FAILED;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<AddLesson2ChapterDTO>> updateSortNumberLesson(UpdateSortNumberLessonRequest updateSortNumberLessonRequest)
        {
            ResponData<AddLesson2ChapterDTO> result = new ResponData<AddLesson2ChapterDTO>();
            AddLesson2ChapterDTO data = new AddLesson2ChapterDTO();
            try
            {
                ChapterLesson chapterLesson = await _context.chapter_lesson.FindAsync(updateSortNumberLessonRequest.Id);
                if (chapterLesson == null)
                {
                    data.Mes = "Không tồn tại bản ghi";
                    data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.NOTFOUND;
                    result.Data = data;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
                chapterLesson.SortNumber = updateSortNumberLessonRequest.SortNumber;
                await _context.SaveChangesAsync();
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                data.Mes = "Lỗi";
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.FAILED;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<AddTestCaseDTO>> updateTestCase(int testCaseId, TestCaseRequest testCaseRequest)
        {
            ResponData<AddTestCaseDTO> result = new ResponData<AddTestCaseDTO>();
            AddTestCaseDTO data = new AddTestCaseDTO();
            try
            {
                TestCase testCase = await _context.test_case.FindAsync(testCaseId);
                if (testCase == null)
                {
                    data.Mes = "Không tồn tại test case có Id là " + testCaseId;
                    data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.NOTFOUND;
                    result.Data = data;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
                //if (testCase.SortNumber != testCaseRequest.SortNumber)
                //{
                //    testCase.SortNumber = -1;
                //    await _context.SaveChangesAsync();
                //    var list = _context.test_case.Where(x => x.SortNumber >= testCaseRequest.SortNumber && x.PracticeLessonId == testCase.PracticeLessonId).OrderBy(x => x.SortNumber).ToList();
                //    int sortNumber = testCaseRequest.SortNumber + 1;
                //    foreach (var item in list)
                //    {
                //        item.SortNumber = sortNumber;
                //        sortNumber++;
                //    }
                //    testCase.SortNumber = testCaseRequest.SortNumber;
                //    await _context.SaveChangesAsync();
                //    var listResult = _context.test_case.Where(x => x.PracticeLessonId == testCase.PracticeLessonId).OrderBy(x => x.SortNumber).ToList();
                //    sortNumber = 1;
                //    foreach (var item in list)
                //    {
                //        item.SortNumber = sortNumber;
                //        sortNumber++;
                //    }
                //    await _context.SaveChangesAsync();
                //}
                testCase.SortNumber = testCaseRequest.SortNumber;
                testCase.Input = testCaseRequest.Input;
                testCase.ExpectOutput = testCaseRequest.Output;
                testCase.InputDetail = testCaseRequest.InputDetail;
                testCase.LockTestCase = testCaseRequest.IsLock;
                await _context.SaveChangesAsync();
                data.Mes = "Cập nhật thành công!";
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.SECCESSFULLY;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                data.Mes = "Lỗi";
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.FAILED;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }

        public async Task<ResponData<AddLessonDTO>> updateTheoryLesson(int lessonId, TheoryLessonRequest theoryLessonRequest)
        {
            ResponData<AddLessonDTO> result = new ResponData<AddLessonDTO>();
            AddLessonDTO data = new AddLessonDTO();
            Lesson lesson = await _context.lesson.FindAsync(lessonId);
            if (lesson == null)
            {
                data.Mes = "Không tồn tại bài học có Id là " + lessonId;
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.NOTFOUND;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            try
            {
                lesson.UpdateDateTime = DateTime.Now;
                lesson.LessonDescription = theoryLessonRequest.lessonDescription;
                lesson.LessonName = theoryLessonRequest.lessonName;
                lesson.VideoTime = theoryLessonRequest.lessonTime;
                VideoLesson videoLesson = _context.video_lesson.Where(x => x.LessonId == lesson.Id).FirstOrDefault();
                videoLesson.LessonLinkUrl = theoryLessonRequest.videoLink;
                await _context.SaveChangesAsync();
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                data.Mes = "Lỗi";
                data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.FAILED;
                result.Data = data;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }
        public async Task<IQueryable<User>> GetUserLockPage(int page)
        {
            var listPage = _context.user.Include(x => x.Role).Include(x => x.Gender).Include(x => x.Catalog).Include(x => x.UserStatus).Include(x => x.Province).Include(x => x.District).Include(x => x.Ward).Where(x => x.IsLock == true).OrderByDescending(x => x.CreateAccount).Skip((page - 1) * 15).Take(15);
            return listPage;
        }

        public async Task<ResponData<AnalyticAppDTO>> GetAnalytics()
        {
            ResponData<AnalyticAppDTO> result = new ResponData<AnalyticAppDTO>();
            AnalyticAppDTO data = new AnalyticAppDTO();
            List<AnalyticUserItemDTO> ListCategory = new List<AnalyticUserItemDTO>();
            AnalyticUserItemDTO cateNewUser = new AnalyticUserItemDTO();
            cateNewUser.Category = "Người dùng mới";
            int[] dataWeek = new int[7];
            int index = 0;
            var listNewUser = _context.user.Where(x => x.CreateAccount.Value.Year == DateTime.Now.Year && x.CreateAccount.Value.Month == DateTime.Now.Month && x.UserStatusId == 1).ToList();
            for (int i = DateTime.Now.Day; i > DateTime.Now.Day - 7; i--)
            {
                dataWeek[index] = listNewUser.Where(x => x.CreateAccount.Value.Day == i).Count();
                index++;
            }
            cateNewUser.DataWeek = dataWeek.Reverse().ToArray();
            int[] dataMonth = new int[12];
            var listNewUserMonth = _context.user.Where(x => x.CreateAccount.Value.Year == DateTime.Now.Year).ToList();
            for (int i = 0; i < 12; i++)
            {
                dataMonth[i] = listNewUserMonth.Where(x => x.CreateAccount.Value.Month == i + 1).Count();
            }
            cateNewUser.DataMonth = dataMonth;
            ListCategory.Add(cateNewUser);

            AnalyticUserItemDTO cateLockUser = new AnalyticUserItemDTO();
            cateLockUser.Category = "Người dùng bị khóa";
            dataWeek = new int[7];
            index = 0;
            var listLockUser = _context.user.Where(x => x.OpenLockTime != null && x.UserStatusId == 4).Where(x => x.OpenLockTime.Value.Year == DateTime.Now.Year && x.OpenLockTime.Value.Month == DateTime.Now.Month).ToList();
            for (int i = DateTime.Now.Day; i > DateTime.Now.Day - 7; i--)
            {
                dataWeek[index] = listLockUser.Where(x => x.OpenLockTime.Value.Day == i).Count();
                index++;
            }
            cateLockUser.DataWeek = dataWeek.Reverse().ToArray(); ;
            dataMonth = new int[12];
            var listLockUserMonth = _context.user.Where(x => x.OpenLockTime != null && x.UserStatusId == 4).Where(x => x.OpenLockTime.Value.Year == DateTime.Now.Year).ToList();
            for (int i = 0; i < 12; i++)
            {
                dataMonth[i] = listLockUserMonth.Where(x => x.OpenLockTime.Value.Month == i + 1).Count();
            }
            cateLockUser.DataMonth = dataMonth;
            ListCategory.Add(cateLockUser);

            AnalyticUserItemDTO cateLockForeverUser = new AnalyticUserItemDTO();
            cateLockForeverUser.Category = "Người dùng bị khóa vĩnh viễn";
            dataWeek = new int[7];
            index = 0;
            var listLockForeverUser = _context.user.Where(x => x.OpenLockTime != null && x.UserStatusId == 2).Where(x => x.OpenLockTime.Value.Year == DateTime.Now.Year && x.OpenLockTime.Value.Month == DateTime.Now.Month).ToList();
            for (int i = DateTime.Now.Day; i > DateTime.Now.Day - 7; i--)
            {
                dataWeek[index] = listLockForeverUser.Where(x => x.OpenLockTime.Value.Day == i).Count();
                index++;
            }
            cateLockForeverUser.DataWeek = dataWeek.Reverse().ToArray(); ;
            dataMonth = new int[12];
            var listLockForeverUserMonth = _context.user.Where(x => x.OpenLockTime != null && x.UserStatusId == 2).Where(x => x.OpenLockTime.Value.Year == DateTime.Now.Year).ToList();
            for (int i = 0; i < 12; i++)
            {
                dataMonth[i] = listLockForeverUserMonth.Where(x => x.OpenLockTime.Value.Month == i + 1).Count();
            }
            cateLockForeverUser.DataMonth = dataMonth;
            ListCategory.Add(cateLockForeverUser);

            data.ListOption = ListCategory;
            result.Data = data;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<UserAnalyticCustomDTO>> GetAnalyticsFilter(DateTime start, DateTime end)
        {
            ResponData<UserAnalyticCustomDTO> result = new ResponData<UserAnalyticCustomDTO>();
            UserAnalyticCustomDTO data = new UserAnalyticCustomDTO();
            List<string> date = new List<string>();
            List<int> newUser = new List<int>();
            List<int> lockUsernew = new List<int>();
            List<int> lockForeverUser = new List<int>();
            while (start <= end)
            {
                date.Add(start.Day + "/" + start.Month + "/" + start.Year);
                newUser.Add(_context.user.Where(x => x.CreateAccount.Value.Day == start.Day && x.CreateAccount.Value.Month == start.Month && x.CreateAccount.Value.Year == start.Year).ToList().Count);
                lockUsernew.Add(_context.user.Where(x => x.OpenLockTime != null && x.UserStatusId == 4).Where(x => x.OpenLockTime.Value.Year == start.Year && x.OpenLockTime.Value.Month == start.Month && x.OpenLockTime.Value.Day == start.Day).ToList().Count);
                lockForeverUser.Add(_context.user.Where(x => x.OpenLockTime != null && x.UserStatusId == 2).Where(x => x.OpenLockTime.Value.Year == start.Year && x.OpenLockTime.Value.Month == start.Month && x.OpenLockTime.Value.Day == start.Day).ToList().Count);
                start = start.AddDays(1);
            }
            data.date = date;
            data.newUser = newUser;
            data.lockUser = lockUsernew;
            data.lockForeverUser = lockForeverUser;
            result.Data = data;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<List<AdviceContactDTO>> GetAdviceContact(int page)
        {
            List<AdviceContactDTO> result = new List<AdviceContactDTO>();
            var list = _context.advice_contact.Where(x => x.IsContact == false).OrderByDescending(x => x.SendRequest).Skip((page - 1) * 15).Take(15).ToList();
            foreach (var item in list)
            {
                AdviceContactDTO ad = new AdviceContactDTO();
                ad.Note = item.Note;
                ad.Name = item.Name;
                ad.Id = item.Id;
                ad.SendRequest = item.SendRequest;
                ad.TypeAdvice = (dj_webdesigncore.Enums.Else.TypeAdviceEnum)item.TypeAdvice;
                result.Add(ad);
            }
            return result;
        }

        public async Task<AdviceContact> getAdviceDetail(int adviceId)
        {
            return await _context.advice_contact.FindAsync(adviceId);
        }

        public async Task<CourseAnaDTO> getCourseAna(int type = -1)
        {
            CourseAnaDTO result = new CourseAnaDTO();
            List<string> ListCourse = new List<string>();
            List<int> Total = new List<int>();
            List<int> Learning = new List<int>();
            List<int> Done = new List<int>();
            List<int> CourseId = new List<int>();
            var list = _context.course.Where(x => x.Id != 13).AsNoTracking();
            if (type != -1)
            {
                list = list.Where(x => x.CourseTypeId == type);
            }
            foreach (var item in list)
            {
                CourseId.Add(item.Id);
                ListCourse.Add(item.CourseCode);
                Total.Add(_context.user_course.Where(x => x.CourseId == item.Id).Count());
                Learning.Add(_context.user_course.Where(x => x.CourseId == item.Id && x.isDone == false).Count());
                Done.Add(_context.user_course.Where(x => x.CourseId == item.Id && x.isDone == true).Count());
            }
            result.ListCourse = ListCourse;
            result.CourseId = CourseId;
            result.Total = Total;
            result.Learning = Learning;
            result.Done = Done;
            return result;
        }

        public async Task<List<ListStudentOfCourse>> ListStudentOfCourse(int courseId, int page)
        {
            List<ListStudentOfCourse> result = new List<ListStudentOfCourse>();
            var userCourse = _context.user_course.Where(x => x.CourseId == courseId).OrderByDescending(x => x.ResisterDateTime).Skip((page - 1) * 15).Take(15).ToList();
            foreach (var item in userCourse)
            {
                ListStudentOfCourse data = new ListStudentOfCourse();
                data.StudentId = (int)item.UserId;
                User user = await _context.user.FindAsync(item.UserId);
                data.StudentName = user.UserFisrtName + " " + user.UserLastName;
                data.StudentAvatar = user.UserAvatarData40x40;
                data.IsKYC = (bool)user.IsKYC;
                Course course = await _context.course.FindAsync(courseId);
                if (item.isDone)
                {
                    data.ThisProcess = "Đã hoàn thành";
                    data.Evalute = course.LessonCount + "/" + course.LessonCount + " bài học hoàn thành!";
                }
                else
                {
                    Lesson l = await _context.lesson.FindAsync(item.LessonProcessId);
                    if (l != null)
                    {
                        data.ThisProcess = l.LessonName;
                        ChapterLesson cl = await _context.chapter_lesson.Where(x => x.LessonId == item.LessonProcessId).FirstOrDefaultAsync();
                        CourseChapter cc = await _context.course_chapter.FindAsync(cl.CourseChapterId);
                        if (cc.SortNumber == 1)
                        {
                            data.Evalute = cl.SortNumber + "/" + course.LessonCount + " bài học hoàn thành!";
                        }
                        else
                        {
                            var lstCourseChapter = _context.course_chapter.Where(x => x.CourseId == courseId && x.SortNumber < cc.SortNumber);
                            int total = 0;
                            foreach (var item1 in lstCourseChapter)
                            {
                                total += item1.ChapterLessonCount;
                            }
                            total += cl.SortNumber;
                            data.Evalute = total + "/" + course.LessonCount + " bài học hoàn thành!";
                        }
                    }
                    else
                    {
                        data.ThisProcess = "Dữ liệu chưa cập nhật!";
                        data.Evalute = "Dữ liệu chưa cập nhật!";
                    }
                }
                result.Add(data);
            }
            return result;
        }

        public async Task<UserCourseProgress> GetCourseProgressUser(int courseId, int userId)
        {
            UserCourseProgress result = new UserCourseProgress();
            Course c = await _context.course.FindAsync(courseId);
            User u = await _context.user.FindAsync(userId);
            result.UserId = userId;
            result.UserName = u.UserFisrtName + " " + u.UserLastName;
            result.CourseName = c.CourseName;
            List<ChapterProgressDTO> progressDTO = new List<ChapterProgressDTO>();
            var cc = _context.course_chapter.Where(x => x.CourseId == courseId).OrderBy(x => x.SortNumber);
            foreach (var item in cc)
            {
                ChapterProgressDTO cpd = new ChapterProgressDTO();
                List<LessonProgressDTO> lessonProgressDTOs = new List<LessonProgressDTO>();
                var cl = _context.chapter_lesson.Where(x => x.CourseChapterId == item.Id).OrderBy(x => x.SortNumber);
                foreach (var item1 in cl)
                {
                    Lesson lesson = await _context.lesson.FindAsync(item1.LessonId);
                    LessonProgressDTO lessonProgressDTO = new LessonProgressDTO();
                    lessonProgressDTO.LessonName = lesson.LessonName;
                    lessonProgressDTO.LessonId = lesson.Id;
                    LessonType lt = await _context.lesson_type.FindAsync(lesson.LessonTypeId);
                    lessonProgressDTO.LessonTypeId = (int)lesson.LessonTypeId;
                    lessonProgressDTO.LessonType = lt.LessonTypeName;
                    lessonProgressDTO.Time = lesson.VideoTime;
                    UserLessonCheckpoint ulc = await _context.user_lesson_checkpoint.Where(x => x.LessonId == lesson.Id && x.UserId == userId).FirstOrDefaultAsync();
                    if (ulc == null)
                    {
                        lessonProgressDTO.OpenTime = null;
                        lessonProgressDTO.IsDone = false;
                    }
                    else
                    {
                        lessonProgressDTO.OpenTime = ulc.OpenLessonDateTime.Day + "-" + ulc.OpenLessonDateTime.Month + "-" + ulc.OpenLessonDateTime.Year;
                        if (ulc.IsDone)
                        {
                            lessonProgressDTO.IsDone = true;
                        }
                        else
                        {
                            lessonProgressDTO.IsDone = false;
                        }
                    }
                    lessonProgressDTOs.Add(lessonProgressDTO);
                }
                cpd.Name = item.ChapterName;
                cpd.LessonProgressDTOs = lessonProgressDTOs;
                progressDTO.Add(cpd);
            }
            result.Progress = progressDTO;
            return result;
        }

        public async Task<ActionStatus> lockOrUnlockLesson(int userId, int lessonId)
        {
            Lesson l = await _context.lesson.FindAsync(lessonId);
            if (l == null)
            {
                return ActionStatus.NOTFOUND;
            }
            else
            {
                ChapterLesson cl = await _context.chapter_lesson.Where(x => x.LessonId == lessonId).FirstOrDefaultAsync();
                CourseChapter cc = await _context.course_chapter.Where(x => x.Id == cl.CourseChapterId).FirstOrDefaultAsync();
                if (cc.SortNumber == 1)
                {
                    return ActionStatus.WRONG;
                }
            }
            var lst = _context.user_lesson_checkpoint.Where(x => x.UserId == userId && x.LessonId == lessonId);
            if (lst.Count() > 0)
            {

                _context.RemoveRange(lst);
            }
            else
            {
                UserLessonCheckpoint ulc = new UserLessonCheckpoint();
                ulc.UserId = userId;
                ulc.LessonId = lessonId;
                ulc.OpenLessonDateTime = DateTime.Now;
                ulc.IsDone = true;
                await _context.AddAsync(ulc);
            }
            switch (l.LessonTypeId)
            {
                case 1:
                    VideoLesson vl = await _context.video_lesson.Where(x => x.LessonId == l.Id).FirstOrDefaultAsync();
                    VideoDoneData vdd = await _context.video_done_data.Where(x => x.UserId == userId && x.VideoLessonId == vl.Id).FirstOrDefaultAsync();
                    if (vdd == null)
                    {
                        vdd = new VideoDoneData();
                        vdd.VideoLessonId = vl.Id;
                        vdd.UserId = userId;
                        vdd.DoneTime = DateTime.Now;
                        await _context.AddAsync(vdd);
                        await _context.SaveChangesAsync();
                        return ActionStatus.SECCESSFULLY;
                    }
                    else
                    {
                        _context.Remove(vdd);
                        await _context.SaveChangesAsync();
                        return ActionStatus.SECCESSFULLY;
                    }
                case 2:
                    dj_webdesigncore.Entities.CourseEntity.PracticeLesson pl = await _context.practice_lesson.Where(x => x.LessonId == l.Id).FirstOrDefaultAsync();
                    PracticeDoneData pdd = await _context.practice_done_data.Where(x => x.UserId == userId && x.PracticeLessonId == pl.Id).FirstOrDefaultAsync();
                    if (pdd == null)
                    {
                        pdd = new PracticeDoneData();
                        pdd.PracticeLessonId = pl.Id;
                        pdd.UserId = userId;
                        pdd.LangueId = pl.LangueDefaultId;
                        pdd.DoneData = "Xác nhận mở khóa bởi Admin!";
                        pdd.DoneTime = DateTime.Now;
                        await _context.AddAsync(pdd);
                        await _context.SaveChangesAsync();
                        return ActionStatus.SECCESSFULLY;
                    }
                    else
                    {
                        _context.Remove(pdd);
                        await _context.SaveChangesAsync();
                        return ActionStatus.SECCESSFULLY;
                    }
                case 3:
                    QuestionLesson ql = await _context.question_lesson.Where(x => x.LessonId == l.Id).FirstOrDefaultAsync();
                    QuestionDoneData qdd = await _context.question_done_data.Where(x => x.UserId == userId && x.QuestionLessonId == ql.Id).FirstOrDefaultAsync();
                    if (qdd == null)
                    {
                        qdd = new QuestionDoneData();
                        qdd.QuestionLessonId = ql.Id;
                        qdd.UserId = userId;
                        qdd.Answer = 1;
                        qdd.DoneTime = DateTime.Now;
                        await _context.AddAsync(qdd);
                        await _context.SaveChangesAsync();
                        return ActionStatus.SECCESSFULLY;
                    }
                    else
                    {
                        _context.Remove(qdd);
                        await _context.SaveChangesAsync();
                        return ActionStatus.SECCESSFULLY;
                    }
            }
            return ActionStatus.SECCESSFULLY;
        }

        public async Task<VideoDoneData> GetVideoDoneDataOfUser(int userId, int videoLessonId)
        {
            return await _context.video_done_data.Include(x => x.VideoLesson).ThenInclude(x => x.Lesson).Where(x => x.UserId == userId && x.VideoLessonId == videoLessonId).FirstOrDefaultAsync();
        }

        public async Task<PracticeDoneData> GetPracDoneDataOfUser(int userId, int pracId)
        {
            return await _context.practice_done_data.Include(x => x.PracticeLesson).ThenInclude(x => x.Lesson).Include(x => x.PracticeLesson).ThenInclude(x => x.testCases).Where(x => x.UserId == userId && x.PracticeLessonId == pracId).FirstOrDefaultAsync();
        }

        public async Task<QuestionDoneData> GetQuesDoneDataOfUser(int userId, int quesId)
        {
            return await _context.question_done_data.Include(x => x.QuestionLesson).ThenInclude(x => x.Lesson).Where(x => x.UserId == userId && x.QuestionLessonId == quesId).FirstOrDefaultAsync();
        }

        public async Task<UserShowDTO> GetUserShow(int userId)
        {
            User u = await _context.user.FindAsync(userId);
            UserShowDTO result = new UserShowDTO();
            if (result.BirthDay != null)
            {
                result.BirthDay = u.Birthday.Value.Day + "-" + u.Birthday.Value.Month + "-" + u.Birthday.Value.Year;
            }
            result.Address = u.AddressNow;
            Gender g = await _context.gender.FindAsync(u.GenderId);
            result.Gender = g.GenderName;
            result.Detail = u.UserDetail;
            result.Email = u.UserEmail;
            result.ImagePath = u.UserAvatarData40x40;
            result.Id = u.Id;
            result.Name = u.UserFisrtName + " " + u.UserLastName;
            result.IsKYC = (bool)u.IsKYC;
            UserRole ur = await _context.user_role.FindAsync(u.UserRoleId);
            result.Role = ur.UserRoleName;
            return result;
        }

        public async Task<List<AdviceByItemDTO>> GetAdviceAna(int opt = 1)
        {
            List<AdviceByItemDTO> result = new List<AdviceByItemDTO>();
            var list = _context.advice_contact.AsNoTracking();
            if (opt == 1)
            {
                for (int i = DateTime.Now.Day; i > DateTime.Now.Day - 7; i--)
                {
                    AdviceByItemDTO abi = new AdviceByItemDTO();

                }
            }
            if (opt == 2)
            {
                list.Where(x => x.SendRequest < DateTime.Now.AddDays(-7)).AsNoTracking();
            }
            return result;
        }
        public async Task<List<ListStudentOfCourse>> GetCourseAnaType(int courseId, int page, int opt = 1)
        {
            List<ListStudentOfCourse> result = new List<ListStudentOfCourse>();
            var userCourse = _context.user_course.Where(x => x.CourseId == courseId).OrderByDescending(x => x.ResisterDateTime).AsNoTracking();
            if (opt == 1)
            {
                userCourse = userCourse.Skip((page - 1) * 15).Take(15);
            }
            if (opt == 2)
            {
                userCourse = userCourse.Where(x => x.isDone == false).Skip((page - 1) * 15).Take(15);
            }
            if (opt == 3)
            {
                userCourse = userCourse.Where(x => x.isDone == true).Skip((page - 1) * 15).Take(15);
            }
            foreach (var item in userCourse)
            {
                ListStudentOfCourse data = new ListStudentOfCourse();
                data.StudentId = (int)item.UserId;
                User user = await _context.user.FindAsync(item.UserId);
                data.StudentName = user.UserFisrtName + " " + user.UserLastName;
                data.StudentAvatar = user.UserAvatarData40x40;
                data.IsKYC = (bool)user.IsKYC;
                Course course = await _context.course.FindAsync(courseId);
                if (item.isDone)
                {
                    data.ThisProcess = "Đã hoàn thành";
                    data.Evalute = course.LessonCount + "/" + course.LessonCount + " bài học hoàn thành!";
                }
                else
                {
                    Lesson l = await _context.lesson.FindAsync(item.LessonProcessId);
                    if (l != null)
                    {
                        data.ThisProcess = l.LessonName;
                        ChapterLesson cl = await _context.chapter_lesson.Where(x => x.LessonId == item.LessonProcessId).FirstOrDefaultAsync();
                        CourseChapter cc = await _context.course_chapter.FindAsync(cl.CourseChapterId);
                        if (cc.SortNumber == 1)
                        {
                            data.Evalute = cl.SortNumber + "/" + course.LessonCount + " bài học hoàn thành!";
                        }
                        else
                        {
                            var lstCourseChapter = _context.course_chapter.Where(x => x.CourseId == courseId && x.SortNumber < cc.SortNumber);
                            int total = 0;
                            foreach (var item1 in lstCourseChapter)
                            {
                                total += item1.ChapterLessonCount;
                            }
                            total += cl.SortNumber;
                            data.Evalute = total + "/" + course.LessonCount + " bài học hoàn thành!";
                        }
                    }
                    else
                    {
                        data.ThisProcess = "Dữ liệu chưa cập nhật!";
                        data.Evalute = "Dữ liệu chưa cập nhật!";
                    }
                }
                result.Add(data);
            }
            return result;
        }
    }
}
