﻿using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Business.Admin
{
    public interface IAdminBusiness
    {
        Task<ResponData<List<LessonDetailDTO>>> getAllLesson();
    }
}