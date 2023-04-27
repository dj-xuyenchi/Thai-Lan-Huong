
using dj_actionlayer.Business.Auth;
using dj_webdesigncore.AuthModel;
using dj_webdesigncore.Business.Auth;
using dj_webdesigncore.Request.Account;
using Microsoft.AspNetCore.Mvc;

namespace dj_endpoint.Controllers.AuthApis
{
    [Route("/login")]
    public class AuthApis : BaseApi
    {
        private readonly IAuthBusiness authBusiness;

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
        [HttpGet("confirmemail")]
        public async Task<IActionResult> ConfirmEmail(string code)
        {
            return Ok(await authBusiness.ConfirmAccount(code));
        }
        [HttpPost("forgetpass")]
        public async Task<IActionResult> ForgetPass(ForgetPassRequest forgetPassRequest)
        {
            return Ok(await authBusiness.ForgetPass(forgetPassRequest));
        }
        [HttpGet("confirmcodeforgetpass")]
        public async Task<IActionResult> ConfirmCodeForgetPass(string code)
        {
            return Ok(await authBusiness.ConfirmCodeForgetPass(code));
        }
        [HttpPost("confirmpass")]
        public async Task<IActionResult> ConfirmNewPass(ConfirmNewPass confirmNewPass)
        {
            return Ok(await authBusiness.ConfirmNewPass(confirmNewPass));
        }
    }
}
