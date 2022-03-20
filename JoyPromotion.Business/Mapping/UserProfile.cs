using AutoMapper;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;

namespace JoyPromotion.Business.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserListDto>().ReverseMap();
            CreateMap<User, UserAddDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}
