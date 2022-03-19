using JoyPromotion.Shared.Entities;
using System.Collections.Generic;

namespace JoyPromotion.Entities.Concrete
{
    public class SocialMedia : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public List<UserSocialMedia> UserSocialMedias { get; set; }
    }
}
