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

        public async Task<ResponData<List<LessonDetailDTO>>> getAllLesson()
        {
            ResponData<List<LessonDetailDTO>> result = new ResponData<List<LessonDetailDTO>>();
            try
            {
                List<LessonDetailDTO> lessonDetailDTO = new List<LessonDetailDTO>();
                var listLesson = _context.lesson.ToList();
                foreach (var item in listLesson)
                {
                    LessonDetailDTO lessonDetail = new LessonDetailDTO();
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
                result.Data = lessonDetailDTO;
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
