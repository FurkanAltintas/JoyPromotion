using JoyPromotion.Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace JoyPromotion.Web.Areas.Admin.Models
{
    public class UserViewModel
    {
        public User Users { get; set; }
        public IFormFile Image { get; set; }
    }
}