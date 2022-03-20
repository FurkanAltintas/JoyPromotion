using AutoMapper;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;

namespace JoyPromotion.Business.Mapping
{
    public class SocialMediaProfile : Profile
    {
        public SocialMediaProfile()
        {

            CreateMap<SocialMedia, SocialMediaListDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaAddDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaUpdateDto>().ReverseMap();
            CreateMap<SocialMediaUpdateDto, SocialMediaDto>().ReverseMap();
        }
    }
}
