using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using System.Collections.Generic;

namespace JoyPromotion.Business.Abstract
{
    public interface IContactService
    {
        List<ContactListDto> GetAll();
        ContactDto GetById(int id);
        ContactAddDto Add(ContactAddDto contactAddDto);
        ContactUpdateDto Update(ContactUpdateDto contactUpdateDto);
        void Delete(Contact contact);
        TDto Convert<TDto>(ContactDto contactDto);
    }
}
