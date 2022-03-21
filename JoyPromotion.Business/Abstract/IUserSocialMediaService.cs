using JoyPromotion.Dtos.Dtos;
using System.Collections.Generic;

namespace JoyPromotion.Business.Abstract
{
    public interface IUserSocialMediaService
    {
        List<UserSocialMediaListDto> GetUserSocialMedia(int userId);
    }
}
