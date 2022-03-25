using System.ComponentModel.DataAnnotations;

namespace JoyPromotion.Dtos.Dtos
{
    public class ContactAddDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        [Required]
        [StringLength(4)]
        public string CaptchaCode { get; set; }
    }
}
