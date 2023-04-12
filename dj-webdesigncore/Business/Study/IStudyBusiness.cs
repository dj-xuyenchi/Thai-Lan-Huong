using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Lobby;
using dj_webdesigncore.DTOs.Study;
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
        Task<ResponData<StudyDTO<TheoryLessonDTO>>> TheoryLessonContent(int? lessonId, int? userId);
        Task<ResponData<StudyDTO<PracticeLessonDTO>>> PracticeLessonContent(int? lessonId,int? userId);
        Task<ResponData<CommentDTO>> CommentOfLesson(int? lessonId);
        Task<List<ChapterDetailDTO>> LessonListOfUser(int? userId,int? courseId);
    }
}
