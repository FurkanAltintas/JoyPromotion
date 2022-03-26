using JoyPromotion.Dtos.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JoyPromotion.Web.Areas.Admin.Models
{
    public class UserAddViewModel
    {
        public UserAddDto UserAddDto { get; set; }
        public SelectList Roles { get; set; }
    }
}
