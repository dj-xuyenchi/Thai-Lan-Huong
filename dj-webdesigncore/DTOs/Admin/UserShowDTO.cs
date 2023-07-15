using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Admin
{
    public class UserShowDTO
    {
        public int Id { get; set; }
        public bool IsKYC { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public string Gender { get; set; }
        public string Detail { get; set; }
        public string BirthDay { get; set; }
        public string Address { get; set; }
    }
}
