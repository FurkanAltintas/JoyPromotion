using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace JoyPromotion.Shared.Utils.SendEmail.Concrete
{
    public class MailSender
    {
        const string SecurityKey = "0123456789ABCDEFGHJKLMNOPRSTUVWXYZ";

        public string Key()
        {
            Random random = new Random();
            int maxRand = SecurityKey.Length - 1;
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                int index = random.Next(maxRand);
                stringBuilder.Append(SecurityKey[index]);
            }

            return stringBuilder.ToString();
        }

        public void Email(string email)
        {
            MailMessage mailMessage = new MailMessage();
            string senderMail = "Email bilgimiz";
            string senderPassword = "Password bilgimiz";
            mailMessage.To.Add(email);
            mailMessage.From = new MailAddress(senderMail);
            mailMessage.Body = $"Aktivasyon Kodu {Key()}";
            mailMessage.Subject = "Hesap Aktivasyon İşlemi";
            SmtpClient smtp = new SmtpClient(Server.Gmail);
            smtp.EnableSsl = true;
            smtp.Port = (int)Server.Port.Gmail;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(senderMail, senderPassword);
            smtp.Send(mailMessage);
        }
    }
}
