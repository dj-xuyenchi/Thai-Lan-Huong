﻿using dj_webdesigncore.DTOs;
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
       Task<ResponData<LobbyDTO>> LobbyContent();
        Task<ResponData<CourseDetailDTO>> CourseDetailContent(int? courseId, int? userId);
        Task<ResponData<List<CourseListDTO>>> CourseListContent();
    }
}
