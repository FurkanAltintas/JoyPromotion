using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess;
using System.Collections.Generic;

namespace JoyPromotion.DataAccess.Abstract
{
    public interface IUserSocialMediaRepository : IGenericRepository<UserSocialMedia>
    {
        List<UserSocialMediaListDto> GetUserSocialMedia(int userId);
    }
}
