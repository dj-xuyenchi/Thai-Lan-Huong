using dj_actionlayer.Business.Admin;
using dj_webdesigncore.Business.Admin;
using dj_webdesigncore.Entities.UserEntity;
using dj_webdesigncore.Request.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        [HttpGet("finduser")]
        public async Task<IActionResult> findUser(string key,int page)
        {
            return Ok(await _root.FindUserByNameEmail(key,page));
        }
        [HttpPost("createuser")]
        public async Task<IActionResult> createUser([FromForm] IFormFile? avatar, [FromForm] string updateUserRequest)
        {
            UpdateUserRequest userRequest = JsonConvert.DeserializeObject<UpdateUserRequest>(updateUserRequest);
            return Ok(await _root.createUser(avatar, userRequest));
        }
        [HttpPost("updateuser")]
        public async Task<IActionResult> updateUser([FromForm] IFormFile? avatar, [FromForm] string updateUserRequest)
        {
            UpdateUserRequest userRequest = JsonConvert.DeserializeObject<UpdateUserRequest>(updateUserRequest);
            return Ok(await _root.updateUser(avatar, userRequest));
        }
    }

}
