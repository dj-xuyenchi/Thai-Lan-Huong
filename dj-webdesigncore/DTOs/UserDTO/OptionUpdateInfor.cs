using System;
using dj_webdesigncore.Entities.BusinessEntity;
using dj_webdesigncore.Entities.UserEntity;

namespace dj_webdesigncore.DTOs.UserDTO
{
	public class OptionUpdateInfor
	{
		public List<District> districts { get; set; }
        public List<Province> provinces { get; set; }
        public List<Ward> wards { get; set; }
        public List<Gender> genders { get; set; }
        public List<UserCatalog> catalogs { get; set; }
        public List<UserRole> roles { get; set; }
        public List<UserStatus> statuses { get; set; }
    }
}

