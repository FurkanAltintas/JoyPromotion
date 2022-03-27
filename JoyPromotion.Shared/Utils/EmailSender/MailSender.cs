using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoyPromotion.Shared.Utils.EmailSender
{
    public class MailSender
    {
        public void Send(string email, string baseUrl, string subject)
        {
            Mail mail = new();           
            string body = new Template().PasswordReset(baseUrl);
            mail.MailSend(email, body, subject);
        }
    }
}
