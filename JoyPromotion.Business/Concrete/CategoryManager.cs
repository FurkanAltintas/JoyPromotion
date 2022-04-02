using AutoMapper;
using JoyPromotion.Business.Abstract;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.Utils.Results.Abstract;
using JoyPromotion.Shared.Utils.Results.ComplexTypes;
using JoyPromotion.Shared.Utils.Results.Concrete;
using System.Collections.Generic;

namespace JoyPromotion.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IDataResult<CategoryDto> Add(CategoryAddDto categoryAddDto)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            var addedCategory = _unitOfWork.Categories.Add(category);
            return new DataResult<CategoryDto>(ResultStatus.Success, $"{addedCategory.Name} adlı kategori başarıyla eklenmiştir.", new CategoryDto
            {
                Category = addedCategory,
                ResultStatus = ResultStatus.Success,
                Message = $"{addedCategory.Name} adlı kategori başarıyla eklenmiştir."
            });
        }

        public TDto Convert<TDto>(CategoryDto categoryDto)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<CategoryDto> Delete(int categoryId)
        {
            var category = _unitOfWork.Categories.GetById(categoryId);

            if (category != null)
            {
                // IsActive, IsDelete eklenilecek
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success,
                    Message = "Silme işlemi başarıyla gerçekleşti"
                });
            }
            else
            {
                return new DataResult<CategoryDto>(ResultStatus.Error, new CategoryDto
                {
                    Category = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Böyle bir kategori sistemde bulunmamaktadır"
                });
            }
        }

        public IDataResult<CategoryListDto> GetAll()
        {
            var categories = _unitOfWork.Categories.GetAll();
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<CategoryListDto>(ResultStatus.Error, new CategoryListDto
                {
                    Categories = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Kategori içeriği boş"
                });
            }
        }

        public IDataResult<CategoryDto> GetById(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);

            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<CategoryDto>(ResultStatus.Error, new CategoryDto
                {
                    Category = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Sistemde böyle bir kategori bulunmamaktadır"
                });
            }
        }

        public IResult HardDelete(int categoryId)
        {
            var category = _unitOfWork.Categories.GetById(categoryId);

            if (category != null)
            {
                _unitOfWork.Categories.Delete(category);

                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success,
                    Message = "Kategori veritabanından başarıyla silinmiştir"
                });
            }
            else
            {
                return new DataResult<CategoryDto>(ResultStatus.Error, new CategoryDto
                {
                    Category = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Sistemde böyle bir kategori bulunmamaktadır"
                });
            }
        }

        public IDataResult<CategoryDto> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
            var updatedCategory = _unitOfWork.Categories.Update(category);
            return new DataResult<CategoryDto>(ResultStatus.Success, $"{categoryUpdateDto.Name} adlı kategori başarıyla güncellenmiştir", new CategoryDto
            {
                Category = updatedCategory,
                ResultStatus = ResultStatus.Success,
                Message = $"{categoryUpdateDto.Name} adlı kategori başarıyla güncellenmiştir"
            });
        }
    }
}
