using dj_actionlayer.Business.Admin;
using dj_webdesigncore.Business.Admin;
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

        [HttpGet("getlesson")]
        public async Task<IActionResult> getLobbyData()
        {
            return Ok(await _admin.getAllLesson());
        }
        [HttpGet("checkadmin")]
        public async Task<IActionResult> checkAdmin()
        {
            return Ok("Admin");
        }
    }
}
