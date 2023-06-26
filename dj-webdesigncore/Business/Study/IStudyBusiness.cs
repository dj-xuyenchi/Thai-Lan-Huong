using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Admin;
using dj_webdesigncore.DTOs.Lobby;
using dj_webdesigncore.DTOs.Study;
using dj_webdesigncore.Entities.BusinessEntity;
using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Enums.ApiEnums;
using dj_webdesigncore.Request.Course;
using dj_webdesigncore.Request.Lesson;
using dj_webdesigncore.Request.SomeThingElse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Business.Study
{
    public interface IStudyBusiness
    {
        Task<ResponData<StudyDTO<VideoLessonDTO>>> VideoLessonContent(int? lessonId, int? userId, int? courseId);
        Task<ResponData<StudyDTO<QuestionLessonDTO>>> QuestionLessonContent(int? lessonId, int? userId, int? courseId);
        Task<ResponData<StudyDTO<PracticeLessonDTO>>> PracticeLessonContent(int? lessonId, int? userId, int? courseId);
        Task<ResponData<CommentDTO>> CommentOfLesson(int? lessonId, int? userId);
        Task<ChapterLessonStudy> LessonListOfUser(int? userId, int? courseId);
        Task<ResponData<TryTestCaseResultDTO>> TryTestCase(CodeRequest codeRequest);
        Task<ResponData<RegisterCourseDTO>> RegisterCourse(RegisterCourse registerCourse);
        Task<ResponData<ActionStatus>> CommentLesson(CommentLessonRequest commentLessonRequest);
        Task<ResponData<ActionStatus>> SubCommentLesson(SubCommentLessonRequest subCommentLessonRequest);
        Task<ResponData<ActionStatus>> LikeComment(LikeComment likeComment);
        Task<ResponData<ActionStatus>> SendPracticeOk(SendPracticeRequest sendPracticeRequest);
        Task<ResponData<ActionStatus>> SendQuestionAnswer(SendQuestionRequest sendQuestionRequest);
        Task<ResponData<ActionStatus>> SendVideoDoneRequest(SendVideoDoneRequest sendVideoDoneRequest);
        Task<ResponData<List<Langue>>> getAllLangue();
        Task<ResponData<List<TestCaseDTO>>> getTestCaseOfPractice(int practiceLessonId);
        Task<IQueryable<DenounceType>> getDenounce();
        Task<ResponData<ActionStatus>> CreateDenounce(DenounceRequest denounceRequest);
        Task<string> ProcessCourse(int courseId, int userId);
    }
}
