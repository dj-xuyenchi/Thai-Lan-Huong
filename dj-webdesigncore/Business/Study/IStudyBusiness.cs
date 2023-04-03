using dj_webdesigncore.DTOs;
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
        ResponData<StudyDTO<VideoLessonDTO>> VideoLessonContent(int? lessonId, int? userId);

        ResponData<StudyDTO<TheoryLessonDTO>> TheoryLessonContent(int? lessonId, int? userId);

        ResponData<StudyDTO<PracticeLessonDTO>> PracticeLessonContent(int? lessonId,int? userId);
    }
}
