using dj_webdesigncore.Business.Admin;
using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_actionlayer.Business.Admin
{
    public class AdminBusiness : BaseBusiness, IAdminBusiness
    {
        public async Task<ResponData<List<LessonDetailDTO>>> getAllLesson()
        {
            ResponData<List<LessonDetailDTO>> result = new ResponData<List<LessonDetailDTO>>();
            try
            {
                List<LessonDetailDTO> lessonDetailDTO= new List<LessonDetailDTO>();

                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.SECCESSFULLY;
                result.Messenger = "Lấy dữ liệu thành công!";
                return result;
            }
            catch(Exception ex)
            {
                result.Status = dj_webdesigncore.Enums.ApiEnums.ActionStatus.FAILED;
                result.Messenger = "Lấy dữ liệu thất bại! Exception: " + ex.Message;
                return result;
            }
        }
    }
}
