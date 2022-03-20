using JoyPromotion.Shared.Entities;

namespace JoyPromotion.Dtos.Dtos
{
    public class ContentTagUpdateDto : IDto
    {
        public int ContentId { get; set; }
        public int TagId { get; set; }
    }
}
