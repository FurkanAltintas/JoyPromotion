using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace JoyPromotion.Web.Areas.Admin.Models
{
    public class UserViewModel
    {
        public UserDto UserDto { get; set; }
    }
}