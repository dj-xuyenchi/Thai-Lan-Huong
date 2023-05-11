using System;
namespace dj_webdesigncore.Request.Account
{
    public class CreateExperience
    {
        public int userId { get; set; }
        public bool isWorking { get; set; }
        public string detail { get; set; }
        public string position { get; set; }
        public DateTime start { get; set; }
        public DateTime? end { get; set; }
    }
}

