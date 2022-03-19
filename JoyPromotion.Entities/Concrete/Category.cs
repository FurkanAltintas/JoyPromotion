using JoyPromotion.Shared.Entities;
using System.Collections.Generic;

namespace JoyPromotion.Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Content> Contents { get; set; }
    }
}
