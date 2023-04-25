using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Admin;
using dj_webdesigncore.Request.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Business.Admin
{
    public interface IAdminBusiness
    {
        Task<ResponData<GetLessonDTO>> getLessonPage(int page);
        Task<ResponData<GetChapterDTO>> getChapterPage(int page);
        Task<ResponData<AddLessonDTO>> addPracticeLesson(PracticeLesson practiceLesson);
    }
}
