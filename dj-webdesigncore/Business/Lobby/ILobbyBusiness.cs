using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Lobby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Business.Lobby
{
    public interface ILobbyBusiness
    {
        ResponData<LobbyDTO> LobbyContent();
        ResponData<CourseDetailDTO> CourseDetailContent(int? courseId,int? userId);
    }
}
