using dj_webdesigncore.Entities.PostEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Post
{
    public  class ListPostAdmin
    {
        public IQueryable<dj_webdesigncore.Entities.PostEntity.Post> ListPost { get; set; }
        public IQueryable<PostStatus> ListOption { get; set; }
    }
}
