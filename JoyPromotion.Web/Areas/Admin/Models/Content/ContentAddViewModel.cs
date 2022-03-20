using JoyPromotion.Dtos.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace JoyPromotion.Web.Areas.Admin.Models
{
    public class ContentAddViewModel
    {
        public ContentAddDto ContentAddDto { get; set; }
        public IEnumerable<SelectListItem> CategoryListDtos { get; set; }
    }
}
