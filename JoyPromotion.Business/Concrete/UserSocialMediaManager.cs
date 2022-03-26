using AutoMapper;
using JoyPromotion.Business.Abstract;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Dtos.Dtos;
using System.Collections.Generic;

namespace JoyPromotion.Business.Concrete
{
    public class UserSocialMediaManager : IUserSocialMediaService
    {
        private readonly IUserSocialMediaRepository _userSocialMediaRepository;
        private readonly IMapper _mapper;

        public UserSocialMediaManager(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper)
        {
            _userSocialMediaRepository = userSocialMediaRepository;
            _mapper = mapper;
        }

        public List<UserSocialMediaListDto> GetUserSocialMedia(int userId)
        {
            return _mapper.Map<List<UserSocialMediaListDto>>(_userSocialMediaRepository.GetUserSocialMedia(userId));
        }
    }
}
