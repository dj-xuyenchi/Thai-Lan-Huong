using dj_actionlayer.Business.Study;
using dj_webdesigncore.Enums.CourseEnums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dj_endpoint.Controllers.StudyAPIs
{
    [Authorize(Policy = "ADMINANDMEMBER")]
    [Route("/study")]
    public class StudyAPIs: BaseApi
    {
        private readonly StudyBusiness _study;

        public StudyAPIs()
        {
            this._study = new StudyBusiness();
        }
        [HttpGet("getcommentoflesson")]
        public async Task<IActionResult> getCommentOfLesson(int? lessonId)
        {
            return Ok(await _study.CommentOfLesson(lessonId));
        }

        [HttpGet("getlessondetail")]
        public async Task<IActionResult> getVideoLesson(int? lessonId, int? userId, int? courseId)
        {
            int type = (int)_appContext.lesson.Find(lessonId).LessonTypeId;
            switch (type)
            {
                case 1:
                    return Ok(await _study.VideoLessonContent(lessonId, userId, courseId));
                case 2:
                    return Ok(await _study.PracticeLessonContent(lessonId, userId, courseId));
                case 3:
                    return Ok(await _study.VideoLessonContent(lessonId, userId, courseId));
                default:
                    return BadRequest();
            }
        }

        [HttpGet("trytestcase")]
        public async Task<IActionResult> tryTestCase(string? code, int? practiceLessonId)
        {
            return Ok(await _study.TryTestCase(code, practiceLessonId));
        }
    }
}
