using JoyPromotion.Shared.Entities;
using System.Collections.Generic;

namespace JoyPromotion.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("Contents")]
    public class Content : IEntity
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string SlugTitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        // public Category Category { get; set; }
        // public User User { get; set; }
        // public List<ContentTag> ContentTags { get; set; }
    }
}
