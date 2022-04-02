using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.Entities;
using System.Collections.Generic;

namespace JoyPromotion.Dtos.Dtos
{
    public class CategoryListDto : DtoGetBase, IDto
    {
        //public int Id { get; set; }
        //public string Name { get; set; }

        public IList<Category> Categories { get; set; }
    }
}
