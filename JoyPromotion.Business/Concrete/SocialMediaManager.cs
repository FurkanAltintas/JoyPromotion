using AutoMapper;
using JoyPromotion.Business.Abstract;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using System.Collections.Generic;

namespace JoyPromotion.Business.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IMapper _mapper;

        public SocialMediaManager(ISocialMediaRepository socialMediaRepository, IMapper mapper)
        {
            _socialMediaRepository = socialMediaRepository;
            _mapper = mapper;
        }

        public SocialMediaAddDto Add(SocialMediaAddDto socialMediaAddDto)
        {
            var addedSocialMedia = _mapper.Map<SocialMedia>(socialMediaAddDto);
            _socialMediaRepository.Add(addedSocialMedia);
            return socialMediaAddDto;
        }

        public TDto Convert<TDto>(SocialMediaDto socialMediaDto)
        {
            return _mapper.Map<TDto>(socialMediaDto);
        }

        public void Delete(SocialMedia socialMedia)
        {
            _socialMediaRepository.Delete(socialMedia);
        }

        public List<SocialMediaListDto> GetAll()
        {
            return _mapper.Map<List<SocialMediaListDto>>(_socialMediaRepository.GetAll());
        }

        public SocialMediaDto GetById(int id)
        {
            return _mapper.Map<SocialMediaDto>(_socialMediaRepository.GetById(id));
        }

        public SocialMediaUpdateDto Update(SocialMediaUpdateDto socialMediaUpdateDto)
        {
            var updatedSocialMedia = _mapper.Map<SocialMedia>(socialMediaUpdateDto);
            _socialMediaRepository.Update(updatedSocialMedia);
            return socialMediaUpdateDto;
        }
    }
}
