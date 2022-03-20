using JoyPromotion.Shared.Entities;

namespace JoyPromotion.Dtos.Dtos
{
    public class ContentTagListDto : IDto
    {
        public int ContentId { get; set; }
        public int TagId { get; set; }
    }
}
