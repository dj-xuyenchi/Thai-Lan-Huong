using System;
namespace dj_webdesigncore.DTOs.Admin
{
	public class GetChapterDTO
	{
		public List<ChapterDetailDTO> list { get; set; }
		public int maxPage { get; set; }
	}
}

