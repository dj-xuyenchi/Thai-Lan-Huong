using System;
namespace dj_webdesigncore.Request.Lesson
{
	public class TestCaseRequest
	{
		public int PracticeId { get; set; }
		public string? InputDetail { get; set; }
		public string? Input { get; set; }
		public string Output { get; set; }
		public bool IsLock { get; set; }
		public int SortNumber { get; set; }
	}
}

