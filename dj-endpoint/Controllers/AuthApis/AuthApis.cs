
using dj_actionlayer.Business.Auth;
using dj_webdesigncore.AuthModel;
using dj_webdesigncore.Request.Account;
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
        public async Task<IActionResult> Login(RequestLogin request)
        {
            return Ok(await authBusiness.Login(request));
        }
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken(TokenModel tokenModel)
        {
            return Ok(await authBusiness.RenewToken(tokenModel));
        }
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInAccount newAccount)
        {
            return Ok(await authBusiness.SignIn(newAccount));
        }
    }
}
