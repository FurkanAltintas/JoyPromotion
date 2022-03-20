using AutoMapper;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;

namespace JoyPromotion.Business.Mapping
{
    public class ContentProfile : Profile
    {
        public ContentProfile()
        {
            CreateMap<Content, ContentListDto>().ReverseMap();
            CreateMap<Content, ContentDto>().ReverseMap();
            CreateMap<Content, ContentAddDto>().ReverseMap();
            CreateMap<Content, ContentUpdateDto>().ReverseMap();
            CreateMap<ContentUpdateDto, ContentDto>().ReverseMap();
        }
    }
}
