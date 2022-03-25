using System.ComponentModel.DataAnnotations;

namespace JoyPromotion.Shared.Utils.Security.Captcha
{
    public class CaptchaModel
    {
        [Required]
        [StringLength(4)]
        public string CaptchaCode { get; set; }
    }
}
