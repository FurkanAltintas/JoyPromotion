using AutoMapper;
using JoyPromotion.Business.Abstract;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess;
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

        public TDto Convert<TDto>(ContentDto contentDto)
        {
            return _mapper.Map<TDto>(contentDto);
        }

        public void Delete(Content content)
        {
            _contentRepository.Delete(content);
        }

        public List<ContentListDto> GetAll()
        {
            return _mapper.Map<List<ContentListDto>>(_contentRepository.GetAll());
        }

        public ContentDto GetById(int id)
        {
            return _mapper.Map<ContentDto>(_contentRepository.GetById(id));
        }

        public ContentUpdateDto Update(ContentUpdateDto contentUpdateDto)
        {
            var updatedContent = _mapper.Map<Content>(contentUpdateDto);
            _contentRepository.Update(updatedContent);
            return contentUpdateDto;
        }
    }
}
