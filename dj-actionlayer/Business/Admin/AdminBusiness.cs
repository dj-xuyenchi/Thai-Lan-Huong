using dj_webdesigncore.Business.Admin;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Admin;
using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Request.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_actionlayer.Business.Admin
{
    public class AdminBusiness : BaseBusiness, IAdminBusiness
    {
        public async Task<ResponData<AddLessonDTO>> addPracticeLesson(dj_webdesigncore.Request.Lesson.PracticeLesson practiceLesson)
        {
            ResponData<AddLessonDTO> result = new ResponData<AddLessonDTO>();
            AddLessonDTO data = new AddLessonDTO();
            foreach (var i in practiceLesson.GetType().GetProperties())
            {
                if (i.GetValue(practiceLesson, null) == null){
                    data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.NULLPROPS;
                    data.Mes = "Thuộc tính "+i.Name+" không có giá trị!";
                    result.Data = data;
                    result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                    result.Messenger = "Lấy dữ liệu thành công!";
                    return result;
                }
            }
            Lesson lesson = new Lesson();
            lesson.LessonStatusId = 1;
            lesson.LessonName = practiceLesson.lessonName;
            lesson.LessonDescription = practiceLesson.lessonDescription;
            lesson.VideoTime = practiceLesson.lessonTime;
            lesson.CreateDateTime=DateTime.Now;
            lesson.LessonTypeId = 2;
            await _context.AddAsync(lesson);
            await _context.SaveChangesAsync();
            dj_webdesigncore.Entities.CourseEntity.PracticeLesson practiceNew = new dj_webdesigncore.Entities.CourseEntity.PracticeLesson();
            practiceNew.LessonId = lesson.Id;
            practiceNew.BeginCodeMethod = practiceLesson.beginCode;
            practiceNew.Problem= practiceLesson.problem;
            practiceNew.ProblemDetail= practiceLesson.problemDetail;
            practiceNew.CallTestCode = practiceLesson.callTestCode;
            practiceNew.ExpectOutput= practiceLesson.outputExemple;
            practiceNew.Input= practiceLesson.inputExemple;
            practiceNew.Suggest = practiceLesson.suggest;
            practiceNew.Explain= practiceLesson.explainCode;
            await _context.AddAsync(practiceNew);
            await _context.SaveChangesAsync();
            data.Status = dj_webdesigncore.Enums.CourseEnums.AddStatusEnum.SECCESSFULLY;
            data.Mes = "Thêm bài học thành công!";
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
                    chapterDetailDTO.LessonCount = _context.chapter_lesson.Where(x => x.CourseChapterId == item.Id).Count()+" bài học";
                    chapterDetail.Add(chapterDetailDTO);
                }
                data.list = chapterDetail;
                int size = _context.lesson.Count();
                data.maxPage = _context.lesson.Count() / 10;
                if (size % 10 != 0&&size>10)
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
                    courseDetailDTO.ChapterCount = item.ChapterCount + " học phần";
                    courseDetailDTO.CourseCode = item.CourseCode;
                    courseDetailDTO.CourseName = item.CourseName;
                    courseDetailDTO.CourseLevel = _context.course_level.Find(item.CourseLevelId).LevelName;
                    courseDetailDTO.CourseStatus = _context.course_status.Find(item.CourseStatusId).CourseStatusName;
                    courseDetailDTO.CourseImageData = item.CourseImageData;
                    courseDetailDTO.CourseSubTitle = item.CourseSubTitle;
                    courseDetailDTO.CourseType = _context.course_type.Find(item.CourseTypeId).CourseTypeName;
                    courseDetailDTO.CourseTypeId=item.CourseTypeId;
                    courseDetailDTO.TimeLessonTotal = item.TimeLessonTotal;
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

        public async Task<ResponData<GetLessonDTO>> getLessonPage(int page)
        {
            ResponData<GetLessonDTO> result = new ResponData<GetLessonDTO>();
            GetLessonDTO data = new GetLessonDTO();
            try
            {
                List<LessonDetailDTO> lessonDetailDTO = new List<LessonDetailDTO>();
                var listLesson = _context.lesson.OrderByDescending(x=>x.CreateDateTime).Skip((page-1)*10).Take(10).ToList();
                foreach (var item in listLesson)
                {
                    LessonDetailDTO lessonDetail = new LessonDetailDTO();
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
    }
}
