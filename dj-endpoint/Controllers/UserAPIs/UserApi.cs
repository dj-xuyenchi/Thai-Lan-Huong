using dj_actionlayer.Business.UserBusiness;
using dj_webdesigncore.Business.Study;
using dj_webdesigncore.Business.UserIBusiness;
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
    }
}
