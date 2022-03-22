using JoyPromotion.Shared.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoyPromotion.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("Roles")]
    public class Role : IEntity
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public List<User> Users { get; set; }
    }
}