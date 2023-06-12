using dj_webdesigncore.Entities.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Lobby
{
    public class LobbyDTO
    {
        public ListActiveCourse ListActiveCourse { get; set; }
        public List<PostDTO> ListPost { get; set; }
        public List<BlogDTO> Blog { get; set; }
        public List<string> Slide { get; set; }
    }
}
