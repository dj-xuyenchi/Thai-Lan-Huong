using dj_actionlayer.Business.Lobby;
using dj_webdesigncore.Business.Lobby;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Lobby;
using Microsoft.AspNetCore.Mvc;

namespace dj_endpoint.Controllers.HomeAPIs
{
    [Route("/lobby")]
    public class LobbyApis : BaseApi
    {
        private readonly ILobbyBusiness _lobby;

        public LobbyApis()
        {
            this._lobby = new LobbyBusiness();
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
    }
}
