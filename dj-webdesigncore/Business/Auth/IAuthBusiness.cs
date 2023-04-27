using System;
using dj_webdesigncore.AuthModel;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Lobby;
using dj_webdesigncore.Entities.UserEntity;
using dj_webdesigncore.Enums.ApiEnums;
using dj_webdesigncore.Request.Account;

namespace dj_webdesigncore.Business.Auth
{
	public interface IAuthBusiness
	{
        Task<LoginResponse<AuthDataRespon>> Login(RequestLogin request);
        Task<LoginResponse<TokenModel>> RenewToken(TokenModel model);
        Task<DateTime> ConvertUnixTimeToDateTime(long utcExpireDate);
        Task<TokenModel> GenToken(User user);
        Task<string> GenerateRefreshToken();
        Task<ResponData<NewAccount>> SignIn(SignInAccount newAccount);
        Task<ResponData<ActionStatus>> ForgetPass(ForgetPassRequest forgetPassRequest);
        Task<LoginResponse<AuthDataRespon>> ConfirmAccount(string code);
        Task<ResponData<ActionStatus>> ConfirmCodeForgetPass(string code);
        Task<LoginResponse<AuthDataRespon>> ConfirmNewPass(ConfirmNewPass confirmNewPass);
    }
}

