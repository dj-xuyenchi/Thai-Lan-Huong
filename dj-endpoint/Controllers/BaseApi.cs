using dj_actionlayer.DAO;
using Microsoft.AspNetCore.Mvc;

namespace dj_endpoint.Controllers
{
    [ApiController]
    public class BaseApi : ControllerBase
    {
        public readonly dj_actionlayer.DAO.AppContext _appContext;

        public BaseApi()
        {
            _appContext = new dj_actionlayer.DAO.AppContext();
        }
    }
}
