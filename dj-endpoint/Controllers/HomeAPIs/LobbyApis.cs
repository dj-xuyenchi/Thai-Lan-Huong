using dj_actionlayer.Business.Lobby;
using dj_actionlayer.Business.PostBusiness;
using dj_webdesigncore.Business.Lobby;
using dj_webdesigncore.Business.Post;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Lobby;
using dj_webdesigncore.Request.SomeThingElse;
using Microsoft.AspNetCore.Mvc;

namespace dj_endpoint.Controllers.HomeAPIs
{
    [Route("/lobby")]
    public class LobbyApis : BaseApi
    {
        private readonly ILobbyBusiness _lobby;
        private readonly IPostBusiness _post;

        public LobbyApis()
        {
            this._lobby = new LobbyBusiness();
            this._post = new PostBusiness();
        }
        [HttpGet("lobbyhomedata")]
        public async Task<IActionResult> getLobbyData()
        {
            return Ok(await _lobby.LobbyContent());
        }
        [HttpGet("lobbycourselist")]
        public async Task<IActionResult> getCourseList()
        {
            return Ok(await _lobby.CourseListContent());
        }
        [HttpGet("lobbycoursedetail")]
        public async Task<IActionResult> getCourseDetail(int? courseId,int? userId)
        {
            return Ok(await _lobby.CourseDetailContent(courseId, userId));
        }
        [HttpPost("sendadvice")]
        public async Task<IActionResult> sendAdvice(AdviceMentorRequest adviceMentorRequest)
        {
            return Ok(await _lobby.AdviceMentor(adviceMentorRequest));
        }
        [HttpGet("getpostdetail")]
        public async Task<IActionResult> getPostDetail(int postId, int userId)
        {
            return Ok(await _post.getPostDetail(postId, userId));
        }
        [HttpGet("commentofpost")]
        public async Task<IActionResult> commentOfPost(int postId, int userId)
        {
            return Ok(await _post.CommentOfPost(postId, userId));
        }
        [HttpGet("postmain")]
        public async Task<IActionResult> getPostMain()
        {
            return Ok(await _post.getPostMain());
        }
        [HttpGet("certificate")]
        public async Task<IActionResult> takeCertificate(int courseId,int userId)
        {
            return Ok(await _lobby.TakeCertificate(courseId,userId));
        }
        [HttpPost("trycodehome")]
        public async Task<IActionResult> TryCodeHome(TryCodeRequest tryCodeRequest)
        {
            return Ok(await _lobby.TryCodeHome(tryCodeRequest.Code));
        }
    }
}
