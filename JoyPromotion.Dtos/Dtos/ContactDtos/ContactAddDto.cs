using JoyPromotion.Shared.Entities;

namespace JoyPromotion.Dtos.Dtos
{
    public class ContactAddDto : IDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string CaptchaCode { get; set; }
    }
}
