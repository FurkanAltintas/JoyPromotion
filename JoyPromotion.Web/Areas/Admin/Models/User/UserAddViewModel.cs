using JoyPromotion.Dtos.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace JoyPromotion.Web.Areas.Admin.Models
{
    public class UserAddViewModel
    {
        public UserAddDto UserAddDto { get; set; }
        public SelectList Roles { get; set; }
    }
}
