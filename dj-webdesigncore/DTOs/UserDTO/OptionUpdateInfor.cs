using System;
using dj_webdesigncore.Entities.UserEntity;

namespace dj_webdesigncore.DTOs.UserDTO
{
	public class OptionUpdateInfor
	{
		public List<District> districts { get; set; }
        public List<Province> provinces { get; set; }
        public List<Ward> wards { get; set; }
        public List<Gender> genders { get; set; }
    }
}

