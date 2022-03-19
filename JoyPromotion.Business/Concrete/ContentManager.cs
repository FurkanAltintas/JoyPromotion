using JoyPromotion.Business.Abstract;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess;

namespace JoyPromotion.Business.Concrete
{
    public class ContentManager : GenericManager<Content>, IContentService
    {
        public ContentManager(IGenericRepository<Content> genericRepository) : base(genericRepository)
        {
        }
    }
}
