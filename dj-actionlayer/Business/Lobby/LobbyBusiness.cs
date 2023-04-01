using dj_webdesigncore.Business.Lobby;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Lobby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_actionlayer.Business.Lobby
{
    public class LobbyBusiness : BaseBusiness, ILobbyBusiness
    {
        public ResponData<LobbyDTO> LobbyContent()
        {
            ResponData<LobbyDTO> result = new ResponData<LobbyDTO>();

            try
            {
                LobbyDTO lobbyDTO = new LobbyDTO();
                ListActiveCourse listActiveCourse = new ListActiveCourse();
                listActiveCourse.StudyedStudent = _context.user_course.ToList().Count;
                listActiveCourse.StudyingStudent = _context.user_course.Where(x => x.isDone == false).ToList().Count;
                List<CourseDTO> courseDTOs = new List<CourseDTO>();
                var courseActiveList = _context.course.Where(x => x.CourseStatusId == 1).ToList();
                foreach (var course in courseActiveList)
                {
                    CourseDTO courseDTO = new CourseDTO();
                    courseDTO.CourseImageData = course.CourseImageData;
                    courseDTO.CourseName = course.CourseName;
                    courseDTO.StudentCount = _context.user_course.Where(x => x.CourseId == course.Id).ToList().Count;
                    courseDTOs.Add(courseDTO);
                }
                listActiveCourse.courseDTOs = courseDTOs;
                lobbyDTO.ListActiveCourse = listActiveCourse;
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Data = lobbyDTO;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch (Exception ex)
            {
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }
    }
}
