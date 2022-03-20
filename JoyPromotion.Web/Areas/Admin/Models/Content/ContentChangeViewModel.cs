using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace JoyPromotion.Web.Areas.Admin.Models
{
    public class ContentChangeViewModel
    {
        public IEnumerable<SelectListItem> CategoryListDtos { get; set; }
        public IEnumerable<SelectListItem> TagListDtos { get; set; }
        public IEnumerable<int> TagId { get; set; }
        public IFormFile Image { get; set; }
    }
}
