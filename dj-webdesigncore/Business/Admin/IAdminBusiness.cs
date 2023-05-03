using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Admin;
using dj_webdesigncore.Request.Chapter;
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
        Task<ResponData<GetCourseDTO>> getCoursePage(int page);
        Task<ResponData<AddLessonDTO>> addPracticeLesson(PracticeLesson practiceLesson);
        Task<ResponData<AddLessonDTO>> updatePracticeLesson(int lessonId,PracticeLesson practiceLesson);
        Task<ResponData<AddLessonDTO>> addTheoryLesson(TheoryLessonRequest theoryLessonRequest);
        Task<ResponData<AddLessonDTO>> updateTheoryLesson(int lessonId, TheoryLessonRequest theoryLessonRequest);
        Task<ResponData<AddLessonDTO>> addQuestionLesson(QuestionLessonRequest questionLessonRequest);
        Task<ResponData<AddLessonDTO>> updateQuestionLesson(int lessonId, QuestionLessonRequest questionLessonRequest);
        Task<ResponData<List<SelectCourseForChapter>>> selectCourseForChapter();
        Task<ResponData<AddChapterDTO>> addChapter(AddChapterRequest addChapterRequest);
        Task<ResponData<AddChapterDTO>> updateChapter(UpdateChapterRequest updateChapterRequest);
        Task<ResponData<List<TestCaseDTO>>> getAllTestCase(int practiceId);
        Task<ResponData<AddTestCaseDTO>> addTestCase(TestCaseRequest testCaseRequest);
        Task<ResponData<AddTestCaseDTO>> updateTestCase(int testCaseId,TestCaseRequest testCaseRequest);
        Task<ResponData<AddTestCaseDTO>> deleteTestCase(int testCaseId);
        Task<ResponData<List<LessonDetailDTO>>> getLessonOfChapter(int chapterId);
        Task<ResponData<AddLesson2ChapterDTO>> updateSortNumberLesson(UpdateSortNumberLessonRequest updateSortNumberLessonRequest);
        Task<ResponData<AddLesson2ChapterDTO>> addLesson2Chapter(UpdateSortNumberLessonRequest updateSortNumberLessonRequest);
        Task<ResponData<AddLesson2ChapterDTO>> deleteLessonOfChapter(int lessonChapterId);
        Task<ResponData<List<LessonDetailDTO>>> getLessonNotInChapter();
    }
}
