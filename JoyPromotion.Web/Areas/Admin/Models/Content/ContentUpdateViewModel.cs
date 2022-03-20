using JoyPromotion.Dtos.Dtos;
using System.Collections.Generic;

namespace JoyPromotion.Web.Areas.Admin.Models
{
    public class ContentUpdateViewModel : ContentChangeViewModel
    {
        public ContentUpdateDto ContentUpdateDto { get; set; }
        public List<ContentTagListFetchDto> ContentTagFetchDtos { get; set; }
    }
}
