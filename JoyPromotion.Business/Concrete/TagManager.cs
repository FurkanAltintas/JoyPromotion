using AutoMapper;
using JoyPromotion.Business.Abstract;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using System.Collections.Generic;

namespace JoyPromotion.Business.Concrete
{
    public class TagManager : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagManager(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public TagAddDto Add(TagAddDto tagAddDto)
        {
            var addedTag = _mapper.Map<Tag>(tagAddDto);
            _tagRepository.Add(addedTag);
            return tagAddDto;
        }

        public TDto Convert<TDto>(TagDto tagDto)
        {
            return _mapper.Map<TDto>(tagDto);
        }

        public void Delete(Tag tag)
        {
            _tagRepository.Delete(tag);
        }

        public List<TagListDto> GetAll()
        {
            return _mapper.Map<List<TagListDto>>(_tagRepository.GetAll());
        }

        public TagDto GetById(int id)
        {
            return _mapper.Map<TagDto>(_tagRepository.GetById(id));
        }

        public TagUpdateDto Update(TagUpdateDto tagUpdateDto)
        {
            var updatedTag = _mapper.Map<Tag>(tagUpdateDto);
            _tagRepository.Update(updatedTag);
            return tagUpdateDto;
        }
    }
}
