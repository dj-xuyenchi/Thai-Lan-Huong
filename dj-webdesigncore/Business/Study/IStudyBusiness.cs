using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Lobby;
using dj_webdesigncore.DTOs.Study;
using dj_webdesigncore.Enums.ApiEnums;
using dj_webdesigncore.Request.Course;
using dj_webdesigncore.Request.Lesson;
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
        Task<ResponData<CommentDTO>> CommentOfLesson(int? lessonId,int? userId);
        Task<List<ChapterDetailDTO>> LessonListOfUser(int? userId, int? courseId);
        Task<ResponData<TryTestCaseResultDTO>> TryTestCase(CodeRequest codeRequest);
        Task<ResponData<RegisterCourseDTO>> RegisterCourse(RegisterCourse registerCourse);
        Task<ResponData<ActionStatus>> CommentLesson(CommentLessonRequest commentLessonRequest);
        Task<ResponData<ActionStatus>> SubCommentLesson(SubCommentLessonRequest subCommentLessonRequest);
        Task<ResponData<ActionStatus>> LikeComment(LikeComment likeComment);
        Task<ResponData<ActionStatus>> SendPracticeOk(SendPracticeRequest sendPracticeRequest);
        Task<ResponData<ActionStatus>> SendQuestionAnswer(int questionId,int userAnswer,int userId);
    }
}
