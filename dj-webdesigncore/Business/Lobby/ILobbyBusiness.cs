using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Lobby;
using dj_webdesigncore.DTOs.Study;
using dj_webdesigncore.Enums.ApiEnums;
using dj_webdesigncore.Request.Course;
using dj_webdesigncore.Request.SomeThingElse;
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
        Task<ResponData<ActionStatus>> AdviceMentor(AdviceMentorRequest adviceMentorRequest);
        Task<ResponData<TakeCertificateDTO>> TakeCertificate(int courseId, int userId);
        Task<TryCodeHome> TryCodeHome(string source);
    }
}
