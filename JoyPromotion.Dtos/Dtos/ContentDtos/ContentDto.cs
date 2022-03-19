namespace JoyPromotion.Dtos.Dtos
{
    public class ContentDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string SlugTitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
