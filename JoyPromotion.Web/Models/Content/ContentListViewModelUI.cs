using JoyPromotion.Dtos.Dtos;
using System.Collections.Generic;

namespace JoyPromotion.Web.Models
{
    public class ContentListViewModelUI
    {
        public IEnumerable<ContentListDto> ContentListDtos { get; set; }
        public ContentDto ContentDto { get; set; }
    }
}
