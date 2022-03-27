using JoyPromotion.Shared.Utils.EmailSender;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JoyPromotion.Web.Utils
{
    public static class EmailSenderRequest
    {
        private static readonly MailSender mailSender;
        public static void SenderRequest(this Controller controller, string email, string subject)
        {
            var callBackUrl = controller.Url.Action("ResetPassword", "Auth", new { userId = 1, code = Guid.NewGuid().ToString() });
            var request = controller.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}" + callBackUrl;
            mailSender.Send(email, baseUrl, subject);
        }

        public const string EmailConfirmed = "Joy Email Onaylama Bildirimi";
        public const string PasswordReset = "Joy Şifre Değiştirme Talebi";
    }
}
