using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using System.Collections.Generic;

namespace JoyPromotion.Business.Abstract
{
    public interface IContentTagService
    {
        List<ContentTagListDto> GetAll();
        ContentTagDto GetById(int id);
        void Add(IEnumerable<int> tagId, int contentId);
        ContentTagUpdateDto Update(ContentTagUpdateDto contentTagUpdateDto);
        void Delete(ContentTag contentTag);
        TDto Convert<TDto>(ContentTagDto contentTagDto);
    }
}
