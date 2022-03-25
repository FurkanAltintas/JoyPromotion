using AutoMapper;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;

namespace JoyPromotion.Business.Mapping
{
    public  class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactListDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Contact, ContactAddDto>().ReverseMap();
            CreateMap<Contact, ContactUpdateDto>().ReverseMap();
            CreateMap<ContactUpdateDto, CategoryDto>().ReverseMap();
        }
    }
}
