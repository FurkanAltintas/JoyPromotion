using AutoMapper;
using JoyPromotion.Business.Abstract;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.Entities;
using System.Collections.Generic;

namespace JoyPromotion.Business.Concrete
{
    public class ContentTagManager : IContentTagService
    {
        private readonly IContentTagRepository _contentTagRepository;
        private readonly IMapper _mapper;

        public ContentTagManager(IContentTagRepository contentTagRepository, IMapper mapper)
        {
            _contentTagRepository = contentTagRepository;
            _mapper = mapper;
        }

        public void Add(IEnumerable<int> tagId, int contentId)
        {
            foreach (var tag in tagId)
            {
                new ContentTag
                {
                    ContentId = contentId,
                    TagId = tag
                };
            }

            #region Eski Hali
            // Manager
            //var addedContentTag = _mapper.Map<ContentTag>(contentTagAddDto);
            //_contentTagRepository.Add(addedContentTag);
            //return contentTagAddDto;

            // View
            //foreach (var tag in contentAddViewModel.TagId)
            //{
            //    _contentTagService.Add(new()
            //    {
            //        ContentId = content.Id,
            //        TagId = Convert.ToInt32(tag)
            //    });
            //}
            #endregion
        }

        public TDto Convert<TDto>(IDto dto)
        {
            return _mapper.Map<TDto>(dto);
        }

        public void Delete(ContentTag contentTag)
        {
            _contentTagRepository.Delete(contentTag);
        }

        public List<ContentTagListFetchDto> FetchTagsOfContent(int contentId)
        {
            return _contentTagRepository.FetchTagsOfContent<ContentTagListFetchDto>(contentId);
        }

        public List<ContentTagListDto> GetAll()
        {
            return _mapper.Map<List<ContentTagListDto>>(_contentTagRepository.GetAll());
        }

        public ContentTagDto GetById(int id)
        {
            return _mapper.Map<ContentTagDto>(_contentTagRepository.GetById(id));
        }

        public ContentTagUpdateDto Update(ContentTagUpdateDto contentTagUpdateDto)
        {
            var updatedContentTag = _mapper.Map<ContentTag>(contentTagUpdateDto);
            _contentTagRepository.Update(updatedContentTag);
            return contentTagUpdateDto;
        }
    }
}
