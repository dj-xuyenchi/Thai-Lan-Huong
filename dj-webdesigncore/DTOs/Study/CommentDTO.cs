using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Study
{
    public class CommentDTO
    {
        public int CommentCount { get; set; }
        public List<CommentDetailDTO> ListComment { get; set; }
    }
}
