using dj_actionlayer.Business.UserBusiness;
using dj_webdesigncore.Business.Study;
using dj_webdesigncore.Business.UserIBusiness;
using dj_webdesigncore.Request.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace dj_endpoint.Controllers.UserAPIs
{
    [Authorize(Policy = "ADMINANDMEMBER")]
    [Route("/user")]
    public class UserApi : BaseApi
    {
        private readonly IUserBusiness _user;

        public UserApi()
        {
            _user = new UserBusiness();
        }

        [HttpGet("getuserinformation")]
        public async Task<IActionResult> getUserInformation(int userId)
        {
            return Ok(await _user.getInformation(userId));
        }
        [HttpGet("getoptionupdate")]
        public async Task<IActionResult> getOptionUpdate()
        {
            return Ok(await _user.optionUpdateInfor());
        }
        [HttpGet("getdistrict")]
        public async Task<IActionResult> getDistrict(string provinceCode)
        {
            return Ok(await _user.getDistrict(provinceCode));
        }
        [HttpGet("getward")]
        public async Task<IActionResult> getWard(string districtCode)
        {
            return Ok(await _user.getWard(districtCode));
        }
        [HttpPost("updateuser")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile? avatar,UpdateUserRequest updateUserRequest)
        {
            return Ok();
        }

    }
}
