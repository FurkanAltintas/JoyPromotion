using System.Collections.Generic;

namespace JoyPromotion.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("Tags")]
    public class Tag
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ContentTag> ContentTags { get; set; }
    }
}
