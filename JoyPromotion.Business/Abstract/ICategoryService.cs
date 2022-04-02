using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.Utils.Results.Abstract;
using System.Collections.Generic;

namespace JoyPromotion.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<CategoryListDto> GetAll();
        IDataResult<CategoryDto> GetById(int id);
        IDataResult<CategoryDto> Add(CategoryAddDto categoryAddDto);
        IDataResult<CategoryDto> Update(CategoryUpdateDto categoryUpdateDto);
        IDataResult<CategoryDto> Delete(int categoryId);
        IResult HardDelete(int categoryId); 
        TDto Convert<TDto>(CategoryDto categoryDto);
    }
}
