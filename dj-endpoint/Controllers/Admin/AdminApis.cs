using dj_actionlayer.Business.Admin;
using dj_webdesigncore.Business.Admin;
using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Entities.UserEntity;
using dj_webdesigncore.Request.Account;
using dj_webdesigncore.Request.Blog;
using dj_webdesigncore.Request.Chapter;
using dj_webdesigncore.Request.Course;
using dj_webdesigncore.Request.Lesson;
using dj_webdesigncore.Request.Post;
using dj_webdesigncore.Request.SomeThingElse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace dj_endpoint.Controllers.Admin
{
    [Authorize(Policy = "ADMINMAINTAIN")]
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
        public async Task<IActionResult> addPracticeLesson(dj_webdesigncore.Request.Lesson.PracticeLesson practiceLesson)
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
        public async Task<IActionResult> updatePracticeLesson(int lessonId, dj_webdesigncore.Request.Lesson.PracticeLesson practiceLesson)
        {
            return Ok(await _admin.updatePracticeLesson(lessonId, practiceLesson));
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
        public async Task<IActionResult> updateTestCase(int testCaseId, TestCaseRequest testCaseRequest)
        {
            return Ok(await _admin.updateTestCase(testCaseId, testCaseRequest));
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
        [HttpGet("updatecoursechaptersortnumber")]
        public async Task<IActionResult> updateCourseChapterSortNumber(int courseChapterId, int newSortNumber)
        {
            return Ok(await _admin.updateCourseChapterSortNumber(courseChapterId, newSortNumber));
        }
        [HttpGet("deletecoursechapter")]
        public async Task<IActionResult> deleteCourseChapter(int courseChapterId)
        {
            return Ok(await _admin.deleteCourseChapter(courseChapterId));
        }
        [HttpGet("getlanguesupport")]
        public async Task<IActionResult> getLangueSupport(int practiceLessonId)
        {
            return Ok(await _admin.getMultiLangueSuport(practiceLessonId));
        }
        [HttpGet("getlanguehavenot")]
        public async Task<IActionResult> getLangueHaveNote(int practiceLessonId)
        {
            return Ok(await _admin.getLangueHaveNot(practiceLessonId));
        }
        [HttpPost("addmultilangue")]
        public async Task<IActionResult> addMultiLangue(AddMultiLangue addMultiLangue)
        {
            return Ok(await _admin.addMultiLangue(addMultiLangue));
        }
        [HttpPost("updatemultilangue")]
        public async Task<IActionResult> updateMultiLangue(AddMultiLangue addMultiLangue)
        {
            return Ok(await _admin.updateMultiLangue(addMultiLangue));
        }
        [HttpGet("findlesson")]
        public async Task<IActionResult> findLessonByName(string key)
        {
            return Ok(await _admin.findLesson(key));
        }
        [HttpPost("addblog")]
        public async Task<IActionResult> addBlog([FromForm] IFormFile img, [FromForm] string data)
        {
            AddBlogRequest addBlog = JsonConvert.DeserializeObject<AddBlogRequest>(data);
            return Ok(await _admin.addBlog(img, addBlog));
        }
        [HttpGet("getblog")]
        public async Task<IActionResult> getBlogPage(int page)
        {
            return Ok(await _admin.getBlog(page));
        }
        [HttpGet("findblog")]
        public async Task<IActionResult> findBlog(string key)
        {
            return Ok(await _admin.findBlog(key));
        }
        [HttpPost("updateblog")]
        public async Task<IActionResult> updateBlog([FromForm] IFormFile? img, [FromForm] string data)
        {
            AddBlogRequest addBlog = JsonConvert.DeserializeObject<AddBlogRequest>(data);
            return Ok(await _admin.updateBlog(img, addBlog));
        }
        [HttpGet("getdenounce")]
        public async Task<IActionResult> getDenounce(int page)
        {
            return Ok(await _admin.getDenouncePage(page));
        }
        [HttpPost("confirmdenounce")]
        public async Task<IActionResult> confirmDenounce(ConfirmDenounceRequest confirmDenounce)
        {
            return Ok(await _admin.checkDenounce(confirmDenounce));
        }
        [HttpGet("gethomecontent")]
        public async Task<IActionResult> getHomeContent()
        {
            return Ok(await _admin.getHomeContent());
        }
        [HttpPost("changehomeslide")]
        public async Task<IActionResult> changeSlide([FromForm] IFormFile? slide1, IFormFile? slide2, IFormFile? slide3, IFormFile? slide4, IFormFile? slide5)
        {
            return Ok(await _admin.changeSlide(slide1, slide2, slide3, slide4, slide5));
        }
        [HttpGet("getadminpost")]
        public async Task<IActionResult> getAdminPost(int? statusOptId, int page)
        {
            return Ok(await _admin.getPostAdmin(statusOptId, page));
        }
        [HttpPost("updatepostadmin")]
        public async Task<IActionResult> changeSlide([FromForm] IFormFile? img, [FromForm] string data)
        {
            UpdatePostAdminRequest updatePostAdmin = JsonConvert.DeserializeObject<UpdatePostAdminRequest>(data);
            return Ok(await _admin.updatePost(img, updatePostAdmin));
        }
        [HttpGet("getlockuser")]
        public async Task<IActionResult> getLockUser(int page)
        {
            return Ok(await _admin.GetUserLockPage(page));
        }
        [HttpGet("getanalytic")]
        public async Task<IActionResult> GetAnalytic()
        {
            return Ok(await _admin.GetAnalytics());
        }
        [HttpGet("getanalyticfilter")]
        public async Task<IActionResult> GetAnalyticFilter(DateTime openTime, DateTime closeTime)
        {
            return Ok(await _admin.GetAnalyticsFilter(openTime, closeTime));
        }
        [HttpGet("getadvicecontact")]
        public async Task<IActionResult> GetAdviceContact(int page)
        {
            return Ok(await _admin.GetAdviceContact(page));
        }
        [HttpGet("getadvicedetail")]
        public async Task<IActionResult> GetAdviceDetail(int adviceId)
        {
            return Ok(await _admin.getAdviceDetail(adviceId));
        }
        [HttpGet("getcourseana")]
        public async Task<IActionResult> GetCourseAna(int type = -1)
        {
            return Ok(await _admin.getCourseAna(type));
        }
        [HttpGet("getliststudentofcourse")]
        public async Task<IActionResult> GetStudentOfCourse(int courseId, int page)
        {
            return Ok(await _admin.ListStudentOfCourse(courseId, page));
        }
        [HttpGet("userlessonprogress")]
        public async Task<IActionResult> GetCourseProgress(int courseId, int userId)
        {
            return Ok(await _admin.GetCourseProgressUser(courseId, userId));
        }
        [HttpGet("lockorunlocklesson")]
        public async Task<IActionResult> LockOrUnlockLesson(int userId, int lessonId)
        {
            return Ok(await _admin.lockOrUnlockLesson(userId, lessonId));
        }
        [HttpGet("getdonedata")]
        public async Task<IActionResult> getDoneDataOfUser(int userId, int lessonId)
        {
            Lesson l = await _appContext.lesson.FindAsync(lessonId);
            switch (l.LessonTypeId)
            {
                case 1:
                    VideoLesson d = await _appContext.video_lesson.Where(x => x.LessonId == l.Id).FirstOrDefaultAsync();
                    return Ok(await _admin.GetVideoDoneDataOfUser(userId, d.Id));
                case 2:
                    dj_webdesigncore.Entities.CourseEntity.PracticeLesson d1 = await _appContext.practice_lesson.Where(x => x.LessonId == l.Id).FirstOrDefaultAsync();
                    return Ok(await _admin.GetPracDoneDataOfUser(userId, d1.Id));
                case 3:
                    QuestionLesson d2 = await _appContext.question_lesson.Where(x => x.LessonId == l.Id).FirstOrDefaultAsync();
                    return Ok(await _admin.GetQuesDoneDataOfUser(userId, d2.Id));
                default: return BadRequest("Không tìm thấy");
            }
        }
        [HttpGet("getusershow")]
        public async Task<IActionResult> GetUserShow(int userId)
        {
            return Ok(await _admin.GetUserShow(userId));
        }
        [HttpGet("courseanatype")]
        public async Task<IActionResult> GetCourseAnaType(int courseId, int page, int opt = 1)
        {
            return Ok(await _admin.GetCourseAnaType(courseId, page, opt));
        }
    }
}
