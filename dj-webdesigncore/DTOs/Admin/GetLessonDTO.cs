using System;
namespace dj_webdesigncore.DTOs.Admin
{
	public class GetLessonDTO
	{
		public List<LessonDetailDTO> list { get; set; }
		public int maxPage { get; set; }
	}
}

