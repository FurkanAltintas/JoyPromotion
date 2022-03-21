using AutoMapper;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;

namespace JoyPromotion.Business.Mapping
{
    public class UserSocialMediaProfile : Profile
    {
        public UserSocialMediaProfile()
        {
            CreateMap<UserSocialMedia, UserSocialMediaListDto>().ReverseMap();
        }
    }
}
