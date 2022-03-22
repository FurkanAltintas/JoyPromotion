using JoyPromotion.Shared.Utils.SendEmail.Abstract;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using MailKit;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;

namespace JoyPromotion.Shared.Utils.SendEmail.Concrete
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToMail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            file.CopyTo(memoryStream);
                            fileBytes = memoryStream.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential("mail", "sifre");
            smtpClient.EnableSsl = true;
        }
    }
}
