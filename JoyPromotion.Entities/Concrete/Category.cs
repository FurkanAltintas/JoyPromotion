using JoyPromotion.Shared.Entities;
using System.Collections.Generic;

namespace JoyPromotion.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("Categories")]
    public class Category : IEntity
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Content> Contents { get; set; }
    }
}
