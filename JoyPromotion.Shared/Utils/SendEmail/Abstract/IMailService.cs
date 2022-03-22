using JoyPromotion.Shared.Utils.SendEmail.Concrete;
using System.Threading.Tasks;

namespace JoyPromotion.Shared.Utils.SendEmail.Abstract
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
