using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Post
{
    public class MyPostDTO
    {
        public List<SuggestPostDTO> WaitPost { get; set; }
        public List<SuggestPostDTO> ActivePost { get; set; }
        public List<SuggestPostDTO> UnactivePost { get; set; }

    }
}
