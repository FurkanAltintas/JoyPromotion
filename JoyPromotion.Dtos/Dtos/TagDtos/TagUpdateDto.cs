using JoyPromotion.Shared.Entities;

namespace JoyPromotion.Dtos.Dtos
{
    public class TagUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
