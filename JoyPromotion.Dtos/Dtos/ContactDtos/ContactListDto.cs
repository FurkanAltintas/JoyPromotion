using System;

namespace JoyPromotion.Dtos.Dtos
{
    public class ContactListDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string HostName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
