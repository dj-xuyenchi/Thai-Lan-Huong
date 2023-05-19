using dj_actionlayer.Business.Admin;
using dj_webdesigncore.Business.Admin;
using dj_webdesigncore.Entities.UserEntity;
using dj_webdesigncore.Request.Account;
using dj_webdesigncore.Request.Chapter;
using dj_webdesigncore.Request.Course;
using dj_webdesigncore.Request.Lesson;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dj_endpoint.Controllers.Admin
{
    [Authorize(Policy = "ADMIN")]
    [Route("/admin")]
    public class AdminApis : BaseApi
    {
        private readonly IAdminBusiness _admin; 

        public AdminApis()
        {
            _admin = new AdminBusiness();
        }

        [HttpGet("getlessonpage")]
        public async Task<IActionResult> getLessonPage(int page)
        {
            return Ok(await _admin.getLessonPage(page));
        }
        [HttpGet("getchapterpage")]
        public async Task<IActionResult> getChapterPage(int page)
        {
            return Ok(await _admin.getChapterPage(page));
        }
        [HttpGet("getcoursepage")]
        public async Task<IActionResult> getCoursePage(int page)
        {
            return Ok(await _admin.getCoursePage(page));
        }
        [HttpGet("checkadmin")]
        public async Task<IActionResult> checkAdmin()
        {
            return Ok("Admin");
        }
        [HttpPost("addpracticelesson")]
        public async Task<IActionResult> addPracticeLesson(PracticeLesson practiceLesson)
        {
            return Ok(await _admin.addPracticeLesson(practiceLesson));
        }
        [HttpPost("addtheorylesson")]
        public async Task<IActionResult> addTheoryLesson(TheoryLessonRequest theoryLessonRequest)
        {
            return Ok(await _admin.addTheoryLesson(theoryLessonRequest));
        }
        [HttpPost("addquestionlesson")]
        public async Task<IActionResult> addQuestionLesson(QuestionLessonRequest questionLessonRequest)
        {
            return Ok(await _admin.addQuestionLesson(questionLessonRequest));
        }
        [HttpPost("updatepracticelesson")]
        public async Task<IActionResult> updatePracticeLesson(int lessonId,PracticeLesson practiceLesson)
        {
            return Ok(await _admin.updatePracticeLesson(lessonId,practiceLesson));
        }
        [HttpPost("updatequestionlesson")]
        public async Task<IActionResult> updateQuestionLesson(int lessonId, QuestionLessonRequest questionLessonRequest)
        {
            return Ok(await _admin.updateQuestionLesson(lessonId, questionLessonRequest));
        }
        [HttpPost("updatetheorylesson")]
        public async Task<IActionResult> updateTheoryLesson(int lessonId, TheoryLessonRequest theoryLessonRequest)
        {
            return Ok(await _admin.updateTheoryLesson(lessonId, theoryLessonRequest));
        }
        [HttpGet("selectcourseforchapter")]
        public async Task<IActionResult> getCourseForChapter()
        {
            return Ok(await _admin.selectCourseForChapter());
        }
        [HttpPost("addchapter")]
        public async Task<IActionResult> addChapter(AddChapterRequest addChapterRequest)
        {
            return Ok(await _admin.addChapter(addChapterRequest));
        }
        [HttpPost("updatechapter")]
        public async Task<IActionResult> updateChapter(UpdateChapterRequest updateChapterRequest)
        {
            return Ok(await _admin.updateChapter(updateChapterRequest));
        }
        [HttpGet("gettestcase")]
        public async Task<IActionResult> getAllTestCase(int practiceId)
        {
            return Ok(await _admin.getAllTestCase(practiceId));
        }
        [HttpPost("addtestcase")]
        public async Task<IActionResult> addTestCase(TestCaseRequest testCaseRequest)
        {
            return Ok(await _admin.addTestCase(testCaseRequest));
        }
        [HttpPost("updatetestcase")]
        public async Task<IActionResult> updateTestCase(int testCaseId,TestCaseRequest testCaseRequest)
        {
            return Ok(await _admin.updateTestCase(testCaseId,testCaseRequest));
        }
        [HttpGet("deletetestcase")]
        public async Task<IActionResult> deleteTestCase(int testCaseId)
        {
            return Ok(await _admin.deleteTestCase(testCaseId));
        }
        [HttpGet("getlessonofchapter")]
        public async Task<IActionResult> getLessonOfChapter(int chapterId)
        {
            return Ok(await _admin.getLessonOfChapter(chapterId));
        }
        [HttpPost("updatesortnumberlesson")]
        public async Task<IActionResult> updateSortNumberLesson(UpdateSortNumberLessonRequest updateSortNumberLessonRequest)
        {
            return Ok(await _admin.updateSortNumberLesson(updateSortNumberLessonRequest));
        }
        [HttpPost("addlesson2chapter")]
        public async Task<IActionResult> addLesson2Chapter(UpdateSortNumberLessonRequest updateSortNumberLessonRequest)
        {
            return Ok(await _admin.addLesson2Chapter(updateSortNumberLessonRequest));
        }
        [HttpGet("deletelessonofchapter")]
        public async Task<IActionResult> deleteLessonOfChapter(int lessonChapterId)
        {
            return Ok(await _admin.deleteLessonOfChapter(lessonChapterId));
        }
        [HttpGet("getlessonnotinchapter")]
        public async Task<IActionResult> getLessonNotInChapter()
        {
            return Ok(await _admin.getLessonNotInChapter());
        }
        [HttpGet("getoptionaddcourse")]
        public async Task<IActionResult> getOptionAddCourse()
        {
            return Ok(await _admin.getOptionAddCourse());
        }
        [HttpPost("addcourse")]
        public async Task<IActionResult> addCourse([FromForm] IFormFile img, [FromForm] string data)
        {
           AddCourseRequest addCourseRequest = JsonConvert.DeserializeObject<AddCourseRequest>(data);
            return Ok(await _admin.addCourse(img, addCourseRequest));
        }
        [HttpPost("updatecourse")]
        public async Task<IActionResult> updateCourse([FromForm] IFormFile? img, [FromForm] string data)
        {
            AddCourseRequest addCourseRequest = JsonConvert.DeserializeObject<AddCourseRequest>(data);
            return Ok(await _admin.updateCourse(img, addCourseRequest));
        }
        [HttpGet("getchapterofcourse")]
        public async Task<IActionResult> getChapterOfCourse(int courseId)
        {
            return Ok(await _admin.getChapterOfCourse(courseId));
        }
    }
}
