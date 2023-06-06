using dj_actionlayer.Business.Admin;
using dj_webdesigncore.Business.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dj_endpoint.Controllers.Admin
{
    [Authorize(Policy = "ADMIN")]
    [Route("/root")]
    public class RootApis : BaseApi
    {
        private readonly IAdminBusiness _admin;

        public RootApis()
        {
            _admin = new AdminBusiness();
        }
    }
   
}
