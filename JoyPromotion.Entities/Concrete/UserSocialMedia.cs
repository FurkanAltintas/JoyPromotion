using JoyPromotion.Shared.Entities;

namespace JoyPromotion.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("UserSocialMedias")]
    public class UserSocialMedia : IEntity
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public int SocialMediaId { get; set; }
        public int UserId { get; set; }
        public string Url { get; set; }

        public SocialMedia SocialMedia { get; set; }
        public User User { get; set; }
    }
}
