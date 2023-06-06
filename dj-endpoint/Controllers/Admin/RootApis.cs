using dj_actionlayer.Business.Admin;
using dj_webdesigncore.Business.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dj_endpoint.Controllers.Admin
{
    [Authorize(Policy = "ADMIN")]
    [Route("/root")]
    public class RootApis : BaseApi
    {
        private readonly IRootBusiness _root;

        public RootApis()
        {
            _root = new RootBusiness();
        }
        [HttpGet("getuser")]
        public async Task<IActionResult> getUserPage(int page)
        {
            return Ok(await _root.GetUserPage(page));
        }
        [HttpGet("getuserdenounce")]
        public async Task<IActionResult> getUserDenounce(int page)
        {
            return Ok(await _root.GetUserDenounce(page));
        }
    }

}
