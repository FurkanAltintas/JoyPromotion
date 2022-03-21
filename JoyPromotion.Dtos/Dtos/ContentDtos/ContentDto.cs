using JoyPromotion.Shared.Entities;

namespace JoyPromotion.Dtos.Dtos
{
    public class ContentDto : IDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string SlugTitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
