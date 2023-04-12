using System;
using dj_webdesigncore.AuthModel;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Lobby;
using dj_webdesigncore.Entities.UserEntity;

namespace dj_webdesigncore.Business.Auth
{
	public interface IAuthBusiness
	{
        Task<LoginResponse<AuthDataRespon>> Login(RequestLogin request);
        Task<LoginResponse<TokenModel>> RenewToken(TokenModel model);
        Task<DateTime> ConvertUnixTimeToDateTime(long utcExpireDate);
        Task<TokenModel> GenToken(User user);
        Task<string> GenerateRefreshToken();
    }
}

