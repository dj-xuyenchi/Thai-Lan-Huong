﻿using System;
namespace dj_webdesigncore.DTOs.Admin
{
	public class TestCaseDTO
	{
		public int SortNumber { get; set; }
		public string TestCaseDetail { get; set; }
		public string Input { get; set; }
		public string Output { get; set; }
		public bool IsLock { get; set; }
	}
}

