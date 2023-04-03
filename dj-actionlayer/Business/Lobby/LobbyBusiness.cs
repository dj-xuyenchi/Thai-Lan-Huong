﻿using dj_webdesigncore.Business.Lobby;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Lobby;
using dj_webdesigncore.Entities.BusinessEntity;
using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_actionlayer.Business.Lobby
{
    public class LobbyBusiness : BaseBusiness, ILobbyBusiness
    {
        public ResponData<CourseDetailDTO> CourseDetailContent(int? courseId, int? userId)
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
                Course course = _context.course.Find(courseId);
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
                        if (userId != null)
                        {
                            User user = _context.user.Find(userId);
                            if (user == null)
                            {
                                lessonDetailDTO.IsDone = false;
                            }
                            else
                            {
                                UserLessonCheckpoint checkPoint = _context.user_lesson_checkpoint.Where(x => x.UserId == userId && x.LessonId == item1.LessonId).SingleOrDefault();
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
                        lessonDetailDTO.LessonVideoPath = lesson.YoutubeUrl;
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

        public ResponData<LobbyDTO> LobbyContent()
        {
            ResponData<LobbyDTO> result = new ResponData<LobbyDTO>();
            try
            {
                LobbyDTO lobbyDTO = new LobbyDTO();
                ListActiveCourse listActiveCourse = new ListActiveCourse();
                listActiveCourse.StudyedStudent = _context.user_course.ToList().Count;
                listActiveCourse.StudyingStudent = _context.user_course.Where(x => x.isDone == false).ToList().Count;
                List<CourseDTO> courseDTOs = new List<CourseDTO>();
                var courseActiveList = _context.course.Where(x => x.CourseStatusId == 1).ToList();
                foreach (var course in courseActiveList)
                {
                    CourseDTO courseDTO = new CourseDTO();
                    courseDTO.CourseId = course.Id;
                    courseDTO.CourseImageData = course.CourseImageData;
                    courseDTO.CourseName = course.CourseName;
                    courseDTO.StudentCount = _context.user_course.Where(x => x.CourseId == course.Id).ToList().Count;
                    courseDTOs.Add(courseDTO);
                }
                listActiveCourse.courseDTOs = courseDTOs;
                lobbyDTO.ListActiveCourse = listActiveCourse;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Data = lobbyDTO;
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
    }
}