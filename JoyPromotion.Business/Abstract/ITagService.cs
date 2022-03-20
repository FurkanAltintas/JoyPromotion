using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using System.Collections.Generic;

namespace JoyPromotion.Business.Abstract
{
    public interface ITagService
    {
        List<TagListDto> GetAll();
        TagDto GetById(int id);
        TagAddDto Add(TagAddDto tagAddDto);
        TagUpdateDto Update(TagUpdateDto tagUpdateDto);
        void Delete(Tag tag);
        TDto Convert<TDto>(TagDto tagDto);
    }
}
