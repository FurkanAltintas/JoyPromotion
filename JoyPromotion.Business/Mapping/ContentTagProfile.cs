using AutoMapper;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;

namespace JoyPromotion.Business.Mapping
{
    public class ContentTagProfile : Profile
    {
        public ContentTagProfile()
        {
            CreateMap<ContentTag, ContentTagListDto>().ReverseMap();
            CreateMap<ContentTag, ContentTagDto>().ReverseMap();
            CreateMap<ContentTag, ContentTagAddDto>().ReverseMap();
            CreateMap<ContentTag, ContentTagUpdateDto>().ReverseMap();
            CreateMap<ContentTagUpdateDto, ContentTagDto>().ReverseMap();
        }
    }
}
