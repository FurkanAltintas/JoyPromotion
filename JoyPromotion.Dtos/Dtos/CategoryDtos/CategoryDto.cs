using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.Entities;

namespace JoyPromotion.Dtos.Dtos
{
    public class CategoryDto : DtoGetBase, IDto
    {
        //public int Id { get; set; }
        //public string Name { get; set; }

        public Category Category { get; set; }
    }
}
