
using dj_actionlayer.Business.Auth;
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
        [HttpPost("getlogin")]
        public IActionResult Login(RequestLogin request)
        {
            var result = authBusiness.Login(request);
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
