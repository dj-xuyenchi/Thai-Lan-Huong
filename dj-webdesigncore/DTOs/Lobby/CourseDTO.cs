using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.DTOs.Lobby
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public byte[] CourseImageData { get; set; }
        public int StudentCount { get; set; }
        public bool IsActive { get; set; }
    }
}
