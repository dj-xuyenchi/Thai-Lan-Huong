using dj_actionlayer.Business.HomeBusiness;
using dj_webdesigncore.Entities.CourseEntity;
using dj_webdesigncore.Entities.UserEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dj_endpoint.Controllers.HomeAPIs
{
    public class TestApi : BaseApi
    {
        private readonly HomeBusiness home = new HomeBusiness();
        [HttpGet("api/getall")]
        public  List<Gender> getALl()
        {
            return home.getALlGender();
        }
    }
}
