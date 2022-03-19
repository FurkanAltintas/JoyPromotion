using JoyPromotion.Shared.Entities;
using System.Collections.Generic;

namespace JoyPromotion.Business.Abstract
{
    public interface IGenericServiceDto<TEntity, TEntityDto, TEntityAddDto, TEntityUpdateDto, TEntityDeleteDto> where TEntity : class, IEntity, new()
    {
        List<TEntityDto> GetAll();
        TEntity GetById(int id);
        TEntityAddDto Add(TEntityAddDto entity);
        TEntityUpdateDto Update(TEntityUpdateDto entity);
        TEntityDeleteDto Delete(TEntityDeleteDto entity);
    }
}
