using AutoMapper;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using System;

namespace JoyPromotion.Business.Mapping
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactListDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Contact, ContactAddDto>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now)).ReverseMap();
            CreateMap<Contact, ContactUpdateDto>().ReverseMap();
            CreateMap<ContactUpdateDto, CategoryDto>().ReverseMap();
        }
    }
}
