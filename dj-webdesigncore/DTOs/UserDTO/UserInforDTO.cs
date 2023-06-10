using dj_webdesigncore.Entities.BusinessEntity;
using dj_webdesigncore.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.UserDTO
{
    public class UserInforDTO
    {
        public int UserId { get; set; }
        public string UserAvatarData40x40 { get; set; }
        public string UserEmail { get; set; }
        public string UserFacebook { get; set; }
        public string UserLinkedIn { get; set; }
        public string UserFisrtName { get; set; }
        public string UserLastName { get; set; }
        public string NumberPhone { get; set; }
        public string UserDetail { get; set; }
        public string Birthday { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public string Ward { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string ProvinceCode { get; set; }
        public string WardCode { get; set; }
        public string DistrictCode { get; set; }
        public string AddressNow { get; set; }
        public string Catalog { get; set; }
        public int? CatalogId { get; set; }
        public List<ExperienceDTO> experienceDTOs { get; set; }
        public List<LearningDTO> learningDTOs { get; set; }
        public List<District> districts { get; set; }
        public List<Province> provinces { get; set; }
        public List<Ward> wards { get; set; }
        public List<Gender> genders { get; set; }
        public List<UserCatalog> catalogs { get; set; }
    }
}
