using dj_actionlayer.DAO;
using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Entities.UserEntity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
namespace dj_actionlayer.Business.Home
{
    public class HomeBusiness : BaseBusiness
    {
        public List<Course> getALl()
        {
            return _context.course.ToList();
        }
        public List<Gender> getALlGender()
        {
            return _context.gender.ToList();
        }
    }
}
