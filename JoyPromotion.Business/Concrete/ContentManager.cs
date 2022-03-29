using AutoMapper;
using JoyPromotion.Business.Abstract;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.Entities;
using JoyPromotion.Shared.Extensions;
using JoyPromotion.Shared.Utils;
using System.Collections.Generic;

namespace JoyPromotion.Business.Concrete
{
    public class ContentManager : IContentService
    {
        private readonly IContentRepository _contentRepository;
        private readonly IMapper _mapper;

        public ContentManager(IContentRepository contentRepository, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _mapper = mapper;
        }

        public ContentAddDto Add(ContentAddDto contentAddDto)
        {
            var addedContent = _mapper.Map<Content>(contentAddDto);
            _contentRepository.Add(addedContent);
            return contentAddDto;
        }

        public TDto Convert<TDto>(IDto dto)
        {
            return _mapper.Map<TDto>(dto);
        }

        public void Delete(Content content)
        {
            _contentRepository.Delete(content);
        }

        public List<ContentListDto> GetAll()
        {
            return _mapper.Map<List<ContentListDto>>(_contentRepository.GetAll());
        }

        public List<ContentListDto> GetAllOrderBy()
        {
            return _mapper.Map<List<ContentListDto>>(_contentRepository.GetAllOrderBy());
        }

        public ContentDto GetById(int id)
        {
            return _mapper.Map<ContentDto>(_contentRepository.GetById(id));
        }

        public ContentAddDto Insert(ContentAddDto contentAddDto, int userId, out int contentId)
        {
            var content = _mapper.Map<Content>(contentAddDto);
            content.SlugTitle = UrlExtensions.FriendlyUrl(content.Title);
            content.UserId = userId;
            _contentRepository.Add(content);
            contentId = content.Id;
            return contentAddDto;
        }

        public ContentDto TakeTheLast()
        {
            return _mapper.Map<ContentDto>(_contentRepository.TakeTheLast());
        }

        public List<ContentListDto> TakeTheLastThree(int id)
        {
            return _mapper.Map<List<ContentListDto>>(_contentRepository.TakeTheLastThree(id));
        }

        public ContentUpdateDto Update(ContentUpdateDto contentUpdateDto)
        {
            var updatedContent = _mapper.Map<Content>(contentUpdateDto);
            _contentRepository.Update(updatedContent);
            return contentUpdateDto;
        }
    }
}
