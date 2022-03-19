using AutoMapper;
using JoyPromotion.Business.Abstract;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using System.Collections.Generic;

namespace JoyPromotion.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public CategoryAddDto Add(CategoryAddDto categoryAddDto)
        {
            var addedCategory = _mapper.Map<Category>(categoryAddDto);
            _categoryRepository.Add(addedCategory);
            return categoryAddDto;
        }

        public TDto Convert<TDto>(CategoryDto categoryDto)
        {
            return _mapper.Map<TDto>(categoryDto);
        }

        public void Delete(Category category)
        {
            _categoryRepository.Delete(category);
        }

        public List<CategoryListDto> GetAll()
        {
            return _mapper.Map<List<CategoryListDto>>(_categoryRepository.GetAll());
        }

        public CategoryDto GetById(int id)
        {
            return _mapper.Map<CategoryDto>(_categoryRepository.GetById(id));
        }

        public CategoryUpdateDto Update(CategoryUpdateDto categoryUpdateDto)
        {
            var updatedCategory = _mapper.Map<Category>(categoryUpdateDto);
            _categoryRepository.Update(updatedCategory);
            return categoryUpdateDto;
        }
    }
}
