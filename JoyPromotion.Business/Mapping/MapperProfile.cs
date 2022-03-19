using AutoMapper;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;

namespace JoyPromotion.Business.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryListDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            CreateMap<CategoryUpdateDto, CategoryDto>().ReverseMap();

            CreateMap<Content, ContentListDto>().ReverseMap();
            CreateMap<Content, ContentDto>().ReverseMap();
            CreateMap<Content, ContentAddDto>().ReverseMap();
            CreateMap<Content, ContentUpdateDto>().ReverseMap();
            CreateMap<ContentUpdateDto, ContentDto>().ReverseMap();

            CreateMap<SocialMedia, SocialMediaListDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaAddDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaUpdateDto>().ReverseMap();
            CreateMap<SocialMediaUpdateDto, SocialMediaDto>().ReverseMap();

            CreateMap<User, UserListDto>().ReverseMap();
            CreateMap<User, UserAddDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}
