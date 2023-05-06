using dj_webdesigncore.DTOs.Study;
using dj_webdesigncore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dj_webdesigncore.DTOs.UserDTO;

namespace dj_webdesigncore.Business.UserIBusiness
{
    public interface IUserBusiness
    {
        Task<ResponData<UserInforDTO>> getInformation(int userId);
    }
}
