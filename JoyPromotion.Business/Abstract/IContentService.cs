using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.Entities;
using System.Collections.Generic;

namespace JoyPromotion.Business.Abstract
{
    public interface IContentService
    {
        List<ContentListDto> GetAll();
        List<ContentListDto> GetAllOrderBy();
        List<ContentListDto> TakeTheLastThree(int id);
        ContentDto TakeTheLast();
        ContentDto GetById(int id);
        ContentAddDto Add(ContentAddDto contentAddDto);
        ContentAddDto Insert(ContentAddDto contentAddDto, int userId, out int contentId);
        ContentUpdateDto Update(ContentUpdateDto contentUpdateDto);
        void Delete(Content content);
        TDto Convert<TDto>(IDto dto);
    }
}
