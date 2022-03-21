using JoyPromotion.Dtos.Dtos;
using System.Collections.Generic;

namespace JoyPromotion.Web.Models
{
    public class ContentViewModelUI
    {
        public ContentDto ContentDto { get; set; }
        public List<ContentListDto> TakeTheLastThreeDtos { get; internal set; }
        public List<UserSocialMediaListDto> GetUserSocialMediaDtos { get; internal set; }
    }
}
