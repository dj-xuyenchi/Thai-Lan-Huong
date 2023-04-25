using dj_actionlayer.Business.Admin;
using dj_webdesigncore.Business.Admin;
using dj_webdesigncore.Request.Lesson;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}
