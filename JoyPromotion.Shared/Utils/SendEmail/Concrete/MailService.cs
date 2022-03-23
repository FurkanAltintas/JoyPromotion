using Microsoft.Extensions.Options;
namespace JoyPromotion.Shared.Utils.SendEmail.Concrete
{
    public class MailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
    }
}
