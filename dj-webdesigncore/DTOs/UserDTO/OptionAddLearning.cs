using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.UserDTO
{
    public class OptionAddLearning
    {
        public List<SchoolDTO> schoolDTOs { get; set; }
        public List<MajorsDTO> majorsDTOs { get;set; }
    }
}
