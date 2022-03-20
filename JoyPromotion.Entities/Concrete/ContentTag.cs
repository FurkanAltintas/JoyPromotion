using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoyPromotion.Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("ContentTags")]
    public class ContentTag
    {
        [Dapper.Contrib.Extensions.Key]
        public int ContentId { get; set; }
        public Content Content { get; set; }

        [Dapper.Contrib.Extensions.Key]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
