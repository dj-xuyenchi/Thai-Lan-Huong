using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using dj_actionlayer.DAO;

namespace dj_actionlayer.Business.Email
{
    public class SendEmail
    {
        public string FromEmail { get; set; }
        public string Password16 { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public SendEmail(string fromEmail, string password16, string smtpHost, int smtpPort)
        {
            FromEmail = fromEmail;
            Password16 = password16;
            SmtpHost = smtpHost;
            SmtpPort = smtpPort;
        }
        public bool SendConfirmCreateAccount(string toEmail, string confirmLink)
        {
            MailMessage message = new MailMessage(FromEmail, toEmail);
            message.Subject = "Xác nhận đăng ký tài khoản DJ - Coding";
            message.Body = TemplateEmail.CreateEmail(confirmLink);
            message.IsBodyHtml= true;
            // Tạo đối tượng SmtpClient
            SmtpClient smtpClient = new SmtpClient(SmtpHost, SmtpPort);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(FromEmail, Password16);
            smtpClient.EnableSsl = true;
            try
            {
                // Gửi email
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SendForgetPass(string toEmail, string confirmLink)
        {
            MailMessage message = new MailMessage(FromEmail, toEmail);
            message.Subject = "Xác nhận yêu cầu đổi mật khẩu tài khoản DJ - Coding";
            message.Body = TemplateEmail.ForgetPass(confirmLink);
            message.IsBodyHtml = true;
            // Tạo đối tượng SmtpClient
            SmtpClient smtpClient = new SmtpClient(SmtpHost, SmtpPort);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(FromEmail, Password16);
            smtpClient.EnableSsl = true;
            try
            {
                // Gửi email
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
