using dj_actionlayer.Business.Compilerrrrrr;
using dj_actionlayer.Business.YoutubeAPIv3;
using dj_webdesigncore.Business.Lobby;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Lobby;
using dj_webdesigncore.DTOs.Study;
using dj_webdesigncore.Entities.BusinessEntity;
using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Entities.UserEntity;
using dj_webdesigncore.Enums.ApiEnums;
using dj_webdesigncore.Request.Course;
using dj_webdesigncore.Request.SomeThingElse;
using Google.Apis.SearchConsole.v1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_actionlayer.Business.Lobby
{
    public class LobbyBusiness : BaseBusiness, ILobbyBusiness
    {
        public async Task<ResponData<ActionStatus>> AdviceMentor(AdviceMentorRequest adviceMentorRequest)
        {
            ResponData<ActionStatus> result = new ResponData<ActionStatus>();
            AdviceContact adviceMentor = new AdviceContact();
            adviceMentor.Name = adviceMentorRequest.Name;
            adviceMentor.Sdt = adviceMentorRequest.Sdt;
            adviceMentor.IsContact = false;
            adviceMentor.Note = adviceMentorRequest.Note;
            adviceMentor.TypeAdvice = (dj_webdesigncore.Enums.Else.TypeAdviceEnum?)adviceMentorRequest.Opt;
            adviceMentor.SendRequest = DateTime.Now;
            adviceMentor.Status = dj_webdesigncore.Enums.Else.AdviceStatusEnum.CHUABIET;
            await _context.AddAsync(adviceMentor);
            await _context.SaveChangesAsync();
            result.Data = ActionStatus.SECCESSFULLY;
            result.Messenger = "Lấy dữ liệu thành công!";
            result.Status = ActionStatus.SECCESSFULLY;
            return result;
        }

        public async Task<ResponData<CourseDetailDTO>> CourseDetailContent(int? courseId, int? userId)
        {
            ResponData<CourseDetailDTO> result = new ResponData<CourseDetailDTO>();
            if (courseId == null)
            {
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.PARAMNULL;
                result.Messenger = "Lấy dữ liệu thất bại không nhận được courseId!";
                return result;
            }
            try
            {
                CourseDetailDTO courseDetail = new CourseDetailDTO();
                Course course = await _context.course.FindAsync(courseId);
                if (course == null)
                {
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.NOTFOUND;
                    result.Messenger = "Lấy dữ liệu thất bại không tồn tại khóa học!";
                    return result;
                }
                courseDetail.CourseTitle = course.CourseName;
                courseDetail.CourseSubTitle = course.CourseSubTitle;
                courseDetail.LessonCount = course.LessonCount;
                courseDetail.ChapterCount = course.ChapterCount;
                courseDetail.TimeTotal = course.TimeLessonTotal;
                courseDetail.IntroVideoPath = course.IntroVideoLink;
                List<CourseCourseProfit> courseCourseProfit = _context.course_course_profit.Where(x => x.CourseId == courseId).OrderBy(x => x.SortNumber).ToList();
                List<CourseProfit> courseProfitResult = new List<CourseProfit>();
                foreach (var item in courseCourseProfit)
                {
                    CourseProfit courseProfit = _context.course_profit.Find(item.CourseProfitId);
                    courseProfitResult.Add(courseProfit);
                }
                List<CourseCourseRequire> courseCourseRequire = _context.course_course_require.Where(x => x.CourseId == courseId).OrderBy(x => x.SortNumber).ToList();
                List<CourseRequire> courseRequireResult = new List<CourseRequire>();
                foreach (var item in courseCourseRequire)
                {
                    CourseRequire courseRequire = _context.course_require.Find(item.CourseRequireId);
                    courseRequireResult.Add(courseRequire);
                }
                List<ChapterDetailDTO> chapterDetailResult = new List<ChapterDetailDTO>();
                List<CourseChapter> chapterOfCourse = _context.course_chapter.Where(x => x.CourseId == courseId).OrderBy(x => x.SortNumber).ToList();
                User user = null;
                if (userId != null || userId != -1)
                {
                    user = _context.user.Find(userId);
                }
                UserCourse userCourse = null;
                if (user != null)
                {
                    userCourse = _context.user_course.Where(x => x.UserId == user.Id && x.CourseId == courseId).FirstOrDefault();
                }
                if (userCourse != null)
                {
                    courseDetail.isRegistered = true;
                    courseDetail.courseId = (int)courseId;
                    UserLessonCheckpoint userLessonCheckpoint = _context.user_lesson_checkpoint.Where(x => x.UserId == userId).OrderBy(x => x.OpenLessonDateTime).FirstOrDefault();
                    courseDetail.lessonId = userLessonCheckpoint.LessonId;
                }
                else
                {
                    courseDetail.isRegistered = false;
                }
                foreach (var item in chapterOfCourse)
                {
                    ChapterDetailDTO chapterDetailDTO = new ChapterDetailDTO();
                    chapterDetailDTO.ChapterId = item.Id;
                    chapterDetailDTO.ChapterTitle = item.ChapterName;
                    chapterDetailDTO.LessonCount = item.ChapterLessonCount;
                    List<LessonDetailDTO> lessonDetailDTOResult = new List<LessonDetailDTO>();
                    List<ChapterLesson> lessonOfChapter = _context.chapter_lesson.Where(x => x.CourseChapterId == item.Id).OrderBy(x => x.SortNumber).ToList();
                    foreach (var item1 in lessonOfChapter)
                    {
                        LessonDetailDTO lessonDetailDTO = new LessonDetailDTO();
                        if (userId != null || userId != -1)
                        {
                            if (user == null)
                            {
                                lessonDetailDTO.IsDone = false;
                            }
                            else
                            {
                                UserLessonCheckpoint checkPoint = _context.user_lesson_checkpoint.Where(x => x.UserId == userId && x.LessonId == item1.LessonId).FirstOrDefault();
                                if (checkPoint != null)
                                {
                                    lessonDetailDTO.IsDone = true;
                                }
                                else
                                {
                                    lessonDetailDTO.IsDone = false;
                                }
                            }
                        }
                        else
                        {
                            lessonDetailDTO.IsDone = false;
                        }
                        Lesson lesson = _context.lesson.Find(item1.LessonId);
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
                courseDetail.ChapterDetail = chapterDetailResult;
                courseDetail.CourseRequire = courseRequireResult;
                courseDetail.CourseProfit = courseProfitResult;
                result.Data = courseDetail;
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

        public async Task<ResponData<List<CourseListDTO>>> CourseListContent()
        {
            ResponData<List<CourseListDTO>> result = new ResponData<List<CourseListDTO>>();
            try
            {
                List<CourseListDTO> courseListDTOs = new List<CourseListDTO>();
                var listCourseType = _context.course_type.ToList();
                foreach (var courseType in listCourseType)
                {
                    CourseListDTO courseListDTO = new CourseListDTO();
                    List<CourseDTO> courseDTOs = new List<CourseDTO>();

                    var courseListOfType = _context.course.Where(x => x.CourseTypeId == courseType.Id && (x.CourseStatusId == 1 || x.CourseStatusId == 3)).ToList();
                    if (courseListOfType.Count == 0)
                    {
                        continue;
                    }
                    courseListDTO.CourseType = courseType.CourseTypeName;
                    if (courseListOfType.Count == 0)
                    {
                        courseListDTO.IsEmpty = true;
                        continue;
                    }
                    foreach (var course in courseListOfType)
                    {
                        CourseDTO courseDTO = new CourseDTO();
                        if (course.CourseStatusId == 1)
                        {
                            courseDTO.IsActive = true;
                        }
                        else
                        {
                            courseDTO.IsActive = false;
                        }
                        courseDTO.CourseId = course.Id;
                        courseDTO.CourseImageData = course.CourseImageData;
                        courseDTO.CourseName = course.CourseName;
                        courseDTO.StudentCount = _context.user_course.Where(x => x.CourseId == course.Id).ToList().Count;
                        courseDTOs.Add(courseDTO);
                    }
                    courseListDTO.CourseListByType = courseDTOs;
                    courseListDTOs.Add(courseListDTO);
                }
                result.Data = courseListDTOs;
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

        public async Task<ResponData<LobbyDTO>> LobbyContent()
        {
            ResponData<LobbyDTO> result = new ResponData<LobbyDTO>();

            LobbyDTO lobbyDTO = new LobbyDTO();
            ListActiveCourse listActiveCourse = new ListActiveCourse();
            HomeContent home = _context.home_content.ToList()[0];
            List<string> lstSlide = new List<string>();
            lstSlide.Add(home.Slide1);
            lstSlide.Add(home.Slide2);
            lstSlide.Add(home.Slide3);
            lstSlide.Add(home.Slide4);
            lstSlide.Add(home.Slide5);
            lobbyDTO.Slide = lstSlide;
            listActiveCourse.StudyedStudent = _context.user_course.ToList().Count;
            listActiveCourse.StudyingStudent = _context.user_course.Where(x => x.isDone == false).ToList().Count;
            List<CourseDTO> courseDTOs = new List<CourseDTO>();
            var courseActiveList = _context.course.Where(x => x.CourseStatusId == 1 || x.CourseStatusId == 3).ToList();
            foreach (var course in courseActiveList)
            {
                CourseDTO courseDTO = new CourseDTO();
                if (course.CourseStatusId == 1)
                {
                    courseDTO.IsActive = true;
                }
                else
                {
                    courseDTO.IsActive = false;
                }
                courseDTO.CourseId = course.Id;
                courseDTO.CourseImageData = course.CourseImageData;
                courseDTO.CourseName = course.CourseName;
                courseDTO.StudentCount = _context.user_course.Where(x => x.CourseId == course.Id).ToList().Count;
                courseDTOs.Add(courseDTO);
            }
            listActiveCourse.courseDTOs = courseDTOs;
            lobbyDTO.ListActiveCourse = listActiveCourse;
            // post
            List<PostDTO> listPost = new List<PostDTO>();
            var getPost = _context.post.Where(x => x.PostStatusId == 1).OrderByDescending(x => x.LikeCount).Take(10).ToList();
            foreach (var post in getPost)
            {
                PostDTO postDTO = new PostDTO();
                postDTO.Id = post.Id;
                User user = await _context.user.FindAsync(post.UserCreateId);
                postDTO.CreaterFullName = user.UserFisrtName + " " + user.UserLastName;
                postDTO.CreaterAvatar = user.UserAvatarData40x40;
                postDTO.PostTitle = post.PostTitle;
                postDTO.CmtCount = post.CommentCount;
                postDTO.LikeCount = post.LikeCount;
                postDTO.PostImg = post.PostAvatar;
                postDTO.IsCreaterKYC = (bool)user.IsKYC;
                listPost.Add(postDTO);
            }
            lobbyDTO.ListPost = listPost;
            //if (DateTime.Now.Minute % 3 == 0)
            //{
            //    await updateFullBlog();
            //}
            var listBlog = _context.blog.Where(x => x.StatusId == 1).OrderByDescending(x => x.CreateTime).Take(10).ToList();
            List<BlogDTO> blogList = new List<BlogDTO>();
            foreach (var blog in listBlog)
            {
                BlogDTO blogDTO = new BlogDTO();
                blogDTO.StatusId = blog.StatusId;
                blogDTO.CmtCount = blog.CmtCount;
                blogDTO.ViewCount = blog.ViewCount;
                blogDTO.BlogImg = blog.BlogImg;
                blogDTO.Title = blog.BlogTitle;
                blogDTO.BlogLink = blog.BlogLink;
                blogList.Add(blogDTO);
            }
            lobbyDTO.Blog = blogList;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Data = lobbyDTO;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<ResponData<TakeCertificateDTO>> TakeCertificate(int courseId, int userId)
        {
            ResponData<TakeCertificateDTO> result = new ResponData<TakeCertificateDTO>();
            UserCourse uc = await _context.user_course.Where(x => x.UserId == userId && x.CourseId == courseId).FirstOrDefaultAsync();
            if (uc.isDone == false)
            {
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Data = null;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            Course course = await _context.course.FindAsync(uc.CourseId);
            User user = await _context.user.FindAsync(uc.UserId);
            TakeCertificateDTO data = new TakeCertificateDTO();
            data.Day = uc.DoneTime.Value.Day.ToString();
            data.Month = uc.DoneTime.Value.Month.ToString();
            data.Year = uc.DoneTime.Value.Year.ToString();
            data.CourseName = course.CourseName;
            data.Name = user.UserFisrtName + " " + user.UserLastName;
            result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
            result.Data = data;
            result.Messenger = "Lấy dữ liệu thành công!";
            return result;
        }

        public async Task<TryCodeHome> TryCodeHome(string source)
        {
            if (source == null || source.Length == 0)
            {
                return null;
            }
            TryCodeHome result = new TryCodeHome();
            if (source.Contains("Directory") || source.Contains("File") || source.Contains("FileInfo"))
            {
                result.Error = 2;
                result.Result = "Security Protect!";
                return result;
            }
            var runCodeResult = await CompileUserCode.RunCSharpCode(source);
            if (!runCodeResult.success)
            {
                result.Error = 2;
                result.Result = runCodeResult.exeption;
            }
            if (runCodeResult.success)
            {
                result.Error = 1;
                result.Result = runCodeResult.result;
            }
            return result;
        }

        private async Task updateFullBlog()
        {
            var list = _context.blog.ToList();
            foreach (var blog in list)
            {
                VideoInfo v = await YoutubeAPI.GetInfo(blog.BlogLink);
                blog.ViewCount = v.view;
                blog.CmtCount = v.cmt;
            }
            await _context.SaveChangesAsync();
        }
    }
}
