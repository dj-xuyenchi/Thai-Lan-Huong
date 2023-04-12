using dj_actionlayer.Business.Study;
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
    }
}
