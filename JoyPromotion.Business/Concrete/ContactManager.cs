using AutoMapper;
using JoyPromotion.Business.Abstract;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using System.Collections.Generic;

namespace JoyPromotion.Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactManager(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public ContactAddDto Add(ContactAddDto contactAddDto)
        {
            var addedContact = _mapper.Map<Contact>(contactAddDto);
            _contactRepository.Add(addedContact);
            return contactAddDto;
        }

        public TDto Convert<TDto>(ContactDto contactDto)
        {
            return _mapper.Map<TDto>(contactDto);
        }

        public void Delete(Contact contact)
        {
            _contactRepository.Delete(contact);
        }

        public List<ContactListDto> GetAll()
        {
            return _mapper.Map<List<ContactListDto>>(_contactRepository.GetAll());
        }

        public ContactDto GetById(int id)
        {
            return _mapper.Map<ContactDto>(_contactRepository.GetById(id));
        }

        public ContactUpdateDto Update(ContactUpdateDto contactUpdateDto)
        {
            var updateContact = _mapper.Map<Contact>(contactUpdateDto);
            _contactRepository.Update(updateContact);
            return contactUpdateDto;
        }
    }
}
