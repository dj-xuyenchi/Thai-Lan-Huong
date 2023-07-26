using Google.Apis.AnalyticsReporting.v4;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;

class Program
{
   
    public int a { get; set; }

    static void Main(string[] args)
    {
       
        //// Đường dẫn tới tệp JSON chứa thông tin xác thực
        //string credentialFilePath = @"";

        //// Đường dẫn tới tệp JSON chứa thông tin xác thực cung cấp bởi Google Developers Console
        //string tokenFilePath = "path/to/your/token.json";

        //// ID xem trong Google Analytics
        //string viewId = "your-view-id";

        //// Khởi tạo phạm vi xác thực (Scope)
        //string[] scopes = { AnalyticsReportingService.Scope.AnalyticsReadonly };

        //try
        //{
        //    // Xác thực và lấy token truy cập
        //    UserCredential credential;

        //    using (var stream = new FileStream(credentialFilePath, FileMode.Open, FileAccess.Read))
        //    {
        //        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
        //            GoogleClientSecrets.Load(stream).Secrets,
        //            scopes,
        //            "user",
        //            System.Threading.CancellationToken.None,
        //            new FileDataStore(tokenFilePath, true)).Result;
        //    }

        //    // Khởi tạo dịch vụ Google Analytics Reporting
        //    var service = new AnalyticsReportingService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = credential,
        //        ApplicationName = "Your Application Name"
        //    });

        //    // Tạo yêu cầu lấy dữ liệu
        //    // ...
        //    // Thực hiện các thao tác lấy dữ liệu từ Google Analytics tại đây
        //    // ...

        //    Console.WriteLine("Data retrieved successfully.");
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"An error occurred: {ex.Message}");
        //}
    }
}
