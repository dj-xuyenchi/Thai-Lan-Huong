using dj_webdesigncore.Enums.PostEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.PostEntity
{
    /// <summary>
    /// Hủy class này do dùng v-md-editor
    /// </summary>
    public class PostSentence : BaseEntity
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string? ImageData { get; set; }
        public string? ImageTitle { get; set; }
        public string? Sentence { get; set; }
        public int SortNumber { get; set; }
        public PostSentenceTypeEnum SentenceType { get; set; }
    }
}
