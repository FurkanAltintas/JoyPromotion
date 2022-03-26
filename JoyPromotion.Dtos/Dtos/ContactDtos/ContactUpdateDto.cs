using JoyPromotion.Shared.Entities;

namespace JoyPromotion.Dtos.Dtos
{
    public class ContactUpdateDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
