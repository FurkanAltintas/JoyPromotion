using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoyPromotion.Shared.Utils.SendEmail
{
    public class Server
    {
        public const string Gmail = "smtp.gmail.com";
        public const string Outlook = "smpt.live.com";
        public const string YahooMail = "smtp.mail.yahoo.com";
        public const string Hotmail = "smtp.live.com";
        public const string Office365 = "smtp.office.365";

        public enum Port
        {
            Gmail = 587,
            Outlook = 587,
            YahooMail = 465,
            Hotmail = 465,
            Office365 = 587
        }
    }
}
