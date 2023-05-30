using dj_webdesigncore.DTOs;
using dj_webdesigncore.DTOs.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Business.Post
{
    public interface IPostBusiness
    {
        Task<ResponData<PostDetailDTO>> getPostDetail(int postId, int userId);
    }
}
