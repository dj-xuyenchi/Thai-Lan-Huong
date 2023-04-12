﻿using dj_actionlayer.DAO;
using dj_webdesigncore.AuthModel;
using dj_webdesigncore.Business.Auth;
using dj_webdesigncore.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace dj_actionlayer.Business.Auth
{
    public class AuthBusiness : BaseBusiness,IAuthBusiness
    {
        public async Task<LoginResponse<AuthDataRespon>> Login(RequestLogin request)
        {
            var user = _context.user.SingleOrDefault(x => x.UserPass == request.Password && x.UserName == request.UserName);
            if (user == null)
            {
                return new LoginResponse<AuthDataRespon>
                {
                    Success = dj_webdesigncore.Enums.AuthEnums.AuthStatusEnum.FAILED,
                    Message = "Invalid username/password"
                };
            }
            return new LoginResponse<AuthDataRespon>
            {
                Success = dj_webdesigncore.Enums.AuthEnums.AuthStatusEnum.SUCCESS,
                Message = "Authenticate success",
                Data = new AuthDataRespon
                {
                    id= user.Id,
                    avatar=user.UserAvatarData40x40,
                    nickName = "Chiến thần Front End",
                    name= user.UserLastName + " "+ user.UserFisrtName,
                    Token =await GenToken(user)
                }
            };
        }
        public async Task<LoginResponse<TokenModel>> RenewToken(TokenModel model)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(Settings.SecretKey());
            var tokenValidateParam = new TokenValidationParameters
            {
                //tự cấp token
                ValidateIssuer = false,
                ValidateAudience = false,

                //ký vào token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                ClockSkew = TimeSpan.Zero,

                ValidateLifetime = false //ko kiểm tra token hết hạn
            };
            try
            {
                //check 1: AccessToken valid format
                var tokenInVerification = jwtTokenHandler.ValidateToken(model.AccessToken, tokenValidateParam, out var validatedToken);

                //check 2: Check alg
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase);
                    if (!result)//false
                    {
                        return new LoginResponse<TokenModel>
                        {
                            Success = dj_webdesigncore.Enums.AuthEnums.AuthStatusEnum.FAILED,
                            Message = "Invalid token"
                        };
                    }
                }

                //check 3: Check accessToken expire?
                var utcExpireDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expireDate = await ConvertUnixTimeToDateTime(utcExpireDate);
                if (expireDate > DateTime.UtcNow)
                {
                    return new LoginResponse<TokenModel>
                    {
                        Success = dj_webdesigncore.Enums.AuthEnums.AuthStatusEnum.FAILED,
                        Message = "Access token has not yet expired"
                    };
                }

                //check 4: Check refreshtoken exist in DB
                var storedToken = _context.refresh_token.FirstOrDefault(x => x.Token == model.RefreshToken);
                if (storedToken == null)
                {
                    return new LoginResponse<TokenModel>
                    {
                        Success = dj_webdesigncore.Enums.AuthEnums.AuthStatusEnum.FAILED,
                        Message = "Refresh token does not exist"
                    };
                }

                //check 5: check refreshToken is used/revoked?
                if (storedToken.IsUsed)
                {
                    return new LoginResponse<TokenModel>
                    {
                        Success = dj_webdesigncore.Enums.AuthEnums.AuthStatusEnum.FAILED,
                        Message = "Refresh token has been used"
                    };
                }
                if (storedToken.IsRevoked)
                {
                    return new LoginResponse<TokenModel>
                    {
                        Success = dj_webdesigncore.Enums.AuthEnums.AuthStatusEnum.FAILED,
                        Message = "Refresh token has been revoked"
                    };
                }

                //check 6: AccessToken id == JwtId in RefreshToken
                var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                if (storedToken.JwtId != jti)
                {
                    return new LoginResponse<TokenModel>
                    {
                        Success = dj_webdesigncore.Enums.AuthEnums.AuthStatusEnum.FAILED,
                        Message = "Token doesn't match"
                    };
                }

                //Update token is used
                storedToken.IsRevoked = true;
                storedToken.IsUsed = true;
                _context.Update(storedToken);
                _context.SaveChanges();

                //create new token
                var user = _context.user.SingleOrDefault(nd => nd.Id == storedToken.UserId);
                var token = await GenToken(user);

                return new LoginResponse<TokenModel>
                {
                    Success = dj_webdesigncore.Enums.AuthEnums.AuthStatusEnum.SUCCESS,
                    Message = "Renew token success",
                    Data = token
                };
            }
            catch (Exception ex)
            {
                return new LoginResponse<TokenModel>
                {
                    Success = dj_webdesigncore.Enums.AuthEnums.AuthStatusEnum.FAILED,
                    Message = "Something went wrong"
                };
            }
        }
        public async Task<DateTime> ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();
            return dateTimeInterval;
        }
        public async Task<TokenModel> GenToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(Settings.SecretKey());

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, _context.user_role.Find(user.UserRoleId).UserRoleCode),
                             new Claim("LoginTime", DateTime.Now.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    

                    //roles
                }),
                // Thời gian token có hiệu lực
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(token);
            var refreshToken =await GenerateRefreshToken();

            //Lưu database
            var refreshTokenEntity = new RefreshToken
            {
                Id = Guid.NewGuid(),
                JwtId = token.Id,
                UserId = user.Id,
                Token = refreshToken,
                IsUsed = false,
                IsRevoked = false,
                IssuedAt = DateTime.Now,
                // Thời gian refresh token có hiệu lực
                ExpiredAt = DateTime.Now.AddDays(1)
            };

           await _context.AddAsync(refreshTokenEntity);
            await _context.SaveChangesAsync();

            return new TokenModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
        public async Task<string> GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }
    }
}
