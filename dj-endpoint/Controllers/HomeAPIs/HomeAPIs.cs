using dj_actionlayer.DAO;
using dj_webdesigncore.Entities.UserEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace dj_endpoint.Controllers.HomeAPIs
{
    [Authorize(Policy = "ADMINANDMEMBER")]
    public class HomeAPIs : BaseApi
    {
   //     private readonly HomeBusiness homeBusiness;

        public HomeAPIs()
        {
  //          homeBusiness = new HomeBusiness();
        }
        [HttpGet("khoahoc")]
        public IActionResult LayDanhSachKhoaHoc()
        {
            return null;
    //        return Ok(homeBusiness.getALl());
        }
    }

}
