using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace JoyPromotion.Shared.Utils.SendEmail.Concrete
{
    public class MailRequest
    {
        public string ToMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
