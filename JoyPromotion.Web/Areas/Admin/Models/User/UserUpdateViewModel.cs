using JoyPromotion.Dtos.Dtos;
using Microsoft.AspNetCore.Http;

namespace JoyPromotion.Web.Areas.Admin.Models
{
    public class UserUpdateViewModel
    {
        public UserUpdateDto UserUpdateDto { get; set; }
        public IFormFile Image { get; set; }
    }
}
