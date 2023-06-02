using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using dj_actionlayer.DAO;

namespace dj_actionlayer.Business.YoutubeAPIv3
{
    public class YoutubeAPI
    {
        public static async Task<VideoInfo> GetInfo(string id)
        {
            // Khởi tạo YouTubeService với API key hoặc OAuth 2.0 credentials
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = Settings.youtubeAPIv3Key(), // Hoặc sử dụng OAuth 2.0 credentials
                ApplicationName = "YOUR_APPLICATION_NAME"
            });

            // Tạo yêu cầu thông tin video
            var videoRequest = youtubeService.Videos.List("statistics");
            videoRequest.Id = id; // Thay YOUR_VIDEO_ID bằng ID của video cần lấy thông tin

            // Gửi yêu cầu và nhận kết quả
            var videoResponse = await videoRequest.ExecuteAsync();
            var video = videoResponse.Items.FirstOrDefault();

            // Lấy thông tin số lượt xem và số lượt bình luận
            return new VideoInfo()
            {
                view = (int)video.Statistics.ViewCount,
                cmt = (int)video.Statistics.CommentCount,
            };
        }
    }
}
