
using dj_actionlayer.Business.AuthBusiness;
using dj_webdesigncore.AuthModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dj_endpoint.Controllers.AuthApis
{
    [Route("/login")]
    public class AuthApis : BaseApi
    {
        private readonly AuthBusiness authBusiness;

        public AuthApis()
        {
            this.authBusiness = new AuthBusiness();
        }
        [HttpGet("getlogin")]
        public IActionResult Login(string userName, string password)
        {
            var result = authBusiness.Login(userName, password);
            return Ok(result);
        }
        [HttpPost("refresh")]
        public IActionResult RefreshToken(TokenModel tokenModel)
        {
            var result = authBusiness.RenewToken(tokenModel);
            return Ok(result);
        }
    }
}
