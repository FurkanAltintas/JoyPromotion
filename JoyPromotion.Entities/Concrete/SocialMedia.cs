using JoyPromotion.Shared.Entities;
using System.Collections.Generic;

namespace JoyPromotion.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("SocialMedias")]
    public class SocialMedia : IEntity
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public List<UserSocialMedia> UserSocialMedias { get; set; }
    }
}
