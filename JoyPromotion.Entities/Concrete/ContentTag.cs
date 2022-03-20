using JoyPromotion.Shared.Entities;

namespace JoyPromotion.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("ContentTags")]
    public class ContentTag : IEntity
    {
        [Dapper.Contrib.Extensions.ExplicitKey]
        public int ContentId { get; set; }
        // public Content Content { get; set; }

        public int TagId { get; set; }
        // public Tag Tag { get; set; }
    }
}
