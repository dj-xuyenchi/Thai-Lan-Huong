using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.BusinessEntity
{
    public class UserLessonNote : BaseEntity
    {
        public int UserLessonCheckpointId { get; set; }
        public UserLessonCheckpoint UserLessonCheckpoint { get; set; }
        public string NoteTime { get; set; }
        public int SortNumber { get; set; }
    }
}
