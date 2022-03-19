using JoyPromotion.Shared.Entities;
using System.Collections.Generic;

namespace JoyPromotion.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("Users")]
    public class User : IEntity
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string PhoneNumber { get; set; }

        public List<Content> Contents { get; set; }
        public List<UserSocialMedia> UserSocialMedias { get; set; }
    }
}
