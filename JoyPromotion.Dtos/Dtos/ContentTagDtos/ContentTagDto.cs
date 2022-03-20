using JoyPromotion.Shared.Entities;

namespace JoyPromotion.Dtos.Dtos
{
    public class ContentTagDto : IDto
    {
        public int ContentId { get; set; }
        public int TagId { get; set; }
    }
}
