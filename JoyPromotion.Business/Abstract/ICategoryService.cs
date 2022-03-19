using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using System.Collections.Generic;

namespace JoyPromotion.Business.Abstract
{
    public interface ICategoryService
    {
        List<CategoryListDto> GetAll();
        CategoryDto GetById(int id);
        CategoryAddDto Add(CategoryAddDto categoryAddDto);
        CategoryUpdateDto Update(CategoryUpdateDto categoryUpdateDto);
        void Delete(Category category);
        TDto Convert<TDto>(CategoryDto categoryDto);
    }
}
