using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Request.Course
{
    public class AddCourseRequest
    {
        public int id { get; set; }
        public string courseCode { get; set; }
        public string courseName { get; set; }
        public string courseSubTitle { get; set; }
        public int levelId { get; set; }
        public string totalTime { get; set; }
        public int typeId { get; set; }
        public string introVideoLink { get; set; }
        //
        public int statusId { get; set; }
        public int doneCount { get; set; }
        public int resigterCount { get; set; }
        public int lessonCount { get; set; }
        public int chapterCount { get; set; }
    }
}
