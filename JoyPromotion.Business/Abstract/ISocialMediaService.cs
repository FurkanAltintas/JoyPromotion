using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using System.Collections.Generic;

namespace JoyPromotion.Business.Abstract
{
    public interface ISocialMediaService
    {
        List<SocialMediaListDto> GetAll();
        SocialMediaDto GetById(int id);
        SocialMediaAddDto Add(SocialMediaAddDto socialMediaAddDto);
        SocialMediaUpdateDto Update(SocialMediaUpdateDto socialMediaUpdateDto);
        void Delete(SocialMedia socialMedia);
        TDto Convert<TDto>(SocialMediaDto socialMediaDto);
    }
}
