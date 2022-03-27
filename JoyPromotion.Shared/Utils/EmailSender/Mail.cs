using System.Net;
using System.Net.Mail;

namespace JoyPromotion.Shared.Utils.EmailSender
{
    public class Mail
    {
        private const string Gmail = "smtp.gmail.com";
        private const int GmailPort = 587;

        public const string EmailConfirmed = "Joy Email Onaylama Bildirimi";
        public const string PasswordReset = "Joy Şifre Değiştirme Talebi";


        public void MailSend(string mail, string body, string subject)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new("sateaga6782@gmail.com");
            // mailMessage.CC.Add("name@gmail.com"); // developerlar ve kimin de görmesini istediği yer
            mailMessage.To.Add(mail);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new(Gmail, GmailPort);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential("furkanaltintas786@gmail.com", "brkNet.1813");
            smtpClient.Send(mailMessage);
        }
    }
}
