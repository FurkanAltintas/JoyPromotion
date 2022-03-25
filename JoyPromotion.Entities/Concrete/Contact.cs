using JoyPromotion.Shared.Entities;
using System;

namespace JoyPromotion.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("Contacts")]
    public class Contact : IEntity
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string HostName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
