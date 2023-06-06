using dj_actionlayer.Business.Admin;
using dj_webdesigncore.Business.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dj_endpoint.Controllers.Admin
{
    [Authorize(Policy = "MAINTAIN")]
    [Route("/maintain")]
    public class MaintainApis : BaseApi
    {
        private readonly IAdminBusiness _admin;

        public MaintainApis()
        {
            _admin = new AdminBusiness();
        }
    }
}
